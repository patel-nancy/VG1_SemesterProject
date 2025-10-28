using System;
using System.Collections;
using System.Collections.Generic;

public class Potion
{
    public List<Action> actions;
    public Recipe approximateRecipe;

    public Potion(List<Action> actions, Recipe approximateRecipe)
    {
        this.actions = new List<Action>(actions);
        this.approximateRecipe = approximateRecipe;
    }

    public float score(Recipe expectedRecipe)
    {
        return approximateRecipe.ScoreRecipe(actions);
    }
}