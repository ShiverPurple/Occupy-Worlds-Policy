using System.Collections;
using UnityEngine;

public class SphereVanish : MonoBehaviour
{

    void OnEnable()
    {
        StartDeactivateSphere();
    }

    void StartDeactivateSphere()
    {
        StartCoroutine(DeactivateSphere());
    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(0.8f);

        gameObject.SetActive(false);
    }

}
