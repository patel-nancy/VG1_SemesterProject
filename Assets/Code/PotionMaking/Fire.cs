using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float baseScale = 1.0f;
    public float maxScale = 2.0f;
    public float cappedDuration = 15.0f;
    private float delta = 5f;

    public float duration = 0f;
    private SpriteRenderer sr; // cache the sprite renderer

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sr.enabled = duration > 0;
        if (duration != 0 && duration < cappedDuration)
        {
            duration += Time.deltaTime;
            
            float t = Mathf.Clamp01(duration / cappedDuration);
            float scale = Mathf.Lerp(baseScale, maxScale, t);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public bool Equals(Fire other)
    {
        //if this duration is "close" to other duration
        if (Math.Abs(this.duration - other.duration) < delta)
        {
            return true;
        }

        return false;
    }
}