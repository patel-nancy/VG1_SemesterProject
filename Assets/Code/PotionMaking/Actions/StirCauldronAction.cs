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
        return $"Stirred clockwise: {stir.clockwise}, Rotations: {stir.rotations}";
    }
}

