using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{    
    public GameObject bookUI;

    private void Start()
    {
        bookUI.GetComponent<RecipeBookUI>().Close();
    }

    private void OnMouseDown()
    {
        bookUI.GetComponent<RecipeBookUI>().Open();
    }
}
