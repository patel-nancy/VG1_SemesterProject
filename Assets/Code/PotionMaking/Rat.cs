using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public bool knocksShelf;
    private float speed = 2f;
    private bool moveLeftOrUp = true;
    
    private Vector2 knockPosition = new Vector2(4, -1);
    private Vector2 bellowsPosition = new Vector2(-6.5f, -3);

    void Update()
    {
        Vector2 directionVector = knocksShelf ? Vector2.left : Vector2.up;
        float going = moveLeftOrUp ? 1 : -1;
        transform.Translate(directionVector * going * speed * Time.deltaTime);

        // reaches edge of shelf or top of bellows, then turns around
        if ((knocksShelf && transform.position.x < knockPosition.x) || (!knocksShelf && transform.position.y > bellowsPosition.y))
        {
            moveLeftOrUp = false;
        }

        // out of bounds -- destroy
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 10) 
        {
            Destroy(gameObject);
        }
    }

}
