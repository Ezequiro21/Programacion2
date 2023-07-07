using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarSonidoSalto : MonoBehaviour
{
    public AudioSource soundTrampolin;
    public float jumpForce ;
    

     void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                soundTrampolin.Play();
                Debug.Log("ElPLAtillovolador");
                
            }
        }


  
}
