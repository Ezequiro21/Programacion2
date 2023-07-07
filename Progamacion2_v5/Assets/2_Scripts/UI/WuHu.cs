using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WuHu : MonoBehaviour
{
    public RectTransform rectTransform;
    public float velocidadDesplazamiento; // Declare the variable
    private Vector2 initialPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;
        PlayerControlller.OnDesplazamientoTerminado += ResetPosition;
    }

    void Update()
    {
        rectTransform.anchoredPosition += Vector2.left * velocidadDesplazamiento * Time.deltaTime;
    }
    void OnDestroy()
    {
        // Asegurarse de cancelar la suscripción al evento cuando se destruya el objeto
        PlayerControlller.OnDesplazamientoTerminado -= ResetPosition;
    }
    public void ResetPosition()
    {
        rectTransform.anchoredPosition = initialPosition;
    }
}
