using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHold : MonoBehaviour
{
    private float baseScale = 1.0f;
    private float maxScale = 2.0f;
    private float cappedDurationForFireScale = 10.0f; //duration is not capped (i.e. it can go >15s). but the scale of the fire stops increasing after 15s.
    
    public Fire fire;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        fire = new Fire();
    }

    void Update()
    {
        if (sr)
        {
            sr.enabled = fire.duration > 0;
            if (fire.duration > 0)
            {
                fire.duration -= Time.deltaTime;
            
                float t = Mathf.Clamp01(fire.duration / cappedDurationForFireScale);
                float scale = Mathf.Lerp(baseScale, maxScale, t);
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        else
        {
            sr = GetComponent<SpriteRenderer>();
        }
    }
}
