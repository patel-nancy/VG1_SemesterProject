using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIngredientAction : Action
{
    private Ingredient ingredient;

    public AddIngredientAction(Ingredient ingredient)
    {
        this.ingredient = ingredient;
    }

    public override String description()
    {
        return $"Add {ingredient.name}";
    }
}
