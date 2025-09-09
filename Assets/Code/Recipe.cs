using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public String name;
    public String purpose;
    public List<IngredientName> ingredients = new List<IngredientName>();

    public bool CheckRecipe(List<IngredientName> pickedIngredients)
    {
        if (ingredients.Count != pickedIngredients.Count)
        {
            return false;
        }

    for (int i = 0; i < pickedIngredients.Count; i++)
        {
            if (pickedIngredients[i] != ingredients[i]) //order matters
            {
                return false;
            }
        }
        return true;
    }
}
