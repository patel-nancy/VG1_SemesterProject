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
        if (expectedRecipe.Equals(approximateRecipe))
            return approximateRecipe.ScoreRecipe(actions);
        else
            return -OrderSession.instance.MAX_SCORE;
    }
}