﻿using System.Collections;
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

        StartCoroutine(ShowMessage("Test", 2));
    }

    IEnumerator ShowMessage(string message, float duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;

        yield return new WaitForSeconds(duration);
        canvasGroup.alpha = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}