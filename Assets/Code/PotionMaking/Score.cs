using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
   public TMP_Text scoreText;
   
   public float maxScore = 10f;
   public float minScore = 0f;
   
   private float score = 0;
   
   //public List<float> playerScores = new List<float>();

   private void Start()
   {
      UpdateScoreText();
   }

   public void AddScore(float amount)
   {
      //playerScores.Add(amount);
      score += amount;
      UpdateScoreText();
   }
   
   private void UpdateScoreText()
   {
      scoreText.text = "Score: " + Math.Round(score, 2);
   }
}
