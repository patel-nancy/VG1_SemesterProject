using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    public Drag bellows;
    public float stopYPosition = -10f;
   
    void Update()
    {
        if (bellows.dragging)
        {
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 currentPositionInWorld = transform.position;
            transform.position = new Vector3(currentPositionInWorld.x, mousePositionInWorld.y, 0);
            
            //TODO: prevent from going too far down
        }
    }
}
