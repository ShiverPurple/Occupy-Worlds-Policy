using System;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    
    // Torna a chamada de funções entre scripts possível

    public static AsteroidPool current;

    // Os asteroides, asteroides quebrados e suas listas

    public List<GameObject> SmallAsteroids = new List<GameObject>();
    public List<GameObject> SmallShattered = new List<GameObject>();
    public List<GameObject> MediumAsteroids = new List<GameObject>();
    public List<GameObject> MediumShattered = new List<GameObject>();
    public List<GameObject> GreatAsteroids = new List<GameObject>();
    public List<GameObject> GreatShattered = new List<GameObject>();


    // Temporario

    GameObject Stemp;
    GameObject Stemp2;
    GameObject Mtemp;
    GameObject Mtemp2;
    GameObject Gtemp;
    GameObject Gtemp2;

    public static List<Vector3> SPositionSha = new List<Vector3>();
    public static List<Vector3> MPositionSha = new List<Vector3>();
    public static List<Vector3> GPositionSha = new List<Vector3>();

    public static Quaternion SPositionNor;
    public static Quaternion MPositionNor;
    public static Quaternion GPositionNor;

    List<Transform> SchildArray = new List<Transform>();
    List<Transform> MchildArray = new List<Transform>();
    List<Transform> GchildArray = new List<Transform>();


    void Start()
    {

        SelectAsteroids.functions.currentBrokenT1 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDBrokenT1];
        SelectAsteroids.functions.currentBrokenT2 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDBrokenT2];
        SelectAsteroids.functions.currentBrokenT3 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDBrokenT3];

        SelectAsteroids.functions.currentT1 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDT1];
        SelectAsteroids.functions.currentT2 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDT2];
        SelectAsteroids.functions.currentT3 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDT3];

        SelectAsteroids.functions.currentBrokenT1.GetComponentsInChildren<Transform>(SchildArray);
        SelectAsteroids.functions.currentBrokenT2.GetComponentsInChildren<Transform>(MchildArray);
        SelectAsteroids.functions.currentBrokenT3.GetComponentsInChildren<Transform>(GchildArray);

        current = this;
        
        CreatePoolS();
        CreatePoolShatteredS();

        CreatePoolM();
        CreatePoolShatteredM();

        CreatePoolG();
        CreatePoolShatteredG();

    }

    public void ReloadBrokenS()
    {

        SelectAsteroids.functions.currentT1 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDT1];
        SelectAsteroids.functions.currentBrokenT1 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDBrokenT1];

        SelectAsteroids.functions.currentBrokenT1.GetComponentsInChildren<Transform>(SchildArray);

    }

    public void ReloadBrokenM()
    {

        SelectAsteroids.functions.currentT2 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDT2];
        SelectAsteroids.functions.currentBrokenT2 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDBrokenT2];

        SelectAsteroids.functions.currentBrokenT2.GetComponentsInChildren<Transform>(MchildArray);

    }

    public void ReloadBrokenG()
    {
        
        SelectAsteroids.functions.currentT3 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDT3];
        SelectAsteroids.functions.currentBrokenT3 = SelectAsteroids.functions.asteroidID[SelectAsteroids.currentIDBrokenT3];

        SelectAsteroids.functions.currentBrokenT3.GetComponentsInChildren<Transform>(GchildArray);

    }

    // Pega a posição dos asteroids quebrados 

    public void OnStartS()
    {

        for (int i = 0; i < SchildArray.Count; i++)
        {

            SPositionSha.Add(SchildArray[i].localPosition);

        }

        for (int i = 0; i < MchildArray.Count; i++)
        {

            MPositionSha.Add(MchildArray[i].localPosition);

        }

        for (int i = 0; i < GchildArray.Count; i++)
        {

            GPositionSha.Add(GchildArray[i].localPosition);

        }

    }

    // Pega a orientação dos asteroides inteiros

    public void OnStartN()
    {

        SPositionNor = SelectAsteroids.functions.currentT1.transform.rotation;
        MPositionNor = SelectAsteroids.functions.currentT2.transform.rotation;
        GPositionNor = SelectAsteroids.functions.currentT3.transform.rotation;

    }

    // Cria e pega a pool dos asteroids normais

    public void CreatePoolS()
    {

        for(int i = 0; i < 10; i++)
        {

            Stemp = Instantiate(SelectAsteroids.functions.currentT1);
            Stemp.SetActive(false);
            SmallAsteroids.Add(Stemp);

        }

    }

    public GameObject GetPoolS()
    {

        if(SmallAsteroids[SmallAsteroids.Count - 1].activeSelf){

            for(int i = 0; i < 10; i++)
            {

                SmallAsteroids[i].SetActive(false);

            }

        }

        for(int i = 0; i < 10; i++)
        {

            if (!SmallAsteroids[i].activeSelf)
            {

                return SmallAsteroids[i];

            }

        }

        return null;

    }


    public void CreatePoolM()
    {

        for(int i = 0; i < 3; i++)
        {

            Mtemp = Instantiate(SelectAsteroids.functions.currentT2);
            Mtemp.SetActive(false);
            MediumAsteroids.Add(Mtemp);

        }

    }

    public GameObject GetPoolM()
    {

        if (MediumAsteroids[MediumAsteroids.Count - 1].activeSelf)
        {

            for(int i = 0; i < 3; i++)
            {

                MediumAsteroids[i].SetActive(false);

            }

        }

        for(int i = 0; i < 3; i++)
        {

            if (!MediumAsteroids[i].activeSelf)
            {

                return MediumAsteroids[i];

            }

        }

        return null;

    }


    public void CreatePoolG()
    {

        for(int i = 0; i < 3; i++)
        {

            Gtemp = Instantiate(SelectAsteroids.functions.currentT3);
            Gtemp.SetActive(false);
            GreatAsteroids.Add(Gtemp);

        }

    }

    public GameObject GetPoolG()
    {

        if(GreatAsteroids[GreatAsteroids.Count - 1].activeSelf)
        {

            for(int i = 0; i < 3; i++)
            {

                GreatAsteroids[i].SetActive(false);

            }

        }

        for(int i = 0; i < 3; i++)
        {

            if (!GreatAsteroids[i].activeSelf)
            {

                return GreatAsteroids[i];

            }

        }

        return null;

    }


    // Cria e pega a pool dos asteroids quebrados

    public void CreatePoolShatteredS()
    {

        for (int i = 0; i < 10; i++)
        {

            Stemp2 = Instantiate(SelectAsteroids.functions.currentBrokenT1);
            Stemp2.SetActive(false);
            SmallShattered.Add(Stemp2);

        }

    }

    public GameObject GetPoolShatteredS()
    {

        if (SmallShattered[SmallAsteroids.Count - 1].activeSelf)
        {

            for (int i = 0; i < 10; i++)
            {

                SmallShattered[i].SetActive(false);

            }

        }

        for (int i = 0; i < 10; i++)
        {

            if (!SmallShattered[i].activeSelf)
            {

                return SmallShattered[i];

            }

        }

        return null;

    }


    public void CreatePoolShatteredM()
    {

        for(int i = 0; i < 3; i++)
        {

            Mtemp2 = Instantiate(SelectAsteroids.functions.currentBrokenT2);
            Mtemp2.SetActive(false);
            MediumShattered.Add(Mtemp2);

        }

    }

    public GameObject GetPoolShatteredM()
    {

        if(MediumShattered[MediumShattered.Count - 1].activeSelf)
        {

            for(int i = 0; 0 < 3; i++)
            {

                MediumShattered[i].SetActive(false);

            }

        }

        for(int i = 0; i < 3; i++)
        {

            if (!MediumShattered[i].activeSelf)
            {

                return MediumShattered[i];

            }

        }

        return null;

    }


    public void CreatePoolShatteredG()
    {

        for(int i = 0; i < 3; i++)
        {

            Gtemp2 = Instantiate(SelectAsteroids.functions.currentBrokenT3);
            Gtemp2.SetActive(false);
            GreatShattered.Add(Gtemp2);

        }

    }

    public GameObject GetPoolShatteredG()
    {

        if (GreatShattered[GreatShattered.Count - 1].activeSelf)
        {

            for (int i = 0; i < 3; i++)
            {

                GreatShattered[i].SetActive(false);

            }

        }

        for (int i = 0; i < 3; i++)
        {

            if (!GreatShattered[i].activeSelf)
            {

                return GreatShattered[i];

            }

        }

        return null;

    }

}