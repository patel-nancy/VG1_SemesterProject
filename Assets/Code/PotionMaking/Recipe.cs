using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public String name;
    public String purpose;
    public List<Action> actions;

    public bool CheckRecipe(List<Action> playerActions)
    {
        Debug.Log("Player Actions Count: " + playerActions.Count);
        if (actions.Count != playerActions.Count)
        {
            return false;
        }
        
        for (int i = 0; i < playerActions.Count; i++)
        {
            if (!playerActions[i].Equals(actions[i])) //order matters
            {
                Debug.Log("NOT EQUAL: " + playerActions[i].description() + " " + actions[i].description());
                return false;
            }
        }
        return true;
    }

    public Recipe(String name, String purpose, List<Action> actions)
    {
        this.name = name;
        this.purpose = purpose;
        this.actions = actions;
    }
}
