using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public bool lit = false;   // whether the fire is on
    private SpriteRenderer sr; // cache the sprite renderer

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = lit;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lit = !lit;
            sr.enabled = lit;
        }
    }
}