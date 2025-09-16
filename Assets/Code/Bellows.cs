using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    private Vector2 offset;
    private float stopYPosition = -0.5f;

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //sprite location - mouse location (in world)
    }

    private void OnMouseDrag()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPositionInWorld = transform.position;
        transform.position = new Vector2(currentPositionInWorld.x, Mathf.Max(mousePositionInWorld.y + offset.y, stopYPosition));
    }
}
