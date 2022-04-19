using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{

    #region Initialization / Declaration

    public static AsteroidPool instance;

    [SerializeField] private List<GameObject> smallAsteroidPool = new List<GameObject>();
    [SerializeField] private List<GameObject> mediumAsteroidPool = new List<GameObject>();
    [SerializeField] private List<GameObject> greatAsteroidPool = new List<GameObject>();

    [SerializeField] private List<GameObject> smallShatteredPool = new List<GameObject>();
    [SerializeField] private List<GameObject> mediumShatteredPool = new List<GameObject>();
    [SerializeField] private List<GameObject> greatShatteredPool = new List<GameObject>();

    public static List<Transform> smallShatteredChildren = new List<Transform>();
    public static List<Transform> nediumShatteredChildren = new List<Transform>();
    public static List<Transform> greatShatteredChildren = new List<Transform>();

    #endregion

    void Start()
    {
        instance = this;

        CreateSmallAsteroidPool();
        CreateMediumAsteroidPool();
        CreateGreatAsteroidPool();

        CreateSmallShatteredPool();
        CreateMediumShatteredPool();
        CreateGreatShatteredPool();
    }

    #region Main Methods

    //--------------------- Criar e Pegar Asteroides ---------------------//

    public void CreateSmallAsteroidPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject smallAsteroid = Instantiate(SelectAsteroids.instance.currentT1);
            smallAsteroid.SetActive(false);

            smallAsteroidPool.Add(smallAsteroid);
        }
    }

    public void CreateMediumAsteroidPool()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject mediumAsteroid = Instantiate(SelectAsteroids.instance.currentT2);
            mediumAsteroid.SetActive(false);

            mediumAsteroidPool.Add(mediumAsteroid);
        }
    }

    public void CreateGreatAsteroidPool()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject greatAsteroid = Instantiate(SelectAsteroids.instance.currentT3);
            greatAsteroid.SetActive(false);

            greatAsteroidPool.Add(greatAsteroid);
        }
    }

    public GameObject GetSmallAsteroidPool()
    {
        if (smallAsteroidPool[smallAsteroidPool.Count - 1].activeSelf)
        {
            for (int i = 0; i < 10; i++)
            {
                smallAsteroidPool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (!smallAsteroidPool[i].activeSelf)
            {
                return smallAsteroidPool[i];
            }
        }

        return null;
    }

    public GameObject GetMediumAsteroidPool()
    {
        if (mediumAsteroidPool[mediumAsteroidPool.Count - 1].activeSelf)
        {
            for (int i = 0; i < 3; i++)
            {
                mediumAsteroidPool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (!mediumAsteroidPool[i].activeSelf)
            {
                return mediumAsteroidPool[i];
            }
        }

        return null;
    }

    public GameObject GetGreatAsteroidPool()
    {
        if (greatAsteroidPool[greatAsteroidPool.Count - 1].activeSelf)
        {
            for (int i = 0; i < 3; i++)
            {
                greatAsteroidPool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (!greatAsteroidPool[i].activeSelf)
            {
                return greatAsteroidPool[i];
            }
        }

        return null;
    }

    //--------------------- Criar e Pegar Asteroides Quebrados ---------------------//

    public void CreateSmallShatteredPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject smallShattered = Instantiate(SelectAsteroids.instance.currentBrokenT1);
            smallShattered.SetActive(false);

            smallShatteredPool.Add(smallShattered);
        }
    }

    public void CreateMediumShatteredPool()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject mediumShattered = Instantiate(SelectAsteroids.instance.currentBrokenT2);
            mediumShattered.SetActive(false);

            mediumShatteredPool.Add(mediumShattered);
        }
    }

    public void CreateGreatShatteredPool()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject greatShattered = Instantiate(SelectAsteroids.instance.currentBrokenT3);
            greatShattered.SetActive(false);

            greatShatteredPool.Add(greatShattered);
        }
    }

    public GameObject GetSmallShatteredPool()
    {
        if (smallShatteredPool[smallAsteroidPool.Count - 1].activeSelf)
        {
            for (int i = 0; i < 10; i++)
            {
                smallShatteredPool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (!smallShatteredPool[i].activeSelf)
            {
                return smallShatteredPool[i];
            }
        }

        return null;
    }

    public GameObject GetMediumShatteredPool()
    {
        if (mediumShatteredPool[mediumShatteredPool.Count - 1].activeSelf)
        {
            for (int i = 0; 0 < 3; i++)
            {
                mediumShatteredPool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (!mediumShatteredPool[i].activeSelf)
            {
                return mediumShatteredPool[i];
            }
        }

        return null;
    }

    public GameObject GetGreatShatteredPool()
    {

        if (greatShatteredPool[greatShatteredPool.Count - 1].activeSelf)
        {
            for (int i = 0; i < 3; i++)
            {
                greatShatteredPool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (!greatShatteredPool[i].activeSelf)
            {
                return greatShatteredPool[i];
            }
        }

        return null;
    }

    //--------------------- Recarregar o Pool ---------------------//

    public void ReloadSmallShattered()
    {
        SelectAsteroids.instance.currentT1 = SelectAsteroids.instance.asteroidID[SelectAsteroids.currentIDT1];
        SelectAsteroids.instance.currentBrokenT1 = SelectAsteroids.instance.asteroidID[SelectAsteroids.currentIDBrokenT1];

        SelectAsteroids.instance.currentBrokenT1.GetComponentsInChildren(smallShatteredChildren);
    }

    public void ReloadMediumShattered()
    {
        SelectAsteroids.instance.currentT2 = SelectAsteroids.instance.asteroidID[SelectAsteroids.currentIDT2];
        SelectAsteroids.instance.currentBrokenT2 = SelectAsteroids.instance.asteroidID[SelectAsteroids.currentIDBrokenT2];

        SelectAsteroids.instance.currentBrokenT2.GetComponentsInChildren<Transform>(nediumShatteredChildren);
    }

    public void ReloadGreatShattered()
    {
        SelectAsteroids.instance.currentT3 = SelectAsteroids.instance.asteroidID[SelectAsteroids.currentIDT3];
        SelectAsteroids.instance.currentBrokenT3 = SelectAsteroids.instance.asteroidID[SelectAsteroids.currentIDBrokenT3];

        SelectAsteroids.instance.currentBrokenT3.GetComponentsInChildren<Transform>(greatShatteredChildren);
    }

    //--------------------- Destruir e Preencher o Pool ---------------------//

    public void RefillSmallAsteroidPool()
    {
        for (int i = 0; i < 10; i++)
        {
            Destroy(smallAsteroidPool[i]);

            GameObject smallAsteroid = Instantiate(SelectAsteroids.instance.currentT1);
            smallAsteroid.SetActive(false);

            smallAsteroidPool[i] = smallAsteroid;
        }
    }

    public void RefillMediumAsteroidPool()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(mediumAsteroidPool[i]);

            GameObject mediumAsteroid = Instantiate(SelectAsteroids.instance.currentT2);
            mediumAsteroid.SetActive(false);

            mediumAsteroidPool[i] = mediumAsteroid;
        }
    }

    public void RefillGreatAsteroidPool()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(greatAsteroidPool[i]);

            GameObject greatAsteroid = Instantiate(SelectAsteroids.instance.currentT3);
            greatAsteroid.SetActive(false);

            greatAsteroidPool[i] = greatAsteroid;
        }
    }

    public void RefillSmallShatteredPool()
    {
        for (int i = 0; i < 10; i++)
        {
            Destroy(smallShatteredPool[i]);

            GameObject smallShattered = Instantiate(SelectAsteroids.instance.currentBrokenT1);
            smallShattered.SetActive(false);

            smallShatteredPool[i] = smallShattered;
        }
    }

    public void RefillMediumShatteredPool()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(mediumShatteredPool[i]);

            GameObject mediumShattered = Instantiate(SelectAsteroids.instance.currentBrokenT2);
            mediumShattered.SetActive(false);

            mediumShatteredPool[i] = mediumShattered;
        }
    }

    public void RefillGreatShatteredPool()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(greatShatteredPool[i]);

            GameObject greatShattered = Instantiate(SelectAsteroids.instance.currentBrokenT3);
            greatShattered.SetActive(false);

            greatShatteredPool[i] = greatShattered;
        }
    }

    #endregion

}