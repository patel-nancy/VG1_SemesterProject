using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;

    void Start()
    { }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            //move ingredient
            this.transform.position = mousePositionInWorld;
           
        }

        if (Input.GetMouseButtonUp(0))
        {
            //leave ingredient there?
        }
    }
    
}
