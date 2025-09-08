using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            //move ingredient to where mouse is
            this.transform.position = mousePositionInWorld;
        }
    }
}
