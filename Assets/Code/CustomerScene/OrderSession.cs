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
    
    //customer
    public string customerName;
    
    //recipes
    public static Dictionary<string, Recipe> recipe_cookbook = new Dictionary<string, Recipe> { 
        {
            "invisibility", 
            new Recipe(
                "invisibility", 
                new List<Action>
                {
                    new AddIngredientAction(new Ingredient(IngredientName.Bat)),
                    new StirCauldronAction(new Stir(-360f)),
                    new FireAction(new Fire(4f))
                }
            )
        },
        {
            "flying",
            new Recipe(
                "flying",
                new List<Action>
                {
                    new AddIngredientAction(new Ingredient(IngredientName.Bat)),
                    new AddIngredientAction(new Ingredient(IngredientName.Frog)),
                }
            )
        },
        {
            "liquid_luck",
            new Recipe(
                "liquid_luck",
                new List<Action>
                {
                    new AddIngredientAction(new Ingredient(IngredientName.Frog)),
                    new FireAction(new Fire(4f))
                }
            )
        }
    };
    
    public Recipe selectedRecipe; //the recipe the player picks
    public Recipe expectedRecipe; //the recipe we expect, based on the customer's dialogue
    
    //potion making
    public List<Action> currPlayerActions = new List<Action>();
    
    //tutorial + scoring
    public static bool isTutorial = true;
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
    
    //order = customer + recipe
    public void SetOrder(string customerName, Recipe recipe) {
        this.customerName = customerName;
        this.selectedRecipe = recipe;
    }
    
    public void PotionDone()
    {
        //finished tutorial
        if (isTutorial)
        {
            isTutorial = false;
        }
        
        //determines if the player chose the right recipe, given what the customer wanted (based on dialogue)
        if (selectedRecipe.Equals(expectedRecipe))
        {
            Debug.Log("Chose the RIGHT recipe for customer's problem!");
            
            //award points
            if (selectedRecipe.CheckRecipe(currPlayerActions))
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
        }
        else
        {
            Debug.Log("Chose the WRONG recipe for customer's problem!");
            score -= 10;
        }
        
        //determine if game over
        if (score < 0 || score >= 30)
        {
            SceneManager.LoadScene("GameOver");
        }
        else {
          currPlayerActions.Clear();
          SceneManager.LoadScene("CustomerScene");
        }
    }
}
