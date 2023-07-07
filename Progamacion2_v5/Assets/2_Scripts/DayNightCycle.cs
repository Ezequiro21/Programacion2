using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Transform sunTransform;          // Referencia al objeto que representa el sol
    public Light sunLight;                  // Referencia a la luz del sol
    public float dayDurationInMinutes = 24f; // Duración del día en minutos

    private float rotationSpeed;             // Velocidad de rotación del sol en grados por segundo
    private float timeCounter;               // Contador de tiempo en minutos

    private void Start()
    {
        // Calcula la velocidad de rotación del sol en función de la duración del día
        rotationSpeed = 360f / (dayDurationInMinutes * 60f);
    }

    private void Update()
    {
        // Actualiza el contador de tiempo
        timeCounter += Time.deltaTime;

        // Calcula el ángulo de rotación del sol en función del tiempo transcurrido
        float sunRotationAngle = timeCounter * rotationSpeed;

        // Calcula la posición del sol en función del ángulo de rotación
        Vector3 sunPosition = Quaternion.Euler(sunRotationAngle, 0f, 0f) * Vector3.forward;

        // Actualiza la posición del sol
        sunTransform.position = sunPosition;

        // Ajusta la rotación del sol para que siempre mire al centro de la escena (opcional)
        sunTransform.LookAt(Vector3.zero);

        // Ajusta la intensidad de la luz del sol en función de la altura del sol
        sunLight.intensity = Mathf.Clamp01(1f - sunTransform.forward.y);
    }
}