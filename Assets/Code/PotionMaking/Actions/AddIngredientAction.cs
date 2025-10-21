using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIngredientAction : Action
{
    public Ingredient ingredient;

    public AddIngredientAction(Ingredient ingredient)
    {
        this.ingredient = ingredient;
    }

    public override String description()
    {
        return $"Add {ingredient.name}";
    }

    public override bool Equals(Action action)
    {
        if (action is AddIngredientAction other)
        {
            return ingredient.Equals(other.ingredient);
        }
        return false;
    }

    public override float ToFloat()
    {
        return (int)ingredient.name;
    }
}
