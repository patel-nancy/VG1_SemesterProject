using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientName { Frog, Bat, Eye, Newt } //general ingredients to be used 

static class IngredientNameExtensions
{
    public static IngredientName Next(this IngredientName name)
    {
        IngredientName[] values = (IngredientName[])Enum.GetValues(typeof(IngredientName)); //turn enum into array
        int index = Array.IndexOf(values, name); //find idx of ingredient in array
        int nextIndex = (index + 1) % values.Length; //get next idx (if at the end of the array, loop to the beginning)
        return values[nextIndex]; 
    }
}
public class Ingredient : MonoBehaviour
{
    public IngredientName name;
    private IngredientName counterName;
    public Drag ingredientDrag;
    
    void Start()
    {
        //the counter ingredient is the next one in the enum list
        //e.g. if name = Frog, counter = Bat
        counterName = name.Next(); 
    }

    void Update()
    {
        if (ingredientDrag.dragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + ingredientDrag.offset;
        }
    }
}
