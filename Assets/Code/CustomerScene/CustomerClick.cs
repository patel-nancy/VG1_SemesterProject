using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerClick : MonoBehaviour
{
    void OnMouseDown()
    {
        //TODO: only allow customer to change once
        
        //ready for new customer to order
        if (!OrderSession.isTutorial && !OrderSession.isCustomerScoring)
        {
            CustomerController.instance.GenerateAndSetCustomer();
        }
    }
}
