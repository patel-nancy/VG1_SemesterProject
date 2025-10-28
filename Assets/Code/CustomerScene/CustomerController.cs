using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CustomerController : MonoBehaviour
{
    public static CustomerController instance;
    
    readonly string[] names = { "Agnes", "Mary", "Thomas", "John", "Martha" };
    [SerializeField] TMP_Text dialogueText;
    public GameObject[] prefabs;
    
    void Start()
    {
        /*
         * S1 = Customer Scene
         * S2 = Potion Making Scene
         * 
         * Cases:
         *  1. (Tutorial)
         *      Paths:
         *          -start -> tutorial mode (S1).
         *          -potion made -> tutorial scoring (S2 -> S1)
         *      What should happen: don't do anything. taken care of by CustomerSceneTutorialController.
         *  3. (Normal) scoring of prev customer -> take new customer's order
         *  4. (Normal) potion made -> see customer's score
         */
        
        instance = this;

        //tutorial
        if (OrderSession.isTutorial)
        {
            //customer is ordering -- don't have to do anything bc CustomerSceneTutorialController takes care of it
        }
        else
        {
            Customer c = OrderSession.instance.customer;
            
            //customer ordering
            if (!OrderSession.isCustomerScoring)
            {
                //no customer exists, make one
                if (c == null)
                {
                    GenerateAndSetCustomer();
                }
            }
            //customer scoring
            else
            {
                //ensure same prefab
                if (c != null)
                {
                    dialogueText.text = "Are you done with my potion?";
                    SetActivePrefab(c.prefab_idx);
                }
            }
        }
    }
    
    public void CustomerCheckPotion(float potionScore)
    {
        string text;
        
        if (potionScore < OrderSession.instance.MAX_SCORE * 1f/3f)
        {
            //BAD
            text = "This was AWFUL!";
        }
        else if (potionScore < OrderSession.instance.MAX_SCORE * 2f / 3f)
        {
            //MEDIUM
            text = "This was MEH!";
        }
        else
        {
            //GOOD
            text = "This was AMAZING!";
        }

        text += " I give it a " + potionScore;
        dialogueText.text = text;

        OrderSession.isCustomerScoring = false;

    }

    public void SetActivePrefab(int index)
    {
        foreach (GameObject p in prefabs)
        {
            p.SetActive(false);
        }
        
        prefabs[index].SetActive(true);
    }

    public void GenerateAndSetCustomer()
    {
        Customer c = GenerateCustomer();
        SetCustomer(c);
    }
    
    public void SetCustomer(Customer c)
    {
        SetActivePrefab(c.prefab_idx);
        dialogueText.text = c.dialogue;
        OrderSession.instance.customer = c;
    }
    
    public Customer GenerateCustomer()
    {
        //1. randomly choose name
        string name = names[Random.Range(0, names.Length)];
        
        //2. randomly chose which potion to make (e.g. "flying")
        //given the randomly chosen potion, randomly chose which dialogue the customer  (e.g. "My cat is stuck in a tree")
        Dictionary<string, List<string>> dialogues = OrderSession.instance.dialogues;
        KeyValuePair<string, List<string>> kvp = 
            dialogues.ElementAt(Random.Range(0, dialogues.Count));
        
        string recipe_name = kvp.Key;
        OrderSession.instance.expectedRecipe = OrderSession.instance.recipe_cookbook[recipe_name]; //expected recipe changes, based on dialogue
        
        string potion_dialogue = kvp.Value[Random.Range(0, kvp.Value.Count)];
        string dialogue = potion_dialogue + " Make me a potion to do it!";
        
        //3. randomly choose prefab_idx
        int prefab_idx = Random.Range(0, prefabs.Length);
        
        return new Customer(name, dialogue, prefab_idx);
    }

}
