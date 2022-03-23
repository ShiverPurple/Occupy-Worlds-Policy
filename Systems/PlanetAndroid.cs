using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAndroid : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] Rigidbody planetRigidbody;

    float rotSpeedMobile = 4f;
    float amountMobile = 8f;

    Touch touch;

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

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            float pointer_x = touch.deltaPosition.x;
            transform.Rotate(new Vector3(0, -pointer_x, 0) * Time.fixedDeltaTime * rotSpeedMobile);

        }

    }

    void LateUpdate()
    {

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (locked == 1 && touch.phase == TouchPhase.Ended)
            {

                locked = 0;
                float pointer_x = touch.deltaPosition.x;
                float x = -pointer_x * amountMobile * Time.deltaTime;
                planetRigidbody.AddTorque(transform.up * x, ForceMode.VelocityChange);

            }

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
