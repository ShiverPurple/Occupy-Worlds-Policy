using System.Collections;
using UnityEngine;

public class SpawnField : MonoBehaviour
{

    public GameObject[] spawnArray = new GameObject[19];

    void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        StartCoroutine(AsteroidSmallSpawn());
        StartCoroutine(AsteroidMediumSpawn());
        StartCoroutine(AsteroidBigSpawn());
    }

    IEnumerator AsteroidSmallSpawn()
    {
        while(true)
        {
            GameObject tempAsteroid = AsteroidPool.instance.GetSmallAsteroidPool();
            tempAsteroid.transform.position = spawnArray[Random.Range(0, 18)].transform.position;
            tempAsteroid.SetActive(true);

            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator AsteroidMediumSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(20f);

            GameObject tempAsteroid = AsteroidPool.instance.GetMediumAsteroidPool();
            tempAsteroid.transform.position = spawnArray[Random.Range(0, 18)].transform.position;
            tempAsteroid.SetActive(true);
        }
    }

    IEnumerator AsteroidBigSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(BuildMenu.timeToAsteroidT3);

            GameObject tempAsteroid = AsteroidPool.instance.GetGreatAsteroidPool();
            tempAsteroid.transform.position = spawnArray[Random.Range(0, 18)].transform.position;
            tempAsteroid.SetActive(true);
        }
    }

}
