using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float forcejump;
    public Animator anim;
    float speedrun;
    bool isjump = false;
    bool floorDetected = false;
   


    private void Start()
    {
        speedrun = 1;
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal= Input.GetAxis("Horizontal");

        transform.position += transform.forward * vertical * speed * speedrun * Time.deltaTime;

        anim.SetFloat("Vertical", vertical);
        
        transform.position += transform.right * horizontal * speed * speedrun * Time.deltaTime;

        anim.SetFloat("Horizontal", horizontal);

        Vector3 floor = transform.TransformDirection(Vector3.down); //apunta hacia el suelo

        if(Physics.Raycast(transform.position, floor, 1.03f))
        {
            floorDetected = true;
            
        }
        else
        {
            floorDetected = false;
            
        }

        isjump = Input.GetButtonDown("Jump");

        if (isjump && floorDetected)
        {
            rb.AddForce(new Vector3(0, forcejump, 0), ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
   
      
       if (vertical > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedrun = 2;
                anim.SetBool("Run", true);
            }
            else
            {
                speedrun = 1;
                anim.SetBool("Run", false);
            }
        }
       
    }
}
