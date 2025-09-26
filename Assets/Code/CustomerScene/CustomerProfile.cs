using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerProfile : MonoBehaviour
{
    public string customerName;
    static readonly string[] Names = { "Agnes", "Mary", "Thomas", "John", "Martha" };

    void Awake()
    {
        customerName = Names[Random.Range(0, Names.Length)];
        Debug.Log($"[CustomerProfile] Assigned customerName = {customerName}");
    }
}
