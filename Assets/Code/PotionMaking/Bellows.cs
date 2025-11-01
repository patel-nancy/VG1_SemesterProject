using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour
{
    public FireHold fireHold;

    private Vector2 offset;
    private float stopYPosition = -0f;

    public AudioSource audioSource;
    public AudioClip fireCrackleSound;

    

      void Start()
    {
        // auto get the AudioSource on this GameObject if not assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }



    private void OnMouseDrag()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPositionInWorld = transform.position;
        transform.position = new Vector2(currentPositionInWorld.x, Mathf.Max(mousePositionInWorld.y + offset.y, stopYPosition));
    }

    private void OnMouseDown()
    {

        Debug.Log("Bellows clicked");
         
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //sprite location - mouse location (in world)
        fireHold.fire.duration += Time.deltaTime;

        // play sound

          if (audioSource != null && fireCrackleSound != null)
        {
            audioSource.clip = fireCrackleSound;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or fireCrackleSound not set on Bellows.");
        }
    }

    void OnMouseUp()
    {
        // stop sound
        if (audioSource && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        //if rat hits bellows, then duration could be 0.
        //don't want to add that to actions list, so check
        if (fireHold.fire.duration != 0)
        {
            Debug.Log("Fire duration: " + fireHold.fire.duration);
            OrderSession.instance.AddAction(new FireAction(fireHold.fire));
            fireHold.fire = new Fire();
        }
    }

    //rat can trigger bellows if going up
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Rat rat = other.gameObject.GetComponent<Rat>();
    //     if (rat && rat.moveLeftOrUp)
    //     {
    //         OnMouseDown();
    //     }
    //     else if (rat && !rat.moveLeftOrUp)
    //     {
    //         OnMouseUp();
    //     }
    // }
}
