using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    public float speedrotation;
    public float clampAngle = 80f; // Límite de ángulo vertical

    private float verticalRotation = 0f;

    void Start()
    {
        // Guardar la rotación inicial del jugador para usarla como referencia
        Vector3 rotation = player.localRotation.eulerAngles;
        verticalRotation = rotation.x;
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Rotar el jugador horizontalmente
            player.Rotate(Vector3.up * mouseX * speedrotation);

            // Rotar la cámara verticalmente
            verticalRotation -= mouseY * speedrotation;
            verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

            // Aplicar la rotación vertical a la cámara
            transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }
}