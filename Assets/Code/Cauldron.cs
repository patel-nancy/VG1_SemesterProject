using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ingredient")) //TODO: do we want to do this by tag?
        {
            Destroy(other.gameObject);
        }
    }
}
