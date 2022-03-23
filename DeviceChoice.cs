using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceChoice : MonoBehaviour
{

    void Start()
    {

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {

            gameObject.GetComponent<PlanetWindows>().enabled = true;

        }

        else if(Application.platform == RuntimePlatform.Android)
        {

            gameObject.GetComponent<PlanetAndroid>().enabled = true;

        }

    }

}
