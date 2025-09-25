using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAction : Action
{
    public Fire fire;

    public FireAction(Fire fire)
    {
        this.fire = fire;
    }
    
    public override string description()
    {
        return $"Fire on for: {fire.duration}";
    }
    
    public override bool Equals(Action action)
    {
        if (action is FireAction other)
        {
            return fire.Equals(other.fire);
        }
        return false;
    }
}