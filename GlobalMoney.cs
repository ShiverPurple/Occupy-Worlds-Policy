using UnityEngine;
using TMPro;
using System.IO;

public class GlobalMoney : MonoBehaviour
{

    #region Initialization / Declaration

    public PlayerData globalMoneyData = new PlayerData();

    [SerializeField] private TextMeshProUGUI moneyDisplay;

    public static double totalMoneyCount = 0d;
    public static double moneyCount = 0d;

    #endregion

    void Start()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
        {
            globalMoneyData = SaveSystem.LoadPlayer();
            InputValues(globalMoneyData);
        }
    }

    void InputValues(PlayerData data)
    {
        moneyCount = data.saveMoneyCount;
        totalMoneyCount = data.saveTotalMoneyCount;
    }

    void Update()
    {
        moneyDisplay.SetText("<sprite=12>" + MainClickButton.instance.FormatNumber(moneyCount));
    }

}
