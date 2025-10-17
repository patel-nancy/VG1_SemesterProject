using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBag : MonoBehaviour
{
    public GameObject ingredientPrefab;
    private GameObject currentIngredient;

    private void OnMouseDown()
    {
        // spawn new ingredient
        Debug.Log("mouse down on ingredient bag");
        currentIngredient = Instantiate(ingredientPrefab, transform.position, Quaternion.identity);
        currentIngredient.GetComponent<IngredientDrag>().dragging = true;
    }

    private void OnMouseDrag()
    {
        if (currentIngredient != null)
        {
            // move with mouse
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;
            currentIngredient.transform.position = worldPos;
        }
    }

    private void OnMouseUp()
    {
        currentIngredient.GetComponent<IngredientDrag>().dragging = false;
        currentIngredient = null;
    }
}
