using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientName { Frog, Bat, Eye } //general ingredients to be used 
public enum CounterIngredientName { Toad, Squirrel, Hair} //counters for general ingredients

public class Ingredient : MonoBehaviour
{
    public IngredientName name;
    private CounterIngredientName counterName;
    private bool dragging = false;
    
    private Vector2 offset;
    
    void Start()
    {
        CounterIngredientName[] counterIngredients = (CounterIngredientName[])Enum.GetValues(typeof(CounterIngredientName));
        counterName = counterIngredients[(int)name];
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
            cauldron.session.playerActions.Add(new AddIngredientAction(this)); 
            //TODO: need to see if this ingredient is a counter
            
            Debug.Log(name);
            Destroy(this.gameObject);
        }
    }
}
