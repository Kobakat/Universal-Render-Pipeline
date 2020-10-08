using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    public delegate void ContexualMessageTriggeredAction ();

    public static event ContexualMessageTriggeredAction ContextualMessageTriggered;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            ContextualMessageTriggered.Invoke();
        }
    }
}
