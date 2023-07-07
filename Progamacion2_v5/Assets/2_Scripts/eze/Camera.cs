using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Camera _cam;

    [Range(0.1f, 2.0f)]

    public float sensitivity;
    public bool invertXaxis;
    public bool invertYaxis;

    public Transform lookAt;

    

    private void Awake()
    {
        _cam.transform.parent = transform;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        h = (invertXaxis) ? (-h) : h;
        v = (invertYaxis) ? (-v) : v;

        if (h != 0)
        {
            transform.Rotate(Vector3.up * h * 90 * sensitivity * Time.deltaTime);
        }
        if (v != 0)
        {
            _cam.transform.RotateAround(transform.position, transform.right, v * 90 * sensitivity * Time.deltaTime);
        }

        _cam.transform.LookAt(lookAt);

        //Vector3 ea = _cam.transform.rotation.eulerAngles;

        //_cam.transform.rotation = Quaternion.Euler(new Vector3(ea.x, ea.y, 0));

    }
}
