using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerProfile : MonoBehaviour
{
    public string customerName;
    static readonly string[] Names = { "Agnes", "Mary", "Thomas", "John", "Martha" };

    public Sprite[] spriteOptions;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        RandomizeProfile();
    }

    public void RandomizeProfile()
    {
        // Randomize name
        customerName = Names[Random.Range(0, Names.Length)];

        // Randomize sprite
        if (spriteRenderer != null && spriteOptions.Length > 0)
        {
            spriteRenderer.sprite = spriteOptions[Random.Range(0, spriteOptions.Length)];
        }
    }
}
