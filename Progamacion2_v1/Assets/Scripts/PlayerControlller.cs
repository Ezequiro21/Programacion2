using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float forcejump;
    

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal= Input.GetAxis("Horizontal");

        transform.position += transform.forward * vertical * speed * Time.deltaTime;
        transform.position += transform.right * horizontal * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forcejump, ForceMode.Impulse);
        }
    }
}
