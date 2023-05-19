using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody platformRb;
    public Transform[] platformPositions;
    public float platformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;

    void Update()
    {
        MovePlatform();
    }
    void MovePlatform()
    {
        if(moveToTheNext)
        {
            StartCoroutine(WaitForMove(0));
            platformRb.MovePosition(Vector3.MoveTowards(platformRb.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }
        if(Vector3.Distance(platformRb.position, platformPositions[nextPosition].position)<=0)
        {
            StartCoroutine(WaitForMove(waitTime));
            actualPosition = nextPosition;
            nextPosition++;

            if(nextPosition > platformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }
    IEnumerator WaitForMove(float time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;
    }
}
