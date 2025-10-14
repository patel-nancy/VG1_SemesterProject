using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakingTutorialController : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public GameObject addIngredientCanvas;
    public GameObject stirCanvas;
    public GameObject fireCanvas;
    public GameObject doneCanvas;

    void Start()
    {
        if (OrderSession.isTutorial)
        {
            tutorialCanvas.SetActive(true);
            
            //reset all canvases
            addIngredientCanvas.SetActive(false);
            stirCanvas.SetActive(false);
            fireCanvas.SetActive(false);
            doneCanvas.SetActive(false);
            
            StartCoroutine("Tutorial");
        }
        else
        {
            tutorialCanvas.SetActive(false);
        }
    }
    
    IEnumerator Tutorial()
    {
        //tutorial mode:
        //do the invisibility recipe so that they can try all three types of actions (add ingredient, stir, fire)

        //highlight step 1: add ingredient
        addIngredientCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        addIngredientCanvas.SetActive(false);
        
        //highlight step 2: stir pot
        stirCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        stirCanvas.SetActive(false);
        
        //highlight step 3: fire
        fireCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        fireCanvas.SetActive(false);
        
        //highlight step 4: bottle potion
        doneCanvas.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        doneCanvas.SetActive(false);
    }
}
