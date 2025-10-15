using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    void Start()
    {
        if (OrderSession.instance != null)
        {
            scoreText.text = "Game Over! Score: " + OrderSession.instance.score;
        }
    }

    public void RestartGame()
    {

         // find any customer profiles still loaded and randomize them
        foreach (CustomerProfile customer in FindObjectsOfType<CustomerProfile>())
        {
            customer.RandomizeProfile();
        }
        OrderSession.RestartSession();
    }
}
