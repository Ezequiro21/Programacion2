using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    public GameObject bullet;
    public float cooldown;
    float counter;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= cooldown)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            counter = 0;
        }
    }
}
