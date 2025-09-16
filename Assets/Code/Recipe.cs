using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public String name;
    public String purpose;
    public List<Action> actions = new List<Action>();

    public bool CheckRecipe(List<Action> playerActions)
    {
        if (actions.Count != playerActions.Count)
        {
            return false;
        }

        for (int i = 0; i < playerActions.Count; i++)
        {
            //TODO: some sort of IsEqual() 
            if (playerActions[i] != actions[i]) //order matters
            {
                return false;
            }
        }
        return true;
    }
}
