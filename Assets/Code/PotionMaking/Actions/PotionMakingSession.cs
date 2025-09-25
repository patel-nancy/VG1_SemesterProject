using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PotionMakingSession : MonoBehaviour
{
   public Recipe currRecipe;
   public List<Action> currPlayerActions = new List<Action>();
   public List<float> playerScores = new List<float>();

   public GameObject ratPrefab;
   private float spawnInterval = 2f; //time btwn spawns
   
   private GameObject currRat;

   void Start()
   {
      //InvokeRepeating("Spawn", spawnInterval, spawnInterval);
   }

   void Spawn()
   {
      if (currRat == null)
      {
         if (Random.Range(0f, 1f) < 0.5f)
         {
            //shelf
            Vector2 position = new Vector2(10f, -1f);
            currRat = Instantiate(ratPrefab, position, Quaternion.identity);
            currRat.gameObject.GetComponent<Rat>().knocksShelf = true;

         }
         else
         {
            Vector2 position = new Vector2(-6.5f, -10f);
            currRat = Instantiate(ratPrefab, position, Quaternion.identity);
            currRat.gameObject.GetComponent<Rat>().knocksShelf = false;
         }
      }
   }

   public void PotionDone()
   {
      
      // List<Action> actions = new List<Action>();
      // Ingredient i1 = new Ingredient(IngredientName.Bat);
      // Ingredient i2 = new Ingredient(IngredientName.Frog);
      // actions.Add(new AddIngredientAction(i1));
      // actions.Add(new AddIngredientAction(i2));
      // Stir s1 = new Stir(360f);
      // actions.Add(new StirCauldronAction(s1));
      // Fire f1 = new Fire(3f);
      // actions.Add(new FireAction(f1));
      
      // currRecipe = new Recipe(
      //       "fly",
      //       "fly",
      //       actions
      //    );
      
      //check Recipe
      Debug.Log("Recipe Matches:" + currRecipe.CheckRecipe(currPlayerActions));
   }

}
