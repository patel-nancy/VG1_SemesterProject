using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public PotionMakingSession session;
    
    void OnCollisionStay2D(Collision2D other)
    {

        Ingredient ingredient = other.gameObject.GetComponent<Ingredient>();
        
        if (ingredient)
        {
            session.playerActions.Add(new AddIngredientAction(ingredient)); 
            //TODO: need to see if this ingredient is a counter
            
            Debug.Log(ingredient.name);
            Destroy(other.gameObject);
        }
    }
    
}
