using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDrag : MonoBehaviour
{
    
    private bool dragging = false;
    private Vector2 offset;
    
    private Ingredient ingredient;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        // TODO: generalize
        if (gameObject.name.StartsWith("ingredients_0"))
        {
            ingredient = new Ingredient(IngredientName.Bat);
        }
        else if (gameObject.name.StartsWith("ingredients_1"))
        {
            ingredient = new Ingredient(IngredientName.Frog);
        }
        else if (gameObject.name.StartsWith("ingredients_2"))
        {
            ingredient = new Ingredient(IngredientName.Eye);
        }

    }
    
    private void OnMouseDown()
    {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + offset; 
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (dragging)
            return;

        Cauldron cauldron = other.gameObject.GetComponent<Cauldron>();
        if (cauldron)
        {
            Debug.Log(ingredient.name);
            OrderSession.instance.currPlayerActions.Add(new AddIngredientAction(ingredient)); 
            // //TODO: need to see if this ingredient is a counter
            
            Destroy(this.gameObject);
        }
    }
}
