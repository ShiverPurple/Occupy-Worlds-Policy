using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredPosition : MonoBehaviour
{
    public List<Renderer> childArray = new List<Renderer>();

    void Start()
    {

       GetComponentsInChildren(childArray);
       AsteroidPool.current.OnStartS();

    }

    //Retorna a posição dos fragmentos de asteroid para a original

    void OnEnable()
    {

        for (int i = 0; i < childArray.Count; i++)
        {

            if(gameObject.CompareTag("ShatteredSmall")) 
            {

                childArray[i].transform.localPosition = AsteroidPool.SPositionSha[i];

            }
            
            else if(gameObject.CompareTag("ShatteredMedium"))
            {

                childArray[i].transform.localPosition = AsteroidPool.MPositionSha[i];

            }

            else if(gameObject.CompareTag("ShatteredGreat"))
            {

                childArray[i].transform.localPosition = AsteroidPool.GPositionSha[i];

            }

        }

    }

}
