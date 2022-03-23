using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolPopUp : MonoBehaviour
{

    public GameObject TextPopUp;
    List<GameObject> PoolList = new List<GameObject>();
    GameObject temp;
    public static ObjectPoolPopUp current;

    void Awake()
    {

        current = this;

    }

    void Start()
    {

        CreatePool();

    }

    //Functions

    void CreatePool()
    {

        for (int i = 0; i < 25; i++)
        {

            temp = Instantiate(TextPopUp);
            temp.SetActive(false);
            PoolList.Add(temp);

        }

    }

    public GameObject GetPool()
    {

        if(PoolList[PoolList.Count - 1].activeInHierarchy)
        {

            for(int i = 0; i < PoolList.Count; i++)
            {

                if (PoolList[i].GetComponent<ParticleSystem>().time >= 3.20f)
                {

                    PoolList[i].SetActive(false);

                }
                
            }

        }

        for (int i = 0; i < PoolList.Count; i++)
        {

            if (!PoolList[i].activeSelf)
            {
           
                return PoolList[i];

            }    

        }

        return null;

    }

}
