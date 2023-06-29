using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushRigidbody : MonoBehaviour
{

    public float pushPower = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody body = collision.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        Vector3 pushDir = collision.contacts[0].point - transform.position;
        pushDir = new Vector3(pushDir.x, 0, pushDir.z).normalized;

        body.AddForce(pushDir * pushPower, ForceMode.Impulse);
    }
}
