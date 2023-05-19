using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] powerUpPrefabs; // Array de prefabs de power-ups
    public Transform spawnPoint; // Punto de aparición de los power-ups

    private bool isOpened = false; // Indica si el cofre ha sido abierto

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que interactúa con el cofre es el jugador
        if (other.CompareTag("Player") && !isOpened)
        {
            Debug.Log("se abrio");
            // Generar un power-up aleatorio
            GenerateRandomPowerUp();

            // Marcar el cofre como abierto
            isOpened = true;

            // Desactivar el colisionador del cofre para evitar que se abra varias veces
            GetComponent<Collider>().enabled = false;
        }
    }

    private void GenerateRandomPowerUp()
    {
        // Verificar si hay power-ups en el array
        if (powerUpPrefabs.Length > 0)
        {
            // Seleccionar un índice aleatorio dentro del rango del array de power-ups
            int randomIndex = Random.Range(0, powerUpPrefabs.Length);

            // Instanciar el power-up en el punto de aparición
            Instantiate(powerUpPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
        }
    }
}

