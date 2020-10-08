using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    CanvasGroup canvasGroup = null;
    TMP_Text messageText = null;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;
    }

    void ShowMessage(string message, float duration)
    {
        messageText.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
