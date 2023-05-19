using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    private bool inZone;
    private bool active;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone == true)
        {
            active = !active;

            if (active == true)
            {
                door.SetBool("DoorAct", true);
            }
            else
            {
                door.SetBool("DoorAct", false);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inZone = false;

        }
    }
}
