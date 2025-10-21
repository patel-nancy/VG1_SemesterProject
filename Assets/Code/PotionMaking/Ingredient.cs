using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: ORDER MATTERS!
public enum IngredientName 
    { Frog, Bat, //general ingredients
      Toad, Squirrel } //counters for general ingredients

public class Ingredient
{
    public IngredientName name; //TODO: should be private. make getters/setters later
    public IngredientName counterName;

    public Ingredient(IngredientName name)
    {
        this.name = name;
        
        IngredientName[] ingredients = (IngredientName[])Enum.GetValues(typeof(IngredientName));
        int wrap_idx = (((int) name) + (ingredients.Length / 2)) % ingredients.Length;
        this.counterName = ingredients[wrap_idx];
    }
    
    public bool Equals(Ingredient other)
    {
        if (this.name != other.name)
        {
            return false;
        }
        return true;
      
    }
}
