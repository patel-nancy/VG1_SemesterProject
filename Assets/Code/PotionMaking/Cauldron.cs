using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // only needed if you use the optional UI text

public partial class Cauldron : MonoBehaviour
{
    [Header("Timer Defaults")]
    [SerializeField] private float defaultTimerSeconds = 5f;

    [System.Serializable]
    public struct IngredientTimer
    {
        public IngredientName name;
        public float seconds;
    }

    [Tooltip("Overrides for specific ingredients; otherwise defaultTimerSeconds is used.")]
    [SerializeField] private List<IngredientTimer> perIngredientTimers = new List<IngredientTimer>();

    [Header("Optional UI")]
    [SerializeField] private Text timerText; // drag a UI Text here if you want on-screen countdown

    // Runtime
    private Dictionary<IngredientName, float> _timerLookup;
    private Coroutine _currentTimerCo;
    private bool _timerRunning;
    private float _remaining;
    private IngredientName _currentIngredient;

    // Optional public events/hooks
    public System.Action<IngredientName> OnTimerStarted;
    public System.Action<IngredientName> OnTimerFinished;

    private void Awake()
    {
        // Build quick lookup for per-ingredient durations
        _timerLookup = new Dictionary<IngredientName, float>();
        foreach (var it in perIngredientTimers)
        {
            _timerLookup[it.name] = Mathf.Max(0f, it.seconds);
        }
        UpdateTimerUI(null); // clear at start
    }

    /// <summary>
    /// Call this when an ingredient enters the cauldron.
    /// </summary>
    public void StartIngredientTimer(Ingredient ingredient)
    {
        // If you only want a SPECIFIC ingredient to start a timer, uncomment & adjust:
        // if (ingredient.name != IngredientName.Frog) return;

        float duration = _timerLookup.TryGetValue(ingredient.name, out var custom)
            ? custom
            : defaultTimerSeconds;

        if (_currentTimerCo != null)
            StopCoroutine(_currentTimerCo);

        _currentIngredient = ingredient.name;
        _currentTimerCo = StartCoroutine(TimerRoutine(_currentIngredient, duration));
    }

    private IEnumerator TimerRoutine(IngredientName ingName, float seconds)
    {
        _timerRunning = true;
        _remaining = seconds;
        OnTimerStarted?.Invoke(ingName);

        while (_remaining > 0f)
        {
            _remaining -= Time.deltaTime;
            UpdateTimerUI(_remaining);
            yield return null;
        }

        _timerRunning = false;
        _remaining = 0f;
        UpdateTimerUI(_remaining);

        // TODO: trigger whatever should happen when the timer completes for this ingredient
        // e.g., increase potency, progress recipe step, allow next action, etc.
        Debug.Log($"Timer finished for {ingName}");
        OnTimerFinished?.Invoke(ingName);
    }

    private void UpdateTimerUI(float? remaining)
    {
        if (!timerText) return;

        if (remaining == null)
        {
            timerText.text = "";
        }
        else
        {
            float r = Mathf.Max(0f, remaining.Value);
            timerText.text = $"Timer: {r:0.0}s";
        }
    }

    // Optional getters if other scripts/UI want to check timer state
    public bool IsTimerRunning => _timerRunning;
    public float RemainingSeconds => _remaining;
    public IngredientName CurrentTimedIngredient => _currentIngredient;
}
