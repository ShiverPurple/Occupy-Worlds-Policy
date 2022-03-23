using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HitPoint : MonoBehaviour
{

    [SerializeField] AudioSource toc;

    int life;

    void OnEnable()
    {

        if (gameObject.CompareTag("AsteroidSmall")) 
        {

            life = 1;

        }

        else if (gameObject.CompareTag("AsteroidMedium")) 
        {

            life = 2;
        
        }

        else if (gameObject.CompareTag("AsteroidGreat")) 
        {

            life = 3;
        
        }

    }

    // Remove um hitpoint a cada click e adiciona os pontos

    void LateUpdate()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {

            Physics.Raycast(ray, out hit);

            if (hit.collider == gameObject.GetComponent<Collider>())
            {

                life -= 1;

               

                if (life == 0 && gameObject.CompareTag("AsteroidSmall"))
                {

                    GlobalMoney.moneyCount += BuildButtonBehaviour.marsAsteroidPoints[0];
                    Explode();

                }

                else if(life == 0 && gameObject.CompareTag("AsteroidMedium"))
                {

                    GlobalMoney.moneyCount += BuildButtonBehaviour.marsAsteroidPoints[1];
                    Explode();

                }

                else if(life == 0 && gameObject.CompareTag("AsteroidGreat"))
                {

                    GlobalMoney.moneyCount += BuildButtonBehaviour.marsAsteroidPoints[2];
                    Explode();

                }

                else if(life > 0)
                {

                    toc.Play();

                }

            }

        }

    }

    
    // Retorna o asteroid para o estado inicial

    void Vanish()
    {

        if (gameObject.CompareTag("AsteroidSmall"))
        {

            gameObject.transform.rotation = AsteroidPool.SPositionNor;

        }

        if (gameObject.CompareTag("AsteroidMedium"))
        {

            gameObject.transform.rotation = AsteroidPool.MPositionNor;

        }

        if (gameObject.CompareTag("AsteroidGreat"))
        {

            gameObject.transform.rotation = AsteroidPool.GPositionNor;

        }

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
        gameObject.SetActive(false);

    }


    // Spawn um asteroide dentro do outro e o explode

    void Explode()
    {

        if (gameObject.CompareTag("AsteroidSmall"))
        {

            GameObject x = AsteroidPool.current.GetPoolShatteredS();
            x.transform.position = gameObject.transform.position;
            x.transform.rotation = gameObject.transform.rotation;
            Vanish();
            x.SetActive(true);
            GameObject temp = ObjectPoolSphere.current.GetSphereS();
            temp.SetActive(true);
            temp.transform.position = x.transform.position;

        }

        if (gameObject.CompareTag("AsteroidMedium"))
        {
            GameObject y = AsteroidPool.current.GetPoolShatteredM();
            y.transform.position = gameObject.transform.position;
            y.transform.rotation = gameObject.transform.rotation;
            Vanish();
            y.SetActive(true);
            GameObject temp = ObjectPoolSphere.current.GetSphereM();
            temp.SetActive(true);
            temp.transform.position = y.transform.position;

        }

        if (gameObject.CompareTag("AsteroidGreat"))
        {
            GameObject z = AsteroidPool.current.GetPoolShatteredG();
            z.transform.position = gameObject.transform.position;
            z.transform.rotation = gameObject.transform.rotation;
            Vanish();
            z.SetActive(true);
            GameObject temp = ObjectPoolSphere.current.GetSphereG();
            temp.SetActive(true);
            temp.transform.position = z.transform.position;

        }

    }

}
