using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    public BoxCollider2D targetTrigger;
    public Fire fire;

    private Vector2 offset;
    private float stopYPosition = -0f;

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

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other == targetTrigger) {
    //         fire.duration += 5;
    //     }
    // }

    private void OnTriggerStay2D(Collider2D other) {
        if (other == targetTrigger) {
            fire.duration += Time.deltaTime * 3;
        }
    }
}
