using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public abstract String description();
    public abstract bool Equals(Action other);
    //TODO: override hashcode for best practice
}