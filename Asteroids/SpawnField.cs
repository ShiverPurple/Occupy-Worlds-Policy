using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnField : MonoBehaviour
{

    // Definindo os spawns dos asteroides
    
    
    [SerializeField] private GameObject Spawn1;
    [SerializeField] private GameObject Spawn2;
    [SerializeField] private GameObject Spawn3;
    [SerializeField] private GameObject Spawn4;
    [SerializeField] private GameObject Spawn5;
    [SerializeField] private GameObject Spawn6;
    [SerializeField] private GameObject Spawn7;
    [SerializeField] private GameObject Spawn8;
    [SerializeField] private GameObject Spawn9;
    [SerializeField] private GameObject Spawn10;
    [SerializeField] private GameObject Spawn11;
    [SerializeField] private GameObject Spawn12;
    [SerializeField] private GameObject Spawn13;
    [SerializeField] private GameObject Spawn14;
    [SerializeField] private GameObject Spawn15;
    [SerializeField] private GameObject Spawn16;
    [SerializeField] private GameObject Spawn17;
    [SerializeField] private GameObject Spawn18;
    [SerializeField] private GameObject Spawn19;

    // Lista com os spawns

    public List<GameObject> SpawnList;

    // Adiciona os spawns à lista a ser usada para spawnar

    void LoopList()
    {

        SpawnList.Add(Spawn1);
        SpawnList.Add(Spawn2);
        SpawnList.Add(Spawn3);
        SpawnList.Add(Spawn4);
        SpawnList.Add(Spawn5);
        SpawnList.Add(Spawn6);
        SpawnList.Add(Spawn7);
        SpawnList.Add(Spawn8);
        SpawnList.Add(Spawn9);
        SpawnList.Add(Spawn10);
        SpawnList.Add(Spawn11);
        SpawnList.Add(Spawn12);
        SpawnList.Add(Spawn13);
        SpawnList.Add(Spawn14);
        SpawnList.Add(Spawn15);
        SpawnList.Add(Spawn16);
        SpawnList.Add(Spawn17);
        SpawnList.Add(Spawn18);
        SpawnList.Add(Spawn19);

    }

    void Start()
    {

        LoopList();
        LancaLogo();
        
    }

    // Função do spawn propriamente dito 

    void LancaLogo()
    {

        StartCoroutine(AsteroidSmallSpawn());
        StartCoroutine(AsteroidMediumSpawn());
        StartCoroutine(AsteroidBigSpawn());

    }

    IEnumerator AsteroidSmallSpawn()
    {
        for (;;)
        {

            GameObject x = AsteroidPool.current.GetPoolS();
            x.transform.position = SpawnList[Random.Range(0, 18)].transform.position;
            x.SetActive(true);
            yield return new WaitForSeconds(5f);

        }
           
    }

    IEnumerator AsteroidMediumSpawn()
    {
        for (;;)
        {

            yield return new WaitForSeconds(20f);
            GameObject y = AsteroidPool.current.GetPoolM();
            y.transform.position = SpawnList[Random.Range(0, 18)].transform.position;
            y.SetActive(true);
           
        }

    }

    IEnumerator AsteroidBigSpawn()
    {
        for (;;)
        {

            yield return new WaitForSeconds(BuildButtonBehaviour.timeToAsteroidT3);
            GameObject z = AsteroidPool.current.GetPoolG();
            z.transform.position = SpawnList[Random.Range(0, 18)].transform.position;
            z.SetActive(true);
            
        }

    }

}
