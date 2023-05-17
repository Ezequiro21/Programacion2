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

    private void Start()
    {
        speedrun = 1;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forcejump, ForceMode.Impulse);
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
