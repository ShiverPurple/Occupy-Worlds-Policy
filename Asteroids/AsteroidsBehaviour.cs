using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject Planet;

    protected float Sspeed = 0.8f;
    protected float Mspeed = 0.6f;
    protected float Gspeed = 0.35f;

    // Ignorar colisão entre dois asteroides ou asteroide e o planeta

    void OnEnable()
    {

        AsteroidPool.current.OnStartN();
        StartLaunchCoroutine();        

    }

    // Retornar o asteroide para o estágio inicial ao chegar no alvo

    IEnumerator OutOfBounds()
    {
        if(gameObject.CompareTag("AsteroidSmall"))
        {

            while (true)
            {

                yield return new WaitForSeconds(30f);
                gameObject.SetActive(false);

            };

        }

        if (gameObject.CompareTag("AsteroidMedium"))
        {

            while (true)
            {

                yield return new WaitForSeconds(45f);
                gameObject.SetActive(false);
            };

        }

        if (gameObject.CompareTag("AsteroidGreat"))
        {

            while (true)
            {

                yield return new WaitForSeconds(50f);
                gameObject.SetActive(false);

            };

        }

    }

    void FixedUpdate()
    {

        if (gameObject.CompareTag("AsteroidSmall"))
        {

            if ((gameObject.transform.position.x != Target.transform.position.x) && (gameObject.transform.position.y != Target.transform.position.y))
            {

                gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Sspeed * Time.deltaTime);
                gameObject.transform.Rotate(0, 0, Time.deltaTime * 50);

            }

        }

        else if (gameObject.CompareTag("AsteroidMedium"))
        {

            if ((gameObject.transform.position.x != Target.transform.position.x) && (gameObject.transform.position.y != Target.transform.position.y))
            {

                gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Mspeed * Time.deltaTime);
                gameObject.transform.Rotate(0, 0, Time.deltaTime * 50);

            }

        }

        else if (gameObject.CompareTag("AsteroidGreat"))
        {

            if ((gameObject.transform.position.x != Target.transform.position.x) && (gameObject.transform.position.y != Target.transform.position.y))
            {

                gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Gspeed * Time.deltaTime);
                gameObject.transform.Rotate(new Vector3(0, 0, 0.6f*Time.deltaTime * 50));

            }

        }



        if ((gameObject.transform.position.x == Target.transform.position.x) && (gameObject.transform.position.y == Target.transform.position.y))
        {

            if (gameObject.CompareTag("AsteroidSmall"))
            {

                gameObject.transform.rotation = AsteroidPool.SPositionNor;

            }
            
            else if(gameObject.CompareTag("AsteroidMedium"))
            {

                gameObject.transform.rotation = AsteroidPool.MPositionNor;

            }

            else if(gameObject.CompareTag("AsteroidGreat"))
            {

                gameObject.transform.rotation = AsteroidPool.GPositionNor;

            }

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
            gameObject.SetActive(false);
            
        }

    }

    // Movimenta o asteroide

    void StartLaunchCoroutine()
    {

        StartCoroutine(OutOfBounds());

    }

}
