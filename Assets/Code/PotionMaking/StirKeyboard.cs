using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StirKeyboard : MonoBehaviour
{
    private float rotationSpeed = 250f; //25 deg / sec
    
    private Stir stir;
    public Transform cauldronCenter;
    public PotionMakingSession session;

    private void Start()
    {
        stir = new Stir();
    }
    
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
            stir.rotations += deltaRotation;
        }

        //done stirring
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("Rotations: " + stir.rotations);
            session.currPlayerActions.Add(new StirCauldronAction(stir));

            stir = new Stir();
        }
    }
}
