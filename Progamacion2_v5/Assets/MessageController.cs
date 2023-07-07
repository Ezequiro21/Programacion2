using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageController : MonoBehaviour
{
    public TMP_Text messageText;
    public float displayDuration = 2f;
    public float moveSpeed = 100f;

    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private float displayTimer;
    private bool isDisplaying = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.localPosition;
        HideMessage();
    }

    private void Update()
    {
        if (isDisplaying)
        {
            displayTimer -= Time.deltaTime;

            if (displayTimer <= 0f)
            {
                HideMessage();
            }
            else
            {
                MoveMessageUp();
            }
        }
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        rectTransform.localPosition = originalPosition;
        displayTimer = displayDuration;
        isDisplaying = true;
        gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        isDisplaying = false;
        gameObject.SetActive(false);
    }

    private void MoveMessageUp()
    {
        rectTransform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
