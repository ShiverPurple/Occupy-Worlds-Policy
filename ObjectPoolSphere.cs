using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSphere : MonoBehaviour
{
   
    public static ObjectPoolSphere current;

    List<GameObject> SpherePoolS = new List<GameObject>();
    List<GameObject> SpherePoolM = new List<GameObject>();
    List<GameObject> SpherePoolG = new List<GameObject>();

    [SerializeField] GameObject smallSphere;
    [SerializeField] GameObject mediumSphere;
    [SerializeField] GameObject bigSphere;

    void Awake()
    {

        current = this;

    }

    void Start()
    {

        CreatePoolSphereS();
        CreatePoolSphereM();
        CreatePoolSphereG();

    }

    void CreatePoolSphereS()
    {

        for(int i = 0; i < 15; i++)
        {

            GameObject temp = Instantiate(smallSphere);
            temp.SetActive(false);
            SpherePoolS.Add(temp);

        }

    } 

    public GameObject GetSphereS()
    {

        if(SpherePoolS[SpherePoolS.Count - 1].activeSelf)
        {

            for(int i = 0; i < 15; i++)
            {

                SpherePoolS[i].SetActive(false);

            }

        }

        for(int i = 0; i < 15; i++)
        {

            if (!SpherePoolS[i].activeSelf)
            {

                return SpherePoolS[i];

            }

        }

        return null;

    }

    void CreatePoolSphereM()
    {

        for (int i = 0; i < 12; i++)
        {

            GameObject temp = Instantiate(mediumSphere);
            temp.SetActive(false);
            SpherePoolM.Add(temp);

        }

    }

    public GameObject GetSphereM()
    {

        if (SpherePoolM[SpherePoolM.Count - 1].activeSelf)
        {

            for (int i = 0; i < 12; i++)
            {

                SpherePoolM[i].SetActive(false);

            }

        }

        for (int i = 0; i < 12; i++)
        {

            if (!SpherePoolM[i].activeSelf)
            {

                return SpherePoolM[i];

            }

        }

        return null;

    }

    void CreatePoolSphereG()
    {

        for (int i = 0; i < 10; i++)
        {

            GameObject temp = Instantiate(bigSphere);
            temp.SetActive(false);
            SpherePoolG.Add(temp);

        }

    }

    public GameObject GetSphereG()
    {

        if (SpherePoolG[SpherePoolG.Count - 1].activeSelf)
        {

            for (int i = 0; i < 10; i++)
            {

                SpherePoolG[i].SetActive(false);

            }

        }

        for (int i = 0; i < 10; i++)
        {

            if (!SpherePoolG[i].activeSelf)
            {

                return SpherePoolG[i];

            }

        }

        return null;

    }



}
