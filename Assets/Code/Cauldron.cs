using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public List<IngredientName> ingredients = new List<IngredientName>();
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        if (ingredient != null)
        {
            ingredients.Add(ingredient.name);
            Debug.Log(ingredient.name);
            Destroy(other.gameObject);
        }
    }
}
