using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientName { Frog, Bat, Eye }
public class Ingredient : MonoBehaviour
{
    private Vector2 offset;
    private bool dragging = false;
    public IngredientName name;
    
    void OnMouseDown()
    {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //ingredient location - mouse location (in world)
    }

    void OnMouseDrag()
    {
        if (dragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseUp()
    {
        dragging = false;
    }
}
