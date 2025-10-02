using UnityEngine;
using TMPro;

public class HelperText : MonoBehaviour
{
    [SerializeField] private TMP_Text recipeText;
    [SerializeField] private TMP_Text actualText;
    
    void Update()
    {
        if (OrderSession.instance != null)
        {
            recipeText.text = "Recipe: \n" + Recipe.describe(OrderSession.instance.currRecipe.actions) + "Bottle potion!";
            actualText.text = "Your actions: \n" + Recipe.describe(OrderSession.instance.currPlayerActions);
        }
    }
}
