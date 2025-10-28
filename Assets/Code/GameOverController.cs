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
        OrderSession.RestartSession(); //TODO: if gameOver, the next time the player plays, it doesn't switch the customer
    }
}
