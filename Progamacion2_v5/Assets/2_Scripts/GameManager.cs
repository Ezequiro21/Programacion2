using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public GameObject fadeInPanel;
    //public BoolValue hasDialoguePlayed;
  

  

    private void Awake()
    {
       /* if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }*/
        //hasDialoguePlayed.RuntimeValue = false;
    }
    
    void Start()
    {
        
       if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 2);
        }
    }


    void Update()
    {
        
    }
}
