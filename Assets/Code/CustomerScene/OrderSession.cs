using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderSession : MonoBehaviour
{
    //WTS: current customer, recipe, + player actions. handle rat moving.
    //     keep track of score.
    //     should be available to all classes
    public static OrderSession instance;
    
    //customer
    public Customer customer;
    
    //dialogues
    public Dictionary<string, List<string>> dialogues = new Dictionary<string, List<string>>
    {
        {
            "invisibility",
            new List<string>
            {
                "There's a dragon guarding some treasure...I need to slip past it!",
                "I want to listen to the president's secret meeting!"
            }
        },
        {
            "flying",
            new List<string>
            {
                "My cat is stuck in tree!",
                "The stairs to my house collapsed...I need another way to get up!"
            }
        },
        {
            "liquid_luck",
            new List<string>
            {
                "I have an exam tomorrow that I need to pass!",
                "I want to win the lottery today!"
            }
        }
    };
    
    //recipes
    public Dictionary<string, Recipe> recipe_cookbook = new Dictionary<string, Recipe> { 
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
    public List<Potion> completedPotions = new List<Potion>();
    
    //tutorial / scene trakcing
    public static bool isTutorial = true;
    public static bool isCustomerScoring = false; //true when on scene 1 and player is finished w potion
    
    //scoring
    public float score;
    public float currPotionScore;
    public float MAX_SCORE = 10;
    public float WIN_SCORE = 30;
    
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
        instance = this;
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
    
    public void SetRecipe(Recipe recipe) {
        // this.customerName = customerName;
        this.selectedRecipe = recipe;
    }
    

    public void SubmitPotion()
    {
        Potion p = new Potion(currPlayerActions, selectedRecipe);
        completedPotions.Add(p);

        currPotionScore = p.score(expectedRecipe);
        score += currPotionScore;
        
        // determine if game over
         if (score < 0 || score >= WIN_SCORE)
         {
             SceneManager.LoadScene("GameOver");
         }
         else
         {
             isCustomerScoring = true;
             currPlayerActions.Clear();
               
             SceneManager.LoadScene("CustomerScene");
         }
    }

    public void AddAction(Action a)
    {
        if (currPlayerActions.Count > 0) {
            //condense if last two actions are the same
            Action last = currPlayerActions[currPlayerActions.Count-1];
            if (a is FireAction afire && last is FireAction lastfire) {
                lastfire.fire.duration += afire.fire.duration;
                return;
            } else if (a is StirCauldronAction astir && last is StirCauldronAction laststir) {
                laststir.stir.rotations += astir.stir.rotations;
                return;
            }
            //remove last ingredient because the counteringred placed in
            else if (a is AddIngredientAction aingred && last is AddIngredientAction lastingred && lastingred.ingredient.counterName == aingred.ingredient.name)
            {
                currPlayerActions.RemoveAt(currPlayerActions.Count - 1);
                return;
            }
        }
        currPlayerActions.Add(a);
    }
}
