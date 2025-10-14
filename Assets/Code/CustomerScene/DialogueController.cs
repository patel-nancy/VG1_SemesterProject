using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
    {
        [SerializeField] TMP_Text dialogueText;
        
        static List<string> invisibility_dialogues = new List<string>
        {
            "There's a dragon guarding some treasure...I need to slip past it!",
            "I want to listen to the president's secret meeting!"
        };

        static List<string> flying_dialogues = new List<string>
        {
            "My cat is stuck in tree!",
            "The stairs to my house collapsed...I need another way to get up!"
        };

        static List<string> liquid_luck_dialogues = new List<string>
        {
            "I have an exam tomorrow that I need to pass!",
            "I want to win the lottery today!"
        };
        
        static Dictionary<string, List<string>> potion_dialogues = new Dictionary<string, List<string>>
        {
            {"invisibility", invisibility_dialogues},
            {"flying", flying_dialogues},
            {"liquid_luck", liquid_luck_dialogues}
        };

        void Start()
        {
            if (!OrderSession.isTutorial)
            {
                // randomly chose which potion to make (e.g. "flying")
                //given the randomly chosen potion, randomly chose which dialogue the customer  (e.g. "My cat is stuck in a tree")
                KeyValuePair<string, List<string>> kvp =
                    potion_dialogues.ElementAt(Random.Range(0, potion_dialogues.Count));
                string recipe_name = kvp.Key;
                string potion_dialogue = kvp.Value[Random.Range(0, kvp.Value.Count)];
                
                dialogueText.text = potion_dialogue + " Make me a potion to do it!";
                OrderSession.instance.expectedRecipe = OrderSession.recipe_cookbook[recipe_name];
            }
        }
        
    }
