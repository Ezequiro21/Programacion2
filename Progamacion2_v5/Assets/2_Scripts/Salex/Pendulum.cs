using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Transform pivot; // Transform del punto de pivote
    public float length = 5f; // Longitud del péndulo
    public float angle = 45f; // Ángulo inicial del péndulo en grados
    public float gravity = 9.8f; // Gravedad aplicada al péndulo

    private float angularVelocity; // Velocidad angular del péndulo
    private float currentAngle; // Ángulo actual del péndulo en radianes

    private void Start()
    {
        // Convertir el ángulo inicial de grados a radianes
        currentAngle = angle * Mathf.Deg2Rad;
        // Calcular la velocidad angular inicial
        angularVelocity = 0f;
    }

    private void Update()
    {
        // Calcular el cambio de tiempo
        float deltaTime = Time.deltaTime;

        // Calcular la aceleración angular utilizando la fórmula del péndulo simple
        float acceleration = -gravity / length * Mathf.Sin(currentAngle);

        // Actualizar la velocidad angular utilizando la aceleración y el cambio de tiempo
        angularVelocity += acceleration * deltaTime;

        // Actualizar el ángulo utilizando la velocidad angular y el cambio de tiempo
        currentAngle += angularVelocity * deltaTime;

        // Calcular la posición del peso del péndulo en coordenadas polares
        float x = length * Mathf.Sin(currentAngle);
        float y = -length * Mathf.Cos(currentAngle);

        // Obtener la dirección del péndulo
        Vector3 direction = new Vector3(x, y, 0f).normalized;

        // Calcular la posición del peso del péndulo relativa al punto de pivote
        Vector3 position = direction * length;

        // Actualizar la posición del peso del péndulo relativa al punto de pivote
        transform.position = pivot.position + position;
    }
}