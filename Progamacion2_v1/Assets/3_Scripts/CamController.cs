using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    public float speedrotation;


    void Update()
    {
        if(Time.timeScale == 1)
        {
            float x = Input.GetAxis("Mouse X");


            player.Rotate(Vector3.up * x * speedrotation);
        }
     
    }
}
