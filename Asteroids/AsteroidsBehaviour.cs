using System.Collections;
using UnityEngine;

public class AsteroidsBehaviour : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private GameObject Target;

    protected float speedAsteroidT1 = 0.85f;
    protected float speedAsteroidT2 = 0.6f;
    protected float speedAsteroidT3 = 0.35f;

    private Quaternion defaultRotation = new Quaternion(0, 0, 0, 0);
    private Vector3 defaultVelocity = new Vector3(0, 0, 0);

    #endregion

    void OnEnable()
    {
        StartLaunchCoroutine();        
    }

    IEnumerator OutOfBounds()
    {
        if(gameObject.CompareTag("AsteroidSmall"))
        {
            while (true)
            {
                yield return new WaitForSeconds(30f);

                gameObject.SetActive(false);
            }
        }

        if (gameObject.CompareTag("AsteroidMedium"))
        {
            while (true)
            {
                yield return new WaitForSeconds(45f);

                gameObject.SetActive(false);
            }
        }

        if (gameObject.CompareTag("AsteroidGreat"))
        {
            while (true)
            {
                yield return new WaitForSeconds(50f);

                gameObject.SetActive(false);
            }
        }
    }

    void StartLaunchCoroutine()
    {
        StartCoroutine(OutOfBounds());
    }

    void FixedUpdate()
    {
        if (gameObject.CompareTag("AsteroidSmall"))
        {
            if ((gameObject.transform.position.x != Target.transform.position.x) && (gameObject.transform.position.y != Target.transform.position.y))
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speedAsteroidT1 * Time.fixedDeltaTime);
                gameObject.transform.Rotate(0, 0, Time.fixedDeltaTime * 50);
            }
        }
        else if (gameObject.CompareTag("AsteroidMedium"))
        {
            if ((gameObject.transform.position.x != Target.transform.position.x) && (gameObject.transform.position.y != Target.transform.position.y))
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speedAsteroidT2 * Time.fixedDeltaTime);
                gameObject.transform.Rotate(0, 0, Time.fixedDeltaTime * 50);
            }
        }
        else if (gameObject.CompareTag("AsteroidGreat"))
        {
            if ((gameObject.transform.position.x != Target.transform.position.x) && (gameObject.transform.position.y != Target.transform.position.y))
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speedAsteroidT3 * Time.fixedDeltaTime);
                gameObject.transform.Rotate(new Vector3(0, 0, 0.6f * Time.fixedDeltaTime * 50));
            }
        }

        if ((gameObject.transform.position.x == Target.transform.position.x) && (gameObject.transform.position.y == Target.transform.position.y))
        {
            gameObject.transform.rotation = defaultRotation;

            gameObject.GetComponent<Rigidbody>().velocity = defaultVelocity;
            gameObject.GetComponent<Rigidbody>().angularVelocity = defaultVelocity;
            gameObject.SetActive(false);
        }
    }

}
