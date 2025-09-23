using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stir : MonoBehaviour
{
    public float rotations;
    public bool clockwise;
    private float rotationSpeed = 250f; //25 deg / sec
    
    public Transform cauldronCenter;
    public PotionMakingSession session;

    private void Update()
    {
        float dir = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = 1f; //counterclockwise
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = -1f; //clockwise
        }

        if (dir != 0f)
        {
            float deltaRotation = dir * rotationSpeed * Time.deltaTime;
            cauldronCenter.Rotate(0, 0, deltaRotation);
            rotations += deltaRotation;
        }

        //done stirring
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("Rotations: " + rotations);
            clockwise = rotations < 0; // negative = cc
            session.playerActions.Add(new StirCauldronAction(this));

            rotations = 0;
        }
    }
}
