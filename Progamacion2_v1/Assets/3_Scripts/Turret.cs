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
        Vector3 dir = player.position - transform.position; //posicion final - incial me da la direccion

        //transform.position = transform.forward; <--- para que te persiga

        if (dir.magnitude <= radius)
        {
            //transform.forward = dir;// mira hacia la direccion

            //transform.position = transform.forward; <--- para que te persiga

            transform.forward = Vector3.Lerp(transform.forward, dir, speedRotation * Time.deltaTime);
            //Lerp hace que se mueva mas lento

        }

    }
}
