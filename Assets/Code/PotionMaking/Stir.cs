using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stir 
{
    private float delta = 10f;
    public float rotations; // if negative, moving clockwise

    public Stir()
    {
        this.rotations = 0;
    }

    public Stir(float rotations)
    {
        this.rotations = rotations;
    }
    
    public bool Equals(Stir other)
    {
        //if same direction and within ten degrees of expected rotation
        if (Math.Abs(this.rotations - other.rotations) <= delta)
        {
            return true;
        }

        return false;
    }
}
