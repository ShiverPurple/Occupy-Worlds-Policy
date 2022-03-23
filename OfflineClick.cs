using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class OfflineClick : MonoBehaviour
{

    DateTime currentTime;
    DateTime oldTime;

    public TimeSpan timeGap;

    public static double timeGapResult = 0d;



    void Start()
    {

      
        currentTime = DateTime.Now;

        if (PlayerPrefs.HasKey("oldTime")){

            oldTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("oldTime")));

            if (oldTime != DateTime.Now)
            {

                timeGap = currentTime.Subtract(oldTime);
                timeGapResult = Convert.ToInt64(Math.Round(timeGap.TotalSeconds));

            }

        }

    }

    void OnApplicationPause()
    {

        PlayerPrefs.SetString("oldTime", DateTime.Now.ToBinary().ToString());

    }


    void OnApplicationQuit()
    {

        PlayerPrefs.SetString("oldTime", DateTime.Now.ToBinary().ToString());
        Application.Quit();

    }

}
