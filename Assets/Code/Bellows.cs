using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    public Drag bellowsDrag;
    public float stopYPosition = -10f;
   
    void Update()
    {
        if (bellowsDrag.dragging)
        {
            Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 currentPositionInWorld = transform.position;
            transform.position = new Vector3(currentPositionInWorld.x, mousePositionInWorld.y + bellowsDrag.offset.y, 0);
            
            //TODO: prevent from going too far down
        }
    }
}
