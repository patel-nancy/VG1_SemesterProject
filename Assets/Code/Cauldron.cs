using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public Transform cauldronCenter;
    public Drag spoonDrag;
    
    public List<IngredientName> ingredients = new List<IngredientName>();
    
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("collide with cauldron");
        Ingredient ingredient = other.GetComponent<Ingredient>();
        Drag ingredientDrag = other.GetComponent<Drag>();
        if (ingredient != null && ingredientDrag != null && !ingredientDrag.dragging)
        {
            ingredients.Add(ingredient.name);
            Debug.Log(ingredient.name);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if (spoonDrag.dragging)
        {
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 directionFromCauldronToMouse = mousePositionInWorld - transform.position;
        
            float radiansToMouse = Mathf.Atan2(directionFromCauldronToMouse.y, directionFromCauldronToMouse.x);
            float angleToMouse = radiansToMouse * Mathf.Rad2Deg;
        
            cauldronCenter.rotation = Quaternion.Euler(0, 0, angleToMouse);
        }
    }
    
}
