using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotionMakingSession : MonoBehaviour
{
   public Recipe currRecipe;
   public List<Action> currPlayerActions = new List<Action>();

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
         Vector2 position = new Vector2(10f, -1f);
         currRat = Instantiate(ratPrefab, position, Quaternion.identity);
         IngredientDrag[] allIngredients = FindObjectsOfType<IngredientDrag>();
         Debug.Log("spawning rat " + allIngredients.Length);
         if (allIngredients.Length > 0)
         {
            IngredientDrag randomIngredient = allIngredients[Random.Range(0, allIngredients.Length)];

            Rat ratScript = currRat.GetComponent<Rat>();
            ratScript.SetTarget(randomIngredient.gameObject);
         }
      }
   }

   public void PotionDone()
   {
      
      List<Action> actions = new List<Action>();
      Ingredient i1 = new Ingredient(IngredientName.Bat);
      Ingredient i2 = new Ingredient(IngredientName.Frog);
      actions.Add(new AddIngredientAction(i1));
      actions.Add(new AddIngredientAction(i2));
      // Stir s1 = new Stir(360f);
      // actions.Add(new StirCauldronAction(s1));
      // Fire f1 = new Fire(3f);
      // actions.Add(new FireAction(f1));
      
       currRecipe = new Recipe(
             "fly",
             "fly",
             actions
          );
      
       Score score = gameObject.GetComponent<Score>();
       
       //check Recipe
       if (currRecipe.CheckRecipe(currPlayerActions))
       {
          Debug.Log("Recipe DOES Match");
          score.AddScore(score.maxScore);
          
       }
       else
       {
          Debug.Log("Recipe DOES NOT Match");
          score.AddScore(score.minScore);
          
       }
       
       //TODO: go back to customer scene
       SceneManager.LoadScene("CustomerScene");
   }

}
