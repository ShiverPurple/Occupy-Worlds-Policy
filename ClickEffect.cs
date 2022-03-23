using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEffect : MonoBehaviour
{

    [SerializeField] Camera mainCamera;

    void Update()
    {

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            Physics.Raycast(ray, out hit);

            if (hit.collider && hit.collider.CompareTag("Planet"))
            {
                GameObject particle = ObjectPoolClick.current.GetPoolCircle();

                if (particle != null)
                {

                    particle.transform.position = ray.origin;
                    particle.SetActive(true);
                    particle.GetComponent<ParticleSystem>().Play();

                }

            }

            else if (hit.collider && !hit.collider.CompareTag("Planet") && !hit.collider.CompareTag("Finish"))
            {

                GameObject particle2 = ObjectPoolClick.current.GetPoolSlash();

                particle2.transform.position = ray.origin;
                particle2.SetActive(true);
                particle2.GetComponent<ParticleSystem>().Play();

            }

        }

    }

}