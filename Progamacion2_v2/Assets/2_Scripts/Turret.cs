using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public float radius;
    public float speedRotation;


    private void Update()
    {
        Vector3 dir = player.position - transform.position; 

        

        if (dir.magnitude <= radius)
        {
            

            transform.forward = Vector3.Lerp(transform.forward, dir, speedRotation * Time.deltaTime);
            

        }

    }
}
