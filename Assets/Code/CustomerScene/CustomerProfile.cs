using UnityEngine;
using UnityEngine.UI; 

public class CustomerProfile : MonoBehaviour
{
    public string customerName;
    static readonly string[] Names = { "Agnes", "Mary", "Thomas", "John", "Martha" };

    public Sprite[] spriteOptions;

    private SpriteRenderer spriteRenderer;
    private Image uiImage;

    private int lastSpriteIndex = -1;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>() ?? GetComponentInChildren<SpriteRenderer>(true);
        uiImage        = GetComponent<Image>()          ?? GetComponentInChildren<Image>(true);

        RandomizeProfile();
    }

    public void RandomizeProfile()
    {
        Debug.Log("[CustomerProfile] RandomizeProfile called");

        // Randomize name
        customerName = Names[Random.Range(0, Names.Length)];

        if (spriteOptions == null || spriteOptions.Length == 0)
        {
            Debug.LogWarning("[CustomerProfile] No sprites assigned.");
            return;
        }

        int idx;
        if (spriteOptions.Length == 1)
        {
            idx = 0;
        }
        else
        {
            do
            {
                idx = Random.Range(0, spriteOptions.Length); 
            } while (idx == lastSpriteIndex);
        }

        var chosen = spriteOptions[idx];
        if (chosen == null)
        {
            Debug.LogWarning("[CustomerProfile] Chosen sprite was null; check your array.");
            return;
        }

        if (spriteRenderer != null)
            spriteRenderer.sprite = chosen;
        if (uiImage != null)
            uiImage.sprite = chosen;

        lastSpriteIndex = idx;

        Debug.Log($"[CustomerProfile] Name: {customerName}, SpriteIndex: {idx}, Sprite: {chosen.name}");
    }
}
