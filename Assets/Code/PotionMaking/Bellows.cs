using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    public Fire fire;

    private Vector2 offset;
    private float stopYPosition = -0f;
    public PotionMakingSession session;

    private void OnMouseDrag()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPositionInWorld = transform.position;
        transform.position = new Vector2(currentPositionInWorld.x, Mathf.Max(mousePositionInWorld.y + offset.y, stopYPosition));
    }
    
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //sprite location - mouse location (in world)
        
        fire.duration += Time.deltaTime;
        if (fire.duration > fire.cappedDuration)
        {
            Debug.Log("Fire duration: " + fire.duration);
            session.playerActions.Add(new FireAction(fire));
            fire.duration = 0;
        }
    }

    void OnMouseUp()
    {
        //leaves trigger AND wasn't just turned off because it reached cappedDuration
        if (fire.duration != 0)
        {
            Debug.Log("Fire duration: " + fire.duration);
            fire.duration = 0;
            session.playerActions.Add(new FireAction(fire));
        }
    }
}
