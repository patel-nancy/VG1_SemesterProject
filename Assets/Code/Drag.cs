using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Vector2 offset;
    public bool dragging = false;
    
    private void OnMouseDown()
    {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //ingredient location - mouse location (in world)
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
    
}
