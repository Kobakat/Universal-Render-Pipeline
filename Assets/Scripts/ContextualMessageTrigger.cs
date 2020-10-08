using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    public delegate void ContexualMessageTriggeredAction ();

    public static event ContexualMessageTriggeredAction ContextualMessageTriggered;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            if (ContextualMessageTriggered != null)
            {
                ContextualMessageTriggered.Invoke();               
            }


        }
    }
}
