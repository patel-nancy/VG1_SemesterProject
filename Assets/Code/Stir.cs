using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stir : MonoBehaviour
{
    public bool clockwise;
    public float rotations;
    
    public Transform cauldronCenter;

    private void OnMouseDrag()
    {
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionFromCauldronToMouse = mousePositionInWorld - cauldronCenter.position;
        
        float radiansToMouse = Mathf.Atan2(directionFromCauldronToMouse.y, directionFromCauldronToMouse.x);
        float angleToMouse = radiansToMouse * Mathf.Rad2Deg;
        
        cauldronCenter.rotation = Quaternion.Euler(0, 0, angleToMouse);
    }
}
