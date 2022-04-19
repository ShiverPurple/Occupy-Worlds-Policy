using UnityEngine;
using TMPro;

public class HitPoint : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private Camera mainCamera;
    [SerializeField] private AudioSource rockClick;

    public static int destroyedAsteroidT1 = 0;
    public static int destroyedAsteroidT2 = 0;
    public static int destroyedAsteroidT3 = 0;

    private Quaternion defaultRotation = new Quaternion(0, 0, 0, 0);
    private Vector3 defaultVelocity = new Vector3(0, 0, 0);

    private int life;

    #endregion

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

    void LateUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(ray, out hit);

            if (hit.collider == gameObject.GetComponent<Collider>())
            {
                life -= 1;

                if (life == 0 && gameObject.CompareTag("AsteroidSmall"))
                {
                    TextMeshPro scoreParticle = AsteroidPoolScore.instance.GetScoreParticle();

                    GlobalMoney.moneyCount += BuildMenu.asteroidValues[0];
                    GlobalMoney.totalMoneyCount += BuildMenu.asteroidValues[0];

                    destroyedAsteroidT1 += 1;

                    Explode();

                    scoreParticle.SetText(MainClickButton.instance.FormatNumber(BuildMenu.asteroidValues[0]));

                    scoreParticle.transform.position = gameObject.transform.position;
                    scoreParticle.gameObject.SetActive(true);
                    AsteroidPoolScore.instance.ShowAsteroidScore(scoreParticle);
                }
                else if(life == 0 && gameObject.CompareTag("AsteroidMedium"))
                {
                    TextMeshPro scoreParticle = AsteroidPoolScore.instance.GetScoreParticle();

                    GlobalMoney.moneyCount += BuildMenu.asteroidValues[1];
                    GlobalMoney.totalMoneyCount += BuildMenu.asteroidValues[1];

                    destroyedAsteroidT2 += 1;

                    Explode();

                    scoreParticle.SetText(MainClickButton.instance.FormatNumber(BuildMenu.asteroidValues[1]));

                    scoreParticle.transform.position = gameObject.transform.position;
                    scoreParticle.gameObject.SetActive(true);
                    AsteroidPoolScore.instance.ShowAsteroidScore(scoreParticle);
                }
                else if(life == 0 && gameObject.CompareTag("AsteroidGreat"))
                {
                    TextMeshPro scoreParticle = AsteroidPoolScore.instance.GetScoreParticle();

                    GlobalMoney.moneyCount += BuildMenu.asteroidValues[2];
                    GlobalMoney.totalMoneyCount += BuildMenu.asteroidValues[2];

                    destroyedAsteroidT3 += 1;

                    Explode();

                    scoreParticle.SetText(MainClickButton.instance.FormatNumber(BuildMenu.asteroidValues[2]));

                    scoreParticle.transform.position = gameObject.transform.position;
                    scoreParticle.gameObject.SetActive(true);
                    AsteroidPoolScore.instance.ShowAsteroidScore(scoreParticle);
                }
                else if(life > 0)
                {
                    rockClick.Play();
                }
            }
        }
    }

    void ResetAsteroid()
    {
        gameObject.transform.rotation = defaultRotation;
        
        gameObject.GetComponent<Rigidbody>().velocity = defaultVelocity;
        gameObject.GetComponent<Rigidbody>().angularVelocity = defaultVelocity;
        gameObject.SetActive(false);
    }

    void Explode()
    {
        if (gameObject.CompareTag("AsteroidSmall"))
        {
            GameObject shatteredAsteroid = AsteroidPool.instance.GetSmallShatteredPool();
            shatteredAsteroid.transform.position = gameObject.transform.position;
            shatteredAsteroid.transform.rotation = gameObject.transform.rotation;
            ResetAsteroid();
            shatteredAsteroid.SetActive(true);

            GameObject sphere = ObjectPoolSphere.instance.GetSphereSmall();
            sphere.SetActive(true);
            sphere.transform.position = shatteredAsteroid.transform.position;
        }

        if (gameObject.CompareTag("AsteroidMedium"))
        {
            GameObject shatteredAsteroid = AsteroidPool.instance.GetMediumShatteredPool();
            shatteredAsteroid.transform.position = gameObject.transform.position;
            shatteredAsteroid.transform.rotation = gameObject.transform.rotation;
            ResetAsteroid();
            shatteredAsteroid.SetActive(true);

            GameObject sphere = ObjectPoolSphere.instance.GetSphereMedium();
            sphere.SetActive(true);
            sphere.transform.position = shatteredAsteroid.transform.position;
        }

        if (gameObject.CompareTag("AsteroidGreat"))
        {
            GameObject shatteredAsteroid = AsteroidPool.instance.GetGreatShatteredPool();
            shatteredAsteroid.transform.position = gameObject.transform.position;
            shatteredAsteroid.transform.rotation = gameObject.transform.rotation;
            ResetAsteroid();
            shatteredAsteroid.SetActive(true);

            GameObject sphere = ObjectPoolSphere.instance.GetSphereGreat();
            sphere.SetActive(true);
            sphere.transform.position = shatteredAsteroid.transform.position;
        }
    }

}
