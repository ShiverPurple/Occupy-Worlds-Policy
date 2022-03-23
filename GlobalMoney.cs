using UnityEngine;
using TMPro;
using System;
using System.IO;

public class GlobalMoney : MonoBehaviour{

    // Save System
    
    public PlayerData globalMoneyData = new PlayerData();

    [SerializeField] TextMeshProUGUI moneyDisplay;

    public static double moneyCount = 0d;

    void Start()
    {

        if (File.Exists(Path.Combine(Application.persistentDataPath, "savetest.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "savetestcloud.k")))
        {

            globalMoneyData = SaveSystem.LoadPlayer();
            InputValues(globalMoneyData);

        }
      

    }

    // Show money amount

    void InputValues(PlayerData data)
    {

        moneyCount = data.saveMoneyCount;

    }

    void Update()
    {
        
        moneyDisplay.SetText("<sprite=12>" + MainButtonClick.functions.FormatNumber(moneyCount));

    }

}
