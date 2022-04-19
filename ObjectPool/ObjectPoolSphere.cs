using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSphere : MonoBehaviour
{

    #region Initialization / Declaration

    public static ObjectPoolSphere instance;

    [SerializeField] private GameObject smallSphere;
    [SerializeField] private GameObject mediumSphere;
    [SerializeField] private GameObject greatSphere;

    private List<GameObject> smallSpherePool = new List<GameObject>();
    private List<GameObject> mediumSpherePool = new List<GameObject>();
    private List<GameObject> greatSpherePool = new List<GameObject>();

    #endregion

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateSpherePoolSmall();
        CreateSpherePoolMedium();
        CreateSpherePoolGreat();
    }

    #region Main Methods

    void CreateSpherePoolSmall()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject tempSphere = Instantiate(smallSphere);
            tempSphere.SetActive(false);

            smallSpherePool.Add(tempSphere);
        }
    }
    
    void CreateSpherePoolMedium()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject tempSphete = Instantiate(mediumSphere);
            tempSphete.SetActive(false);

            mediumSpherePool.Add(tempSphete);
        }
    }

    void CreateSpherePoolGreat()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject tempSphere = Instantiate(greatSphere);
            tempSphere.SetActive(false);

            greatSpherePool.Add(tempSphere);
        }
    }
  
    public GameObject GetSphereSmall()
    {
        if(smallSpherePool[smallSpherePool.Count - 1].activeSelf)
        {
            for(int i = 0; i < 10; i++)
            {
                smallSpherePool[i].SetActive(false);
            }
        }

        for(int i = 0; i < 10; i++)
        {
            if (!smallSpherePool[i].activeSelf)
            {
                return smallSpherePool[i];
            }
        }

        return null;
    }

    public GameObject GetSphereMedium()
    {
        if (mediumSpherePool[mediumSpherePool.Count - 1].activeSelf)
        {
            for (int i = 0; i < 3; i++)
            {
                mediumSpherePool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (!mediumSpherePool[i].activeSelf)
            {
                return mediumSpherePool[i];
            }
        }

        return null;
    }

    public GameObject GetSphereGreat()
    {
        if (greatSpherePool[greatSpherePool.Count - 1].activeSelf)
        {
            for (int i = 0; i < 3; i++)
            {
                greatSpherePool[i].SetActive(false);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (!greatSpherePool[i].activeSelf)
            {
                return greatSpherePool[i];
            }
        }

        return null;
    }

    #endregion

}
