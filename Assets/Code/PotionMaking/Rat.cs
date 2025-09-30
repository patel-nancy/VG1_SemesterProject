using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    // private Vector2 shelfExitPosition = new Vector2(10, 3);
    // private float speed = 8f;
    // private Collider2D ratCollider;
    // private Rigidbody2D ratBody;
    //
    // private Vector2 knockPosition = new Vector2(4, -1);
    // // private Vector2 bellowsPosition = new Vector2(-6.5f, -3);
    //
    // private enum RatState { Idle, KnockingIngredient, KnockingBellows, ExitingIngredient, ExitingBellows }
    // private RatState state = RatState.Idle;
    //
    // private GameObject targetIngredient;
    //
    // void Awake()
    // {
    //     ratBody = GetComponent<Rigidbody2D>();
    //     ratCollider = GetComponent<Collider2D>();
    //     IngredientDrag[] allIngredients = FindObjectsOfType<IngredientDrag>();
    //     foreach (IngredientDrag ingredient in allIngredients)
    //     {
    //         Collider2D ingredientCollider = ingredient.GetComponent<Collider2D>();
    //         Physics2D.IgnoreCollision(ratCollider, ingredientCollider, true);
    //     }
    // }
    //
    // public void SetTarget(GameObject ingredient)
    // {
    //     state = RatState.KnockingIngredient;
    //     targetIngredient = ingredient;
    //     Collider2D ingredientCollider = ingredient.GetComponent<Collider2D>();
    //     Physics2D.IgnoreCollision(ratCollider, ingredientCollider, false); // no longer ignore collision for the set ingredient
    // }
    //
    // void Update()
    // {
    //     // to-do: states for knocking bellows, exiting bellows
    //     // to-do: extra animations for knocking (for example: rat uses tail to fling the ingredient down, or bumps it with head to fling it down)
    //     if (state == RatState.KnockingIngredient)
    //     {
    //         // MoveToTarget(targetIngredient.transform.position);
    //         MoveToTarget(knockPosition, Vector2.right, RatState.ExitingIngredient);
    //     } else if (state == RatState.ExitingIngredient)
    //     {
    //         MoveToTarget(shelfExitPosition, Vector2.right, RatState.Idle);
    //     }
    // }
    //
    // void MoveToTarget(Vector2 targetPos, Vector2 axis, RatState reached)
    // {
    //     Vector2 currentPos = transform.position;
    //
    //     Vector2 offset = targetPos - currentPos;
    //     float distance = Vector2.Dot(offset, axis);
    //     if (Mathf.Abs(distance) <= 1.0f)
    //     {
    //         state = reached;
    //         return;
    //     }
    //     Vector2 direction = axis * Mathf.Sign(distance);
    //     ratBody.MovePosition(currentPos + direction * speed * Time.deltaTime);
    // }
}
