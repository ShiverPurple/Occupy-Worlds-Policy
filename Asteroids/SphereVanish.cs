using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVanish : MonoBehaviour
{

    void OnEnable()
    {

        StartAdios();

    }

    void StartAdios()
    {

        StartCoroutine(SphereAdios());

    }

    IEnumerator SphereAdios()
    {

        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);

    }


}
