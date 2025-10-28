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
    public GameObject potionPanelCanvas;
    public GameObject scoringDialogueCanvas;
    public GameObject newCustomerCanvas;
    
    [SerializeField] TMP_Text dialogueText;
    
    void Start()
    {
        instance = this;
        if (OrderSession.isTutorial)
        {
            //customer ordering
            if (!OrderSession.isCustomerScoring)
            {    
                tutorialCanvas.SetActive(true);
                ResetCanvases();
                StartCoroutine("OrderTutorial");
            }
            else
            {
                tutorialCanvas.SetActive(true);
                ResetCanvases();
                StartCoroutine("ScoreTutorial");
            }
        }
        else
        {
            tutorialCanvas.SetActive(false);
        }
    }

    public void ResetCanvases()
    {
        customerCanvas.SetActive(false);
        dialogueCanvas.SetActive(false);
        recipeOptionsCanvas.SetActive(false);
        repromptCanvas.SetActive(false);
        potionPanelCanvas.SetActive(false);
        scoringDialogueCanvas.SetActive(false);
        newCustomerCanvas.SetActive(false);
    }
    
    public void Reprompt()
    {
        StartCoroutine("TutorialReprompt");
    }
    
    private IEnumerator TutorialReprompt()
    {
        repromptCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); //TODO: check this...should be space
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        repromptCanvas.SetActive(false);
    }

    IEnumerator OrderTutorial()
    {
        //tutorial mode:
        //do the invisibility recipe so that they can try all three types of actions (add ingredient, stir, fire)
        OrderSession.instance.expectedRecipe = OrderSession.instance.recipe_cookbook["invisibility"];
        OrderSession.instance.customer = new Customer("Mary",
            "I want to listen to the president's secret meeting! Make me a potion to do it!", 0);
        
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

    IEnumerator ScoreTutorial()
    {
        dialogueText.text = "Are you done with my potion?";
        potionPanelCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        potionPanelCanvas.SetActive(false);
        
        scoringDialogueCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        scoringDialogueCanvas.SetActive(false);
        
        newCustomerCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        newCustomerCanvas.SetActive(false);
        
        //finished tutorial
        if (OrderSession.isTutorial)
        {
            OrderSession.isTutorial = false;
        }
    }
}
