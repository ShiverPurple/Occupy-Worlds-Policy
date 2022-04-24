using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolClick : MonoBehaviour
{

    #region Initialization / Declaration

    public static ObjectPoolClick instance;

    [SerializeField] private GameObject circleParticle;
    [SerializeField] private GameObject slashParticle;

    private List<GameObject> circlePool = new List<GameObject>();
    private List<GameObject> slashPool = new List<GameObject>();

    #endregion

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateCirclePool();
        CreateSlashPool();
    }

    #region Main Methods

    public void CreateCirclePool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject tempCircle = Instantiate(circleParticle);
            tempCircle.SetActive(false);

            circlePool.Add(tempCircle);
        }
    }

    public void CreateSlashPool()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject temopSlash = Instantiate(slashParticle);
            temopSlash.SetActive(false);

            slashPool.Add(temopSlash);
        }
    }

    public GameObject GetCircleParticle()
    {
        if (circlePool[circlePool.Count - 1].activeInHierarchy)
        {
            for (int i = 0; i < circlePool.Count; i++)
            {
                if(circlePool[i].GetComponent<ParticleSystem>().time == 0.5f)
                {
                    circlePool[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < circlePool.Count; i++)
        {
            if (!circlePool[i].activeInHierarchy)
            {
                return circlePool[i];
            }
        }

        return null;
    }
    
    public GameObject GetSlashParticle()
    {
        if (slashPool[slashPool.Count - 1].activeInHierarchy)
        {
            for(int i = 0; i < slashPool.Count; i++)
            {
                if (slashPool[i].GetComponent<ParticleSystem>().time == 0.5f) 
                {
                    slashPool[i].SetActive(false);
                }
            }
        }

        for(int i = 0; i < slashPool.Count; i++)
        {
            if (!slashPool[i].activeInHierarchy)
            {
                return slashPool[i];
            }
        }

        return null;
    }

    #endregion

}