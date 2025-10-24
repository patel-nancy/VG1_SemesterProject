using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBottle : MonoBehaviour
{
    public Potion potion;
    private Vector2 offset;
    
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
        Debug.Log("wow collision\n");
        if (other.gameObject.GetComponent<CustomerProfile>())
        {
            Destroy(this.gameObject);
            
            OrderSession.instance.CompletePotion();
        }
    }
}
