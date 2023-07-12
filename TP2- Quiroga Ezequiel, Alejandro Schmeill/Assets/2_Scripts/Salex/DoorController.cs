using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    
    public GameObject key; // Referencia al objeto de la llave
    public GameObject door; // Referencia al objeto de la puerta
  
    private void Update()
    {
        // Verificar si el personaje está cerca de la puerta
        if (Vector3.Distance(transform.position, door.transform.position) < 1f)
        {
            // Verificar si el personaje tiene la llave necesaria
            if (Input.GetKeyDown(KeyCode.E) && key.activeSelf)
            {
                // Abrir la puerta
                door.SetActive(false);
            }
        }
    }
}
