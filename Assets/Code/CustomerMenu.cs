using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerMenu : MonoBehaviour
{
    [SerializeField] string cauldronSceneName = "PotionMaking"; 
    DialogueController dialogue;
    CustomerProfile profile;

    void Start() {
        dialogue = FindObjectOfType<DialogueController>();
        profile  = FindObjectOfType<CustomerProfile>();
        Debug.Log($"[CustomerMenu] Start. profile={(profile ? profile.customerName : "null")}, dialogue={(dialogue ? "ok" : "null")}");
    }

    public void PickFlying() {
        var ings = new List<IngredientName>{ IngredientName.Frog, IngredientName.Bat };
        if (OrderSession.Instance == null) { Debug.LogError("[CustomerMenu] No OrderSession in scene!"); return; }
        OrderSession.Instance.SetOrder(profile.customerName, "Flying Potion", ings);
        dialogue?.SetLine($"{profile.customerName}: \"I’ll take a Flying Potion.\"");
    }

    public void PickInvisibility() {
        var ings = new List<IngredientName>{ IngredientName.Eye, IngredientName.Bat };
        if (OrderSession.Instance == null) { Debug.LogError("[CustomerMenu] No OrderSession in scene!"); return; }
        OrderSession.Instance.SetOrder(profile.customerName, "Invisibility", ings);
        dialogue?.SetLine($"{profile.customerName}: \"I’ll take an Invisibility Potion.\"");
    }

    public void PickLiquidLuck() {
        var ings = new List<IngredientName>{ IngredientName.Frog, IngredientName.Eye };
        if (OrderSession.Instance == null) { Debug.LogError("[CustomerMenu] No OrderSession in scene!"); return; }
        OrderSession.Instance.SetOrder(profile.customerName, "Liquid Luck", ings);
        dialogue?.SetLine($"{profile.customerName}: \"I’ll take Liquid Luck.\"");
    }

    public void SendToCauldron() {
        if (OrderSession.Instance == null) { Debug.LogError("[CustomerMenu] No OrderSession!"); return; }
        if (OrderSession.Instance.recipeIngredients.Count == 0) {
            Debug.LogWarning("[CustomerMenu] No recipe selected; ignoring SendToCauldron");
            return;
        }
        Debug.Log($"[CustomerMenu] Loading scene '{cauldronSceneName}'…");
        SceneManager.LoadScene(cauldronSceneName);
    }
}
