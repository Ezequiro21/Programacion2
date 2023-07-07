using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletT : MonoBehaviour
{
    public float speed;


    void Start()
    {
        Destroy(gameObject, 4);
    }


    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
