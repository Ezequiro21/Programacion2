using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSteps : MonoBehaviour
{
  
   

    public AudioSource eventRespuestaRightStep;
    public AudioSource eventRespuestaLeftStep;
    public AudioSource eventRespuestaRightStepGround;
    public AudioSource eventRespuestaLeftStepGround;

    public PlayerControlller playerController;

   
    
    
    public void MakeStepRight()
    {
        
            AudioSource audioSource = GetComponent<AudioSource>();
        
            if (playerController.groundDetected)
            {   
                eventRespuestaRightStepGround.Play();
            }
            else
            {
                Debug.Log("Derecha");
                
                eventRespuestaRightStep.Play();

            }
        
    }
    public void MakeStepLeft()
    {
        
            AudioSource audioSource = GetComponent<AudioSource>();

            if (playerController.groundDetected)
            {   
                eventRespuestaLeftStepGround.Play();
            }
            else
            {
                Debug.Log("Izquierda");

            eventRespuestaLeftStep.Play();

            }
        
    }
}
