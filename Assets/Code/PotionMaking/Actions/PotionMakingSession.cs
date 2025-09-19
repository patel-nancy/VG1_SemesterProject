using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakingSession : MonoBehaviour
{
   public Recipe recipe;
   public List<Action> playerActions = new List<Action>();

   public GameObject ratPrefab;
   private float spawnInterval = 2f; //time btwn spawns
   
   private GameObject currRat;

   void Start()
   {
      InvokeRepeating("Spawn", spawnInterval, spawnInterval);
   }

   void Spawn()
   {
      if (currRat == null)
      {
         if (Random.Range(0f, 1f) < 0.5f)
         {
            //shelf
            Debug.Log("Rat on Shelf");
            
            Vector2 position = new Vector2(10f, -1f);
            currRat = Instantiate(ratPrefab, position, Quaternion.identity);
            currRat.gameObject.GetComponent<Rat>().knocksShelf = true;

         }
         else
         {
            Debug.Log("Rat on Bellows");
            
            Vector2 position = new Vector2(-6.5f, -10f);
            currRat = Instantiate(ratPrefab, position, Quaternion.identity);
            currRat.gameObject.GetComponent<Rat>().knocksShelf = false;
         }
      }
     
   }

}
