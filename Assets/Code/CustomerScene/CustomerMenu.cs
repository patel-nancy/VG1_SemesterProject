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
        // Debug.Log($"[CustomerMenu] Start. profile={(profile ? profile.customerName : "null")}, dialogue={(dialogue ? "ok" : "null")}");
    }
    
    public void PickInvisibility() {
        List<Action> actions = new List<Action>();
        Ingredient i1 = new Ingredient(IngredientName.Bat);
        Stir s1 = new Stir(-360f);
        actions.Add(new AddIngredientAction(i1));
        actions.Add(new StirCauldronAction(s1));

        Recipe recipe = new Recipe("invisibility", actions);
        // if (OrderSession.instance == null)
        // {
        //     Debug.LogError("[CustomerMenu] No OrderSession in scene!"); return;
        // }
        OrderSession.instance.SetOrder(profile.customerName, recipe);
        
        dialogue?.SetLine($"{profile.customerName}: \"I’ll take an Invisibility Potion.\"");
    }

    public void PickFlying() {
        List<Action> actions = new List<Action>();
        Ingredient i1 = new Ingredient(IngredientName.Bat);
        Ingredient i2 = new Ingredient(IngredientName.Frog);
        actions.Add(new AddIngredientAction(i1));
        actions.Add(new AddIngredientAction(i2));
        Recipe recipe = new Recipe("flying", actions);

        // if (OrderSession.instance == null)
        // {
        //     Debug.LogError("[CustomerMenu] No OrderSession in scene!"); return;
        // }
        OrderSession.instance.SetOrder(profile.customerName, recipe);
        
        dialogue?.SetLine($"{profile.customerName}: \"I’ll take a Flying Potion.\"");
    }

    public void PickLiquidLuck() {
        List<Action> actions = new List<Action>();
        Ingredient i1 = new Ingredient(IngredientName.Frog);
        Fire f1 = new Fire(4f);
        actions.Add(new AddIngredientAction(i1));
        actions.Add(new FireAction(f1));
        
        Recipe recipe = new Recipe("liquid_luck", actions);
        // if (OrderSession.instance == null)
        // {
        //     Debug.LogError("[CustomerMenu] No OrderSession in scene!"); return;
        // }
        OrderSession.instance.SetOrder(profile.customerName, recipe);
        dialogue?.SetLine($"{profile.customerName}: \"I’ll take Liquid Luck.\"");
    }

    public void SendToCauldron() {
        // if (OrderSession.instance == null)
        // {
        //     Debug.LogError("[CustomerMenu] No OrderSession!"); return;
        // }
        
        Debug.Log("submit");
        if (OrderSession.instance.currRecipe.name == null) {
            Debug.LogWarning("[CustomerMenu] No recipe selected; ignoring SendToCauldron");
            return;
        }
        
        SceneManager.LoadScene(cauldronSceneName);
    }
}
