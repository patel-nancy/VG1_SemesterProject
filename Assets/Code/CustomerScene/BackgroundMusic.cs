using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script to play the background music when the game starts
public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundClip;   
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component automatically if not present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // setting  the AudioSource and volume settings
        audioSource.clip = backgroundClip;
        audioSource.loop = true;       
        audioSource.playOnAwake = true;
        audioSource.volume = 0.7f;     
        audioSource.Play();      
        DontDestroyOnLoad(gameObject);
    }
}
