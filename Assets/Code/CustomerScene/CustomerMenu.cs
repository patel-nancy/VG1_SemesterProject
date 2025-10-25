using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles customer interactions on the customer menu screen
public class CustomerMenu : MonoBehaviour
{
    private CustomerProfile profile;

    void Start()
    {
        profile = FindObjectOfType<CustomerProfile>();
    }

    // Called when the player selects the "Invisibility" potion.
    public void PickInvisibility()
    {
        OrderSession.instance.SetOrder(profile.customerName, OrderSession.recipe_cookbook["invisibility"]);
    }

    // Called when the player selects the "Flying" potion.
    public void PickFlying()
    {
        OrderSession.instance.SetOrder(profile.customerName, OrderSession.recipe_cookbook["flying"]);
    }

    // Called when the player selects the "Liquid Luck" potion.
    public void PickLiquidLuck()
    {
        OrderSession.instance.SetOrder(profile.customerName, OrderSession.recipe_cookbook["liquid_luck"]);
    }

    // Sends the selected order to the potion-making (cauldron) scene.
    public void SendToCauldron()
    {
        if (OrderSession.instance.selectedRecipe.name == null)
        {
            Debug.LogWarning("[CustomerMenu] No recipe selected; ignoring SendToCauldron");
            return;
        }

        // Tutorial mode behavior: re-prompt if incorrect recipe is chosen
        if (OrderSession.isTutorial && OrderSession.instance.selectedRecipe.name != "invisibility")
        {
            CustomerSceneTutorialController.instance.Reprompt();
            return;
        }

        // Load the potion-making scene
        SceneManager.LoadScene("PotionMaking");
    }
}
