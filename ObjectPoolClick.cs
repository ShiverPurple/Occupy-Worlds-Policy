using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolClick : MonoBehaviour
{

    public static ObjectPoolClick current;
    List<GameObject> PoolList = new List<GameObject>();
    List<GameObject> PoolList2 = new List<GameObject>();
    public GameObject ObjectToPool;
    public GameObject ObjectToPool2;

    void Awake()
    {

        current = this;

    }

    void Start()
    {

        CreatePoolCircle();
        CreatePoolSlash();

    }

    // Functions

    public void CreatePoolCircle()
    {

        for (int i = 0; i < 10; i++)
        {

            GameObject temp = Instantiate(ObjectToPool);
            temp.SetActive(false);
            PoolList.Add(temp);

        }

    }

    public void CreatePoolSlash()
    {

        for(int i = 0; i < 10; i++)
        {

            GameObject temp2 = Instantiate(ObjectToPool2);
            temp2.SetActive(false);
            PoolList2.Add(temp2);

        }

    }

    public GameObject GetPoolCircle()
    {

        if (PoolList[PoolList.Count - 1].activeInHierarchy)
        {

            for (int i = 0; i < PoolList.Count; i++)
            {

                if(PoolList[i].GetComponent<ParticleSystem>().time == 0.5)
                {

                    PoolList[i].SetActive(false);

                }
                
            }

        }

        for (int i = 0; i < PoolList.Count; i++)
        {

            if (!PoolList[i].activeInHierarchy)
            {

                return PoolList[i];

            }

        }

        return null;

    }
    
    public GameObject GetPoolSlash()
    {

        if (PoolList2[PoolList2.Count - 1].activeInHierarchy)
        {

            for(int i = 0; i < PoolList2.Count; i++)
            {

                if (PoolList2[i].GetComponent<ParticleSystem>().time == 0.5f) 
                {

                    PoolList2[i].SetActive(false);

                }
                
            }

        }

        for(int i = 0; i < PoolList2.Count; i++)
        {

            if (!PoolList2[i].activeInHierarchy)
            {

                return PoolList2[i];

            }

        }

        return null;

    }

}