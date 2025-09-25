using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientName { Frog, Bat, Eye } 
public enum CounterIngredientName { Toad, Squirrel, Hair} //counters for general ingredients

public class Ingredient
{
    public IngredientName name; //TODO: should be private. make getters/setters later
    private CounterIngredientName counterName;

    public Ingredient(IngredientName name)
    {
        this.name = name;
        CounterIngredientName[] counterIngredients = (CounterIngredientName[])Enum.GetValues(typeof(CounterIngredientName));
        this.counterName = counterIngredients[(int)name];
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
