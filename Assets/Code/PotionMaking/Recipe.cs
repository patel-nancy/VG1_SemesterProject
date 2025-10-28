using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Recipe
{
    public String name;
    public List<Action> actions;
    
    public float ScoreRecipe(List<Action> playerActions)
    {
        float MAX_SCORE = OrderSession.instance.MAX_SCORE;
        
        Vector3 actions_vector = new Vector3(0, 0, 0);
        Vector3 playerActions_vector = new Vector3(0, 0, 0);

        foreach (Action action in actions)
        {
            //[1, 0, 0]
            if (action is AddIngredientAction)
            {
                actions_vector.x += action.ToFloat();
            }   
            //[0, 1, 0]
            else if (action is FireAction)
            {
                actions_vector.y += action.ToFloat();
            }
            //[0, 0, 1]
            else
            {
                actions_vector.z += action.ToFloat();
            }
        }
        foreach (Action action in playerActions)
        {
            //[1, 0, 0]
            if (action is AddIngredientAction)
            {
                playerActions_vector.x += action.ToFloat();
            }   
            //[0, 1, 0]
            else if (action is FireAction)
            {
                playerActions_vector.y += action.ToFloat();
            }
            //[0, 0, 1]
            else
            {
                playerActions_vector.z += action.ToFloat();
            }
        }
        
        //normalize vectors [-1,1]
        float maxX = Mathf.Max(Mathf.Abs(actions_vector.x), Mathf.Abs(playerActions_vector.x));
        float maxY = Mathf.Max(Mathf.Abs(actions_vector.y), Mathf.Abs(playerActions_vector.y));
        float maxZ = Mathf.Max(Mathf.Abs(actions_vector.z), Mathf.Abs(playerActions_vector.z));

        //ensure no divide by 0
        if (maxX == 0)
        {
            maxX = 1;
        }

        if (maxY == 0)
        {
            maxY = 1;
        }

        if (maxZ == 0)
        {
            maxZ = 1;
        }
        
        actions_vector.x /= maxX;
        actions_vector.y /= maxY;
        actions_vector.z /= maxZ;
        
        playerActions_vector.x /= maxX;
        playerActions_vector.y /= maxY;
        playerActions_vector.z /= maxZ;
        
        //scale s.t. maximum distance <= MAX_SCORE (s.t. score = [-MAX_SCORE, MAX_SCORE]
        float max_og_dist = Mathf.Sqrt(12); //[-1, -1, -1] and [1, 1, 1]
        float scale = 2 * MAX_SCORE / max_og_dist;
        
        actions_vector.x *= scale;
        actions_vector.y *= scale;
        actions_vector.z *= scale;
        
        playerActions_vector.x *= scale;
        playerActions_vector.y *= scale;
        playerActions_vector.z *= scale;
        
        //calculate distance btwn normalized/scaled vectors
        float distance = Vector3.Distance(actions_vector, playerActions_vector);
        float score = MAX_SCORE - distance;
        return score;

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
