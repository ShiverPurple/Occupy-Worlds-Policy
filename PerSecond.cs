using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class PerSecond : MonoBehaviour{

    // Save System
    public PlayerData perSecondData = new PlayerData();

    [SerializeField] TextMeshProUGUI perSecondDisplay;

    public static double moneyPerSecond = 1d;
    double oldPerSecond = moneyPerSecond;

    void Start()
    {

       
        if (File.Exists(Path.Combine(Application.persistentDataPath, "savetest.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "savetestcloud.k")))
        {

            perSecondData = SaveSystem.LoadPlayer();
            InputValues(perSecondData);

        }
        
        perSecondDisplay.text = MainButtonClick.functions.FormatNumber(moneyPerSecond) + "/s";
        StartPSecondCoroutine();
        
    }

    void InputValues(PlayerData data)
    {

        moneyPerSecond = data.saveMoneyPerSecond;

    }

    // Show money per sencond on screen

    void Update()
    {
        if(oldPerSecond != moneyPerSecond)
        {

            perSecondDisplay.text = MainButtonClick.functions.FormatNumber(moneyPerSecond) + "/s";

            oldPerSecond = moneyPerSecond;

        }
        

    }

    // Coroutine to make the money go one by one

    void StartPSecondCoroutine()
    {

        StartCoroutine(PSecond());

    }

    IEnumerator PSecond()
    {

        for(; ; )
        {

            if(moneyPerSecond > 20)
            {

                double aux = moneyPerSecond / 20d;

                GlobalMoney.moneyCount += aux;
                yield return new WaitForSeconds(0.05f);

            }

            else
            {

                double time = 1d / moneyPerSecond;

                GlobalMoney.moneyCount += 1;
                yield return new WaitForSeconds(Convert.ToSingle(time));

            }

        }

    }

 

}