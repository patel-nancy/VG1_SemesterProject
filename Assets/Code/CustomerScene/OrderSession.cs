using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSession : MonoBehaviour
{
    public static OrderSession Instance { get; private set; }
    public string customerName;
    public string recipeName;
    public List<IngredientName> recipeIngredients = new();

    void Awake() {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("[OrderSession] Awake (DontDestroyOnLoad)");
    }

    public void SetOrder(string cust, string rec, List<IngredientName> ings) {
        customerName = cust;
        recipeName = rec;
        recipeIngredients = new List<IngredientName>(ings);
        Debug.Log($"[OrderSession] SetOrder -> customer={customerName}, recipe={recipeName}, ingredients=[{string.Join(", ", recipeIngredients)}]");
    }
}
