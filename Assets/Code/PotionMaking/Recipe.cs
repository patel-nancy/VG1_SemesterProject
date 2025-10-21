using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Recipe
{
    public String name;
    public List<Action> actions;

    // public bool CheckRecipe(List<Action> playerActions)
    // {
    //     if (actions.Count != playerActions.Count)
    //     {
    //         Debug.Log("Expected Actions Count: " + actions.Count);
    //         Debug.Log("Played Actions Count: " + playerActions.Count);
    //         return false;
    //     }
    //     
    //     for (int i = 0; i < playerActions.Count; i++)
    //     {
    //         if (!playerActions[i].Equals(actions[i])) //order matters
    //         {
    //             Debug.Log("NOT EQUAL! Player: " + playerActions[i].description() + "Action:" + actions[i].description());
    //             return false;
    //         }
    //     }
    //     return true;
    // }
    
    public float ScoreRecipe(List<Action> playerActions)
    {
        float[] actions_array = new float[actions.Count];
        float[] playerActions_array = new float[playerActions.Count];

        for (int i = 0; i < actions_array.Length; i++)
        {
            actions_array[i] = actions.ElementAt(i).ToFloat();
        }

        for (int i = 0; i < playerActions_array.Length; i++)
        {
            playerActions_array[i] = playerActions.ElementAt(i).ToFloat();
        }

        float score = 10 - CalculateDistance(actions_array, playerActions_array);
        Debug.Log("Score: " + score);
        
        return score;
    }

    private float CalculateDistance(float[] a1, float[] a2)
    {
        float sum = 0;
        int n = Math.Max(a1.Length, a2.Length);

        for (int i = 0; i < n; i++)
        {
            float diff = 0;
            if (i < a1.Length && i < a2.Length)
            {
                diff = a1[i] - a2[i];
            }
            else if (i < a1.Length && i >= a1.Length)
            {
                diff = a1[i] - 0;
            }
            else 
            {
                diff = 0 - a2[i];
            }

            sum += diff * diff;
        }

        return (float)Math.Sqrt(sum);
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
