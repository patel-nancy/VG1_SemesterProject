using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerSceneTutorialController : MonoBehaviour
{
    public static CustomerSceneTutorialController instance;
    
    public GameObject tutorialCanvas;
    public GameObject customerCanvas;
    public GameObject dialogueCanvas;
    public GameObject recipeOptionsCanvas;
    public GameObject repromptCanvas;
    
    [SerializeField] TMP_Text dialogueText;
    
    void Start()
    {
        instance = this;
        if (OrderSession.isTutorial)
        {
            tutorialCanvas.SetActive(true);
            
            //reset all canvases
            customerCanvas.SetActive(false);
            dialogueCanvas.SetActive(false);
            recipeOptionsCanvas.SetActive(false);
            repromptCanvas.SetActive(false);
            
            StartCoroutine("Tutorial");
        }
        else
        {
            tutorialCanvas.SetActive(false);
        }
    }

    public void Reprompt()
    {
        StartCoroutine("TutorialReprompt");
    }
    
    private IEnumerator TutorialReprompt()
    {
        repromptCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        repromptCanvas.SetActive(false);
    }

    IEnumerator Tutorial()
    {
        //tutorial mode:
        //do the invisibility recipe so that they can try all three types of actions (add ingredient, stir, fire)
        OrderSession.instance.expectedRecipe = OrderSession.recipe_cookbook["invisibility"];
        
        //highlight customer
        customerCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        customerCanvas.SetActive(false);
        
        //highlight customer dialogue
        dialogueText.text = "I want to listen to the president's secret meeting! Make me a potion to do it!";
        dialogueCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        dialogueCanvas.SetActive(false);
        
        //let player decide what potion to make
        recipeOptionsCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        recipeOptionsCanvas.SetActive(false);
    }
}
