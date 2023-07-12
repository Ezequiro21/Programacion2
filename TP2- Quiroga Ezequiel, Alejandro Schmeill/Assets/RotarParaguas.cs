using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarParaguas : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación en grados por segundo
    public GameObject UIUmbrella;
    
    void Start()
    {
        UIUmbrella.SetActive(true);
    }

    void Update()
    {
        // Obtener el componente Transform de la sombrilla de playa
        Transform umbrellaTransform = GetComponent<Transform>();

        // Girar la sombrilla de playa alrededor de su eje central
        umbrellaTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
