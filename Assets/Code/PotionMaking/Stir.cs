using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stir : MonoBehaviour
{
    public bool clockwise;
    public float rotations;
    private float lastAngle;
    
    public Transform cauldronCenter;
    public PotionMakingSession session;

    private void OnMouseDrag()
    {
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionFromCauldronToMouse = mousePositionInWorld - cauldronCenter.position;
        
        float currAngle = Mathf.Atan2(directionFromCauldronToMouse.y, directionFromCauldronToMouse.x) * Mathf.Rad2Deg;
        
        //total rotation
        rotations += Mathf.DeltaAngle(lastAngle, currAngle);
        lastAngle = currAngle;
        
        cauldronCenter.rotation = Quaternion.Euler(0, 0, currAngle);
    }

    void OnMouseUp()
    {
        Debug.Log("Rotations: " + rotations);
        Debug.Log("Last Angle: " + lastAngle);
        //TODO: determine if clockwise or counterclockwise
        session.playerActions.Add(new StirCauldronAction(this));
        
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionFromCauldronToMouse = mousePositionInWorld - cauldronCenter.position;
        
        rotations = 0;
        lastAngle = Mathf.Atan2(directionFromCauldronToMouse.y, directionFromCauldronToMouse.x);
    }
}
