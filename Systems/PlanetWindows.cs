using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetWindows : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] Rigidbody planetRigidbody;

    float rotSpeedPc = 700f;
    float amountPC = 25f;
    int locked = 0;


    void Update()
    {

        if (locked != 1)
        {

            transform.Rotate(new Vector3(0, -0.4f, 0));

        }

    }

    void OnMouseDrag()
    {

        if (!Input.GetMouseButtonUp(0))
        {

            transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotSpeedPc);
            locked = 1;

        }

    }


    void LateUpdate()
    {

        if (locked == 1 && Input.GetMouseButtonUp(0))
        {

            locked = 0;
            float x = -Input.GetAxis("Mouse X") * amountPC * Time.deltaTime;
            planetRigidbody.AddTorque(transform.up * x, ForceMode.VelocityChange);

        }

    }

    void FixedUpdate()
    {
        if (transform.position != new Vector3(0, 0, 0))
        {

            transform.position = new Vector3(0, 0, 0);

        }
    }

}
