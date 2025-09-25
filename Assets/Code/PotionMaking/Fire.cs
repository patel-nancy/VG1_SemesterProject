using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire
{ 
    private float delta = 5f;
    public float duration; //TODO should make private with setters/getters

    public Fire()
    {
        this.duration = 0f;
    }

    public Fire(float duration)
    {
        this.duration = duration;
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