using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    public Drag bellowsDrag;
    private float stopYPosition = -1.0f;
   
    void Update()
    {
        if (bellowsDrag.dragging)
        {
            Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 currentPositionInWorld = transform.position;
            transform.position = new Vector2(currentPositionInWorld.x, Mathf.Max(mousePositionInWorld.y + bellowsDrag.offset.y, stopYPosition));
        }
    }
}
