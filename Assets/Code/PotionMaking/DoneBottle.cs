using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneBottle : MonoBehaviour
{
    private Vector2 offset;
    public PotionMakingSession session;
    
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + offset; 
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Cauldron>())
        {
            Debug.Log("potion done");
            Destroy(this.gameObject);
            
            session.PotionDone(); //TODO: potion success
        }
    }
}
