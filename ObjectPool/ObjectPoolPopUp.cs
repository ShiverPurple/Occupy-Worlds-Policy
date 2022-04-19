using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolPopUp : MonoBehaviour
{

    #region Initialization / Declaration

    public static ObjectPoolPopUp instance;

    [SerializeField] private GameObject textPopUp;
    
    private List<GameObject> popUpPool = new List<GameObject>();

    #endregion

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreatePopUpPool();
    }

    void CreatePopUpPool()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject tempPopUp = Instantiate(textPopUp);
            tempPopUp.SetActive(false);

            popUpPool.Add(tempPopUp);
        }
    }

    public GameObject GetPopUpParticle()
    {
        if(popUpPool[popUpPool.Count - 1].activeInHierarchy)
        {
            for(int i = 0; i < popUpPool.Count; i++)
            {
                if (popUpPool[i].GetComponent<ParticleSystem>().time >= 3.20f)
                {
                    popUpPool[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < popUpPool.Count; i++)
        {
            if (!popUpPool[i].activeSelf)
            {
                return popUpPool[i];
            }    
        }

        return null;
    }

}
