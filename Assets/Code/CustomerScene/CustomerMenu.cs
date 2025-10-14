using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerMenu : MonoBehaviour
{
    CustomerProfile profile;

    void Start()
    {
        profile = FindObjectOfType<CustomerProfile>();
    }
    
    public void PickInvisibility() {
        OrderSession.instance.SetOrder(profile.customerName, OrderSession.recipe_cookbook["invisibility"]);
    }

    public void PickFlying()
    {
        OrderSession.instance.SetOrder(profile.customerName, OrderSession.recipe_cookbook["flying"]);
    }

    public void PickLiquidLuck() {
        OrderSession.instance.SetOrder(profile.customerName, OrderSession.recipe_cookbook["liquid_luck"]);
    }

    public void SendToCauldron() {
        if (OrderSession.instance.selectedRecipe.name == null) {
            Debug.LogWarning("[CustomerMenu] No recipe selected; ignoring SendToCauldron");
            return;
        }

        //if on tutorial mode AND they pick the WRONG recipe (not invisibility), then reprompt
        if (OrderSession.isTutorial && OrderSession.instance.selectedRecipe.name != "invisibility")
        {
            CustomerSceneTutorialController.instance.Reprompt();
            return;
        }
        
        SceneManager.LoadScene("PotionMaking");
    }
}
