using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDrag : MonoBehaviour
{
    
    public bool dragging = true;
    private Vector2 offset;
    
    private Ingredient ingredient;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        // TODO: generalize
        if (gameObject.name.StartsWith("bat"))
        {
            ingredient = new Ingredient(IngredientName.Bat);
        }
        else if (gameObject.name.StartsWith("frog"))
        {
            ingredient = new Ingredient(IngredientName.Frog);
        }
        else if (gameObject.name.StartsWith("squirrel"))
        {
            ingredient = new Ingredient(IngredientName.Squirrel);
        }
        else if (gameObject.name.StartsWith("toad"))
        {
            ingredient = new Ingredient(IngredientName.Toad);
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (dragging)
            return;

        Cauldron cauldron = other.gameObject.GetComponent<Cauldron>();
        if (cauldron)
        {
            OrderSession.instance.AddAction(new AddIngredientAction(ingredient));
            Destroy(this.gameObject);
        }
    }
}
