using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;   // for EventSystem.current
using TMPro;

public class IngredientsPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text ingredientsText;

    // Fallback (shown if no mapping is found)
    [Header("Fallback")]
    [SerializeField] private string defaultPotionName = "Potion";
    [SerializeField, TextArea] private string[] defaultIngredients;

    // Automated mode: watch current selected UI and update automatically
    [Header("Automated Mode")]
    [SerializeField] private bool autoUpdateFromSelectedUI = true;

    [System.Serializable]
    public class RecipeEntry
    {
        public string potionName;                 // must match the button/label text
        [TextArea] public string[] ingredients;   // one per line in Inspector
    }

    [SerializeField] private List<RecipeEntry> recipeTable = new List<RecipeEntry>();

    // runtime helpers
    private Dictionary<string, string[]> _lookup;
    private string _lastShownName;

    void Awake()
    {
        // Build case-insensitive lookup from the table
        _lookup = new Dictionary<string, string[]>(System.StringComparer.OrdinalIgnoreCase);
        foreach (var e in recipeTable)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.potionName)) continue;
            _lookup[e.potionName.Trim()] = e.ingredients ?? System.Array.Empty<string>();
        }
    }

    void Start()
    {
        if (ingredientsText != null)
            ingredientsText.text = "Select a potion to see its ingredients.";
        else
            Debug.LogWarning("[IngredientsPanel] ingredientsText is not assigned!");
    }

    void Update()
    {
        if (!autoUpdateFromSelectedUI) return;

        var go = EventSystem.current ? EventSystem.current.currentSelectedGameObject : null;
        if (!go) return;

        string nameFromUI = TryGetLabel(go);
        if (string.IsNullOrWhiteSpace(nameFromUI)) return;

        if (nameFromUI.Equals(_lastShownName)) return;

        if (_lookup != null && _lookup.TryGetValue(nameFromUI, out var ing))
        {
            ShowIngredients(nameFromUI, ing);
            _lastShownName = nameFromUI;
        }
        else
        {
            ShowIngredients(defaultPotionName, defaultIngredients);
            _lastShownName = nameFromUI;
        }
    }

    // Reads TMP text from this object or its children
    private string TryGetLabel(GameObject go)
    {
        var tmp = go.GetComponentInChildren<TMP_Text>();
        if (tmp && !string.IsNullOrWhiteSpace(tmp.text)) return tmp.text.Trim();

        // If you also use legacy Text, you can add:
        // var ugui = go.GetComponentInChildren<UnityEngine.UI.Text>();
        // if (ugui && !string.IsNullOrWhiteSpace(ugui.text)) return ugui.text.Trim();

        return null;
    }

    // You can still call this from anywhere if you want
    public void ShowDefault()
    {
        ShowIngredients(defaultPotionName, defaultIngredients);
    }

    public void ShowIngredients(string potionName, IEnumerable<string> ingredients)
    {
        if (ingredientsText == null)
        {
            Debug.LogWarning("[IngredientsPanel] Cannot show — ingredientsText is not assigned!");
            return;
        }

        var sb = new StringBuilder();
        sb.AppendLine($"<b>{(string.IsNullOrWhiteSpace(potionName) ? "Potion" : potionName)}</b>");

        if (ingredients == null)
        {
            sb.AppendLine("• No ingredients.");
        }
        else
        {
            foreach (var item in ingredients)
            {
                if (string.IsNullOrWhiteSpace(item)) continue;
                sb.AppendLine($"• {item}");
            }
        }

        ingredientsText.text = sb.ToString();
    }
}
