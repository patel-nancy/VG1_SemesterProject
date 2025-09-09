using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector2 offset;
    public bool dragging = false;
    
    void OnMouseDown()
    {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //ingredient location - mouse location (in world)
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    void OnMouseDrag()
    {
        if (gameObject.GetComponent<Ingredient>())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }
}
