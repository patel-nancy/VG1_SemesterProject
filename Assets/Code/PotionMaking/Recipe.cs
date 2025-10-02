using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public String name;
    public List<Action> actions;

    public bool CheckRecipe(List<Action> playerActions)
    {
        if (actions.Count != playerActions.Count)
        {
            Debug.Log("Expected Actions Count: " + actions.Count);
            Debug.Log("Played Actions Count: " + playerActions.Count);
            return false;
        }
        
        for (int i = 0; i < playerActions.Count; i++)
        {
            if (!playerActions[i].Equals(actions[i])) //order matters
            {
                Debug.Log("NOT EQUAL! Player: " + playerActions[i].description() + "Action:" + actions[i].description());
                return false;
            }
        }
        return true;
    }

    public Recipe(String name, List<Action> actions)
    {
        this.name = name;
        this.actions = actions;
    }

    public static String describe(List<Action> actions)
    {
        String d = "";
        for (int i = 0; i < actions.Count; i++)
        {
            d += actions[i].description() + "\n";
        }
        return d;
    }
}
