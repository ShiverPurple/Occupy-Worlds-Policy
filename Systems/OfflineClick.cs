using UnityEngine;
using System;

public class OfflineClick : MonoBehaviour
{

    #region Initialization / Declaration

    public static double timeGapResult = 0d;

    private DateTime currentTime;
    private DateTime oldTime;

    private TimeSpan timeGap;

    #endregion

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
