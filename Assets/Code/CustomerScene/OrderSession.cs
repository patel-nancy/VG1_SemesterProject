using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderSession : MonoBehaviour
{
    //WTS: current customer, recipe, + player actions. handle rat moving.
    //     keep track of score.
    //     should be available to all classes
    public static OrderSession instance;
    
    //order 
    public string customerName;
    public Recipe currRecipe;
    
    //potion making
    public List<Action> currPlayerActions = new List<Action>();
    
    //scoring
    public float score;

    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
        
    }

    void Start()
    {
        score = 0;
        instance = this; //do i need this?
    }

    public static void RestartSession()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = null;
        }

        GameObject newSession = new GameObject("OrderSession");
        instance = newSession.AddComponent<OrderSession>();
        SceneManager.LoadScene("CustomerScene");
    }
    
    public void SetOrder(string customerName, Recipe recipe) {
        this.customerName = customerName;
        this.currRecipe = recipe;
    }
    
    public void PotionDone()
    {
        if (currRecipe.CheckRecipe(currPlayerActions))
        {
            //recipe matches
            Debug.Log("Recipe matches!");
            score += 10;
        }
        else
        {
            Debug.Log("Recipe DOES NOT match!");
            score -= 10;
        }
        if (score < 0 || score >= 30)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
