using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        scoreText.text = "Score: " + OrderSession.instance.score;
    }
}
