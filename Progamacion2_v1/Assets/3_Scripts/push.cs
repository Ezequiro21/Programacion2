using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    public float pushPower = 2.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if(hit.moveDirection.y < -0.2)
        {
            return;
        }

        Vector3 pushdir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushdir * pushPower;
    }
}
