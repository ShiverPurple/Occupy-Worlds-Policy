using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class PerSecond : MonoBehaviour{

    #region Initialization / Declaration

    public PlayerData perSecondData = new PlayerData();

    [SerializeField] private TextMeshProUGUI perSecondDisplay;

    public static double moneyPerSecond = 1d;
    private double oldPerSecond = moneyPerSecond;
    private double oldClick = 0d;
    private double oldAutoClick = 0d;

    #endregion

    void Start()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
        {
            perSecondData = SaveSystem.LoadPlayer();
            InputValues(perSecondData);
        }

        perSecondDisplay.SetText(MainClickButton.instance.FormatNumber(moneyPerSecond + (UpgradeMenu.autoClickValue * (MainClickButton.clickValue / 10d))) + "/s");

        StartPSecondCoroutine();
    }

    void InputValues(PlayerData data)
    {
        moneyPerSecond = data.saveMoneyPerSecond;
    }

    void Update()
    {
        if(oldPerSecond != moneyPerSecond || oldClick != MainClickButton.clickValue || oldAutoClick != UpgradeMenu.autoClickValue)
        {
            perSecondDisplay.SetText(MainClickButton.instance.FormatNumber(moneyPerSecond + (UpgradeMenu.autoClickValue * (MainClickButton.clickValue / 10d))) + "/s");

            oldPerSecond = moneyPerSecond;
            oldClick = MainClickButton.clickValue;
        }     
    }

    void StartPSecondCoroutine()
    {
        StartCoroutine(PSecond());
    }

    IEnumerator PSecond()
    {
        while(true)
        {
            if(moneyPerSecond > 20)
            {
                double aux = moneyPerSecond / 20d;

                GlobalMoney.moneyCount += aux;
                GlobalMoney.totalMoneyCount += aux;

                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                double time = 1d / moneyPerSecond;

                GlobalMoney.moneyCount += 1d;
                GlobalMoney.totalMoneyCount += 1d;

                yield return new WaitForSeconds(Convert.ToSingle(time));
            }
        }
    }

}