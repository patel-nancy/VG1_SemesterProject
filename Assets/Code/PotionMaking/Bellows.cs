using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    public FireHold fireHold;

    private Vector2 offset;
    private float stopYPosition = -0f;
    
    private void OnMouseDrag()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPositionInWorld = transform.position;
        transform.position = new Vector2(currentPositionInWorld.x, Mathf.Max(mousePositionInWorld.y + offset.y, stopYPosition));
    }
    
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //sprite location - mouse location (in world)
        fireHold.fire.duration += Time.deltaTime;
    }

    void OnMouseUp()
    {
        //if rat hits bellows, then duration could be 0.
        //don't want to add that to actions list, so check
        if(fireHold.fire.duration != 0)
        {
            Debug.Log("Fire duration: " + fireHold.fire.duration);
            OrderSession.instance.currPlayerActions.Add(new FireAction(fireHold.fire));
            fireHold.fire = new Fire();
        }
    }

    //rat can trigger bellows if going up
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Rat rat = other.gameObject.GetComponent<Rat>();
    //     if (rat && rat.moveLeftOrUp)
    //     {
    //         OnMouseDown();
    //     }
    //     else if (rat && !rat.moveLeftOrUp)
    //     {
    //         OnMouseUp();
    //     }
    // }
}
