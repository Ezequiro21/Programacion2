using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSteps : MonoBehaviour
{
  
    public AudioClip eventRespuestaRightStep;
    public AudioClip eventRespuestaLeftStep;
    public AudioClip eventRespuestaRightStepGround;
    public AudioClip eventRespuestaLeftStepGround;

    public PlayerControlller playerController;

   
    
    
    public void MakeStepRight()
    {
        
            AudioSource audioSource = GetComponent<AudioSource>();
        
            if (playerController.groundDetected)
            {   
                audioSource.clip = eventRespuestaRightStepGround;
                audioSource.Play();
            }
            else
            {
                Debug.Log("Derecha");
                audioSource.clip = eventRespuestaRightStep;
                audioSource.Play();

            }
        
    }
    public void MakeStepLeft()
    {
        
            AudioSource audioSource = GetComponent<AudioSource>();

            if (playerController.groundDetected)
            {   
                audioSource.clip = eventRespuestaLeftStepGround;
                audioSource.Play();
            }
            else
            {
                Debug.Log("Izquierda");
                audioSource.clip = eventRespuestaLeftStep;
                audioSource.Play();

            }
        
    }
}
