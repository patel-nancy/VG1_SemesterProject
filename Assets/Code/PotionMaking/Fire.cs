using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public bool lit = false;   // whether the fire is on
    private SpriteRenderer sr; // cache the sprite renderer
    public float duration = 0f;
    public PotionMakingSession session;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = lit;
    }

    void Update()
    {
        if (lit)
        {
            duration += Time.deltaTime;
        }
       
        if (Input.GetKeyDown(KeyCode.F))
        {
            lit = !lit;
            sr.enabled = lit;

            if (!lit)
            {
                session.playerActions.Add(new FireAction(this));
                Debug.Log(duration);
                duration = 0f;
                
            }
        }
    }
}