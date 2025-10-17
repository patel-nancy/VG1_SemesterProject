using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirCauldronAction : Action
{
    public Stir stir;

    public StirCauldronAction(Stir stir)
    {
        this.stir = stir;
    }
    
    public override String description()
    {
        return $"Stir {stir.rotations} times";
    }

    public override bool Equals(Action action)
    {
        if (action is StirCauldronAction other)
        {
            return stir.Equals(other.stir);
        }
        return false;
    }
}

