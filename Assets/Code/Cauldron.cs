using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public Transform cauldronCenter;
    public Drag spoonDrag;
    
    public List<IngredientName> ingredients = new List<IngredientName>();
    
    void OnCollisionEnter2D(Collision2D other)
    {

        Ingredient ingredient = other.gameObject.GetComponent<Ingredient>();
        Drag drag = other.gameObject.GetComponent<Drag>();
        
        if (ingredient && drag && !drag.dragging)
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
