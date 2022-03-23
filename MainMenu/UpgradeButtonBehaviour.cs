using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class UpgradeButtonBehaviour : MonoBehaviour
{

    public static UpgradeButtonBehaviour function;
    public PlayerData upgradeButtonData = new PlayerData();

    [SerializeField] private Button[] upgradeButtons = new Button[9];
    [SerializeField] private Image[] upgradeButtonsImg = new Image[9];

    double fixMultClick1 = 1.4d;
    double fixMultClick2 = 1.5d;

    public static bool clickCheck = false;

    public static bool overCheck1 = false;
    public static bool overCheck2 = false;

    public static bool tempCheck = false;
    public static bool bombOfClicksCheck = false;

    public static bool autoClickCheck = false;

    public static double clickNumber = 1d;

    public static double clickUpgradePercentDisplay1 = 0;
    public static double clickUpgradePercentDisplay2 = 0;

    public static double clickBombClicks = 100d;
    public static double clickBombTime = 1200d;
    public static double bombCountDown = 1200d;
    public static bool bombImageBool = false;

    public static double clickOffTime = 300d;
    public static double autoClickAddValue = 1d;

    public static double autoClickNumber = 0d;

    public static double[] marsUpgradeCost = { 40d, 20000d, 40000d, 60000d, 100000d, 400000d, 20000d, 30000d, 100000000d };
    public static int[] currentAmountUpgradeA = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] currentAmountUpgradeB = { 10 };

    [SerializeField] TextMeshProUGUI[] currentAmountUpgradeDisplay = new TextMeshProUGUI[9];
    [SerializeField] TextMeshProUGUI[] upgradeCostDisplay = new TextMeshProUGUI[9];
    [SerializeField] TextMeshProUGUI[] upgradeInfoDisplay = new TextMeshProUGUI[9];

    [SerializeField] TextMeshProUGUI bombTimeDisplay;

    [SerializeField] GameObject bombIcon;

    public Sprite comprar_button_gold;
    public Sprite comprar_button;
    public Sprite max_buy;


    void Start()
    {

        
        if (File.Exists(Path.Combine(Application.persistentDataPath, "savetest.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "savetestcloud.k")))
        {

            upgradeButtonData = SaveSystem.LoadPlayer();
            InputValues(upgradeButtonData);

        }
        

        function = this;

        upgradeButtons[0].onClick.AddListener(delegate { PointPerClickButton(0, marsUpgradeCost, currentAmountUpgradeA, currentAmountUpgradeB); });
        upgradeButtons[1].onClick.AddListener(delegate { MultiplyClickValue(1, marsUpgradeCost, currentAmountUpgradeA, fixMultClick1); });
        upgradeButtons[2].onClick.AddListener(delegate { MultiplyClickValue(2, marsUpgradeCost, currentAmountUpgradeA, fixMultClick2); });

        upgradeButtons[3].onClick.AddListener(delegate { ReduceT3Wait(3, marsUpgradeCost, currentAmountUpgradeA); });

        upgradeButtons[4].onClick.AddListener(delegate { BombOfClicks(4, marsUpgradeCost,  currentAmountUpgradeA); });
        upgradeButtons[5].onClick.AddListener(delegate { BombClickRemoveTime(5, marsUpgradeCost, currentAmountUpgradeA); });

        upgradeButtons[6].onClick.AddListener(delegate { AutoClickButton(6, marsUpgradeCost, currentAmountUpgradeA); });

        upgradeButtons[7].onClick.AddListener(delegate { OfflineClickButton(7, marsUpgradeCost,  currentAmountUpgradeA); });

        upgradeButtons[8].onClick.AddListener(delegate { DoubleEverything(8, marsUpgradeCost, currentAmountUpgradeA); });

        if(bombOfClicksCheck == true)
        {

            StartBombOfClicks();

        }

        if(autoClickCheck == true)
        {

            StartAutoClickCoroutine();

        }

        if(bombImageBool == true)
        {

            bombIcon.SetActive(true);

        }

        StartOffline();

        ReloadALL();

    }

    void InputValues(PlayerData data)
    {

        clickCheck = data.saveUpgradeClickCheck;

        overCheck1 = data.saveOverCheck1;
        overCheck2 = data.saveOverCheck2;

        tempCheck = data.saveTempCheck;
        bombOfClicksCheck = data.saveBombOfClicksCheck;

        autoClickCheck = data.saveAutoClickCheck;

        clickNumber = data.saveClickNumber;

        clickUpgradePercentDisplay1 = data.saveclickUpgradePercentDisplay1;
        clickUpgradePercentDisplay2 = data.saveclickUpgradePercentDisplay2;

        clickBombClicks = data.saveClickBombClicks;
        clickBombTime = data.saveClickBombTime;
        bombCountDown = data.saveBombCountDown;
        bombImageBool = data.saveBombImageBool;

        clickOffTime = data.saveClickOffTime;

        autoClickNumber = data.saveAutoClickNumber;

        marsUpgradeCost[0] = data.saveMarsUpgradeValue1;
        marsUpgradeCost[1] = data.saveMarsUpgradeValue2;
        marsUpgradeCost[2] = data.saveMarsUpgradeValue3;
        marsUpgradeCost[3] = data.saveMarsUpgradeValue4;
        marsUpgradeCost[4] = data.saveMarsUpgradeValue5;
        marsUpgradeCost[5] = data.saveMarsUpgradeValue6;
        marsUpgradeCost[6] = data.saveMarsUpgradeValue7;
        marsUpgradeCost[7] = data.saveMarsUpgradeValue8;
        marsUpgradeCost[8] = data.saveMarsUpgradeValue9;

        currentAmountUpgradeA[0] = data.saveUpgradeAmountNumberA1;
        currentAmountUpgradeA[1] = data.saveUpgradeAmountNumberA2;
        currentAmountUpgradeA[2] = data.saveUpgradeAmountNumberA3;
        currentAmountUpgradeA[3] = data.saveUpgradeAmountNumberA4;
        currentAmountUpgradeA[4] = data.saveUpgradeAmountNumberA5;
        currentAmountUpgradeA[5] = data.saveUpgradeAmountNumberA6;
        currentAmountUpgradeA[6] = data.saveUpgradeAmountNumberA7;
        currentAmountUpgradeA[7] = data.saveUpgradeAmountNumberA8;
        currentAmountUpgradeA[8] = data.saveUpgradeAmountNumberA9;

        currentAmountUpgradeB[0] = data.saveUpgradeAmountNumberB1;

    }

    // Misc Functions


    public void ReloadCost(int objectNumber)
    {

        upgradeCostDisplay[objectNumber].text = MainButtonClick.functions.FormatNumber(marsUpgradeCost[objectNumber]);

    }
    public void ReloadTotalAmount(int objectNumber)
    {

        if(objectNumber == 0)
        {

            currentAmountUpgradeDisplay[objectNumber].text = currentAmountUpgradeA[objectNumber] + "/" + currentAmountUpgradeB[objectNumber];

        }

        else {

            currentAmountUpgradeDisplay[objectNumber].text = currentAmountUpgradeA[objectNumber].ToString() ;

        }

    }
    public void ReloadDescriptions(int objectNumber)
    {

        switch (objectNumber)
        {

            case 0:
                upgradeInfoDisplay[objectNumber].text = "Click Adicional: " + MainButtonClick.functions.FormatNumber(clickNumber);
                break;
            case 1:
                upgradeInfoDisplay[objectNumber].text = "10% de Click adicional\nMultiplicador atual: " + clickUpgradePercentDisplay1 + "%";
                break;
            case 2:
                upgradeInfoDisplay[objectNumber].text = "20% de Click adicional\nMultiplicador atual: " + clickUpgradePercentDisplay2 + "%";
                break;
            case 3:
                upgradeInfoDisplay[objectNumber].text = "Diminuir a espera do Asteroide T3 para:" + (BuildButtonBehaviour.timeToAsteroidT3 - 2) + "s";
                break;
            case 4:
                upgradeInfoDisplay[objectNumber].text = "Bomba de " + clickBombClicks + "\nclicks em " + MainButtonClick.functions.FormatNumber(clickBombTime / 60d) + " min";
                break;
            case 5:
                upgradeInfoDisplay[objectNumber].text = "Diminuir tempo da\nbomba para: " + (MainButtonClick.functions.FormatNumber((clickBombTime - 20d) / 60d)) + "min";
                break;
            case 6:
                upgradeInfoDisplay[objectNumber].text = "Valor do Auto Click: " + MainButtonClick.functions.FormatNumber(MainButtonClick.clickValue / 10d);
                break;
            case 7:
                upgradeInfoDisplay[objectNumber].text = "Tempo de Auto Play\ncom o jogo fechado: " + MainButtonClick.functions.FormatNumber(clickOffTime / 60d);
                break;
            case 8:
                upgradeInfoDisplay[objectNumber].text = "Dobra Click e Click/s";
                break;

        }

    }

    public void ReloadALL()
    {

        for (int i = 0; i < 9; i++)
        {

            if (i == 0)
            {

                currentAmountUpgradeDisplay[i].text = currentAmountUpgradeA[i] + "/" + currentAmountUpgradeB[i];

            }

            else
            {

                currentAmountUpgradeDisplay[i].text = "" + currentAmountUpgradeA[i];

            }

        }

        for (int i = 0; i < 9; i++)
        {

            upgradeCostDisplay[i].text = MainButtonClick.functions.FormatNumber(marsUpgradeCost[i]);

        }

        for (int i = 0; i < 9; i++)
        {

            switch (i)
            {

                case 0:
                    upgradeInfoDisplay[i].text = "Click Adicional: " + MainButtonClick.functions.FormatNumber(clickNumber);
                    break;
                case 1:
                    upgradeInfoDisplay[i].text = "10% de Click adicional\nMultiplicador atual: " + clickUpgradePercentDisplay1 + "%";
                    break;
                case 2:
                    upgradeInfoDisplay[i].text = "20% de Click adicional\nMultiplicador atual: " + clickUpgradePercentDisplay2 + "%";
                    break;
                case 3:
                    upgradeInfoDisplay[i].text = "Diminuir a espera do Asteroide T3 para:" + (BuildButtonBehaviour.timeToAsteroidT3 - 2) + "s";
                    break;
                case 4:
                    upgradeInfoDisplay[i].text = "Bomba de " + clickBombClicks + "\nclicks em " + MainButtonClick.functions.FormatNumber(clickBombTime / 60d) + " min";
                    break;
                case 5:
                    upgradeInfoDisplay[i].text = "Diminuir tempo da\nbomba para: " + (MainButtonClick.functions.FormatNumber((clickBombTime - 20d) / 60d)) + "min";
                    break;
                case 6:
                    upgradeInfoDisplay[i].text = "Valor do Auto Click: " + MainButtonClick.functions.FormatNumber(MainButtonClick.clickValue / 10d);
                    break;
                case 7:
                    upgradeInfoDisplay[i].text = "Tempo de Auto Play\ncom o jogo fechado: " + MainButtonClick.functions.FormatNumber(clickOffTime / 60d);
                    break;
                case 8:
                    upgradeInfoDisplay[i].text = "Dobra Click e Click/s";
                    break;

            }

        }

    }

    // Função principal


    void PointPerClickButton(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA, int[] currentAmountUpgradeB )
    {

        if(marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount)
        {

            

            if (ComprarX.HoldMultiplier == 0)
            {

                if (clickCheck == true)
                {

                    GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
                    MainButtonClick.flatClickValue += clickNumber;
                    marsUpgradeCost[objectNumber] = marsUpgradeCost[objectNumber] / 3d;
                    clickNumber = clickNumber / 3d;
                    marsUpgradeCost[objectNumber] *= 1.15d;

                    clickCheck = false;

                    upgradeButtonsImg[objectNumber].sprite = comprar_button;

                }

                else
                {

                    GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
                    MainButtonClick.flatClickValue += clickNumber;

                    currentAmountUpgradeA[objectNumber] += 1;

                    if (currentAmountUpgradeA[objectNumber] == currentAmountUpgradeB[objectNumber])
                    {

                        marsUpgradeCost[objectNumber] *= 3d;
                        clickNumber *= (2d * 3d);
                        clickCheck = true;

                        upgradeButtonsImg[objectNumber].sprite = comprar_button_gold;

                    }

                    else
                    {

                        marsUpgradeCost[objectNumber] *= 1.15d;

                    }

                }

                if (currentAmountUpgradeA[objectNumber] > currentAmountUpgradeB[objectNumber])
                {

                    currentAmountUpgradeB[objectNumber] += 10;

                }

            }

            else if (ComprarX.HoldMultiplier == 1)
            {

                clickNumber = clickNumber / (2d * 3d);

                GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
                MainButtonClick.flatClickValue += (10d * clickNumber) + ((2d * 3d) * clickNumber);
                currentAmountUpgradeA[objectNumber] += 10;
                marsUpgradeCost[objectNumber] = ComprarX.function.CostTimesTen(40d, 1.15d, currentAmountUpgradeA[objectNumber]) + (3 * (40d * ComprarX.function.Power(1.15d, (currentAmountUpgradeA[objectNumber] + 9))));
                clickNumber *= (2d * (2d * 3d));

                clickCheck = false;

                currentAmountUpgradeB[objectNumber] += 10;

            }

            else if (ComprarX.HoldMultiplier == 2)
            {

                clickNumber = clickNumber / (ComprarX.function.Power(2d, 10d) * (2d * 3d));

                GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
                MainButtonClick.flatClickValue += ComprarX.function.ClickValuePerHundred(clickNumber);
                currentAmountUpgradeA[objectNumber] += 100;
                marsUpgradeCost[objectNumber] = ComprarX.function.CostTimesHundred(40d, 1.15d, currentAmountUpgradeA[objectNumber]) + ComprarX.function.BonucCostPerTen(40d, 1.15d, currentAmountUpgradeA[objectNumber]);
                clickNumber *= ComprarX.function.Power(2d, 10d) * ComprarX.function.Power(2d, 10d) * (2d * 3d);

                clickCheck = false;

                currentAmountUpgradeB[objectNumber] += 100;

            }

            ReloadALL();

        }

    }

    void MultiplyClickValue(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA, double fixMultiplier)
    {

        if (marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount)
        {

            

            GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
            marsUpgradeCost[objectNumber] *= 1.5d;

            currentAmountUpgradeA[objectNumber] += 1;

            if (objectNumber == 1)
            {

                clickUpgradePercentDisplay1 += 10;

            }

            if (objectNumber == 2)
            {

                clickUpgradePercentDisplay2 += 20;

            }

            MainButtonClick.clickValue = MainButtonClick.flatClickValue + (MainButtonClick.flatClickValue * (clickUpgradePercentDisplay1 / 100)) + (MainButtonClick.flatClickValue * (clickUpgradePercentDisplay2 / 100));

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

        }

    }

    void ReduceT3Wait(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA)
    {

        if (marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount && overCheck1 == false)
        {

            

            GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
            BuildButtonBehaviour.timeToAsteroidT3 -= 2f;
            marsUpgradeCost[objectNumber] *= 1.5d;

            currentAmountUpgradeA[objectNumber] += 1;

            if (BuildButtonBehaviour.timeToAsteroidT3 <= 22f)
            {

                upgradeButtonsImg[objectNumber].sprite = max_buy;
                overCheck1 = true;

            }

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

        }

    }

    void BombOfClicks(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA)
    {

        if(marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount)
        {

            

            if (bombOfClicksCheck == false)
            {

                StartBombOfClicks();
                bombIcon.SetActive(true);
                bombImageBool = true;

            }

            GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];

            if (currentAmountUpgradeA[objectNumber] >= 1)
            {

                clickBombClicks += 10d;

            }

            marsUpgradeCost[objectNumber] *= 1.4d;
            currentAmountUpgradeA[objectNumber] += 1;

            bombOfClicksCheck = true;

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

        }

    }

    void BombClickRemoveTime(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA)
    {

        if(marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount && overCheck2 == false)
        {

            

            GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];

            clickBombTime -= 20d;
            bombCountDown -= 20d;

            marsUpgradeCost[objectNumber] *= 1.5d;
            currentAmountUpgradeA[objectNumber] += 1;

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);

            if (clickBombTime <= 210d)
            {

                upgradeButtonsImg[objectNumber].sprite = max_buy;
                overCheck2 = true;

            }

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

        }
   
    }

    //Bomb Mechanics

    void StartBombOfClicks()
    {

        StartCoroutine(BombCoroutine());

    }

    IEnumerator BombCoroutine()
    {

        for(; ; )
        {

            while (bombCountDown >= 0)
            {

                bombTimeDisplay.SetText(Math.Floor(bombCountDown / 60d) + ":" + bombCountDown % 60d);

                yield return new WaitForSeconds(1f);

                bombCountDown -= 1d;

            }

            GlobalMoney.moneyCount += clickBombClicks * MainButtonClick.clickValue;
            bombCountDown = clickBombTime;

        }
  
    }



    // Função principal auto

    void OfflineClickButton(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA)
    {

        if(marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount)
        {

            

            GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
            currentAmountUpgradeA[objectNumber] += 1;
            marsUpgradeCost[objectNumber] *= 1.3d;
        
            clickOffTime *= 1.4d;

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

        }

    }

    void AutoClickButton(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA)
    {

        if (marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount)
        {

            

            GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
            autoClickNumber += 1d;
            marsUpgradeCost[objectNumber] *= 1.8d;

            if (autoClickCheck == false)
            {

                autoClickCheck = true;
                StartAutoClickCoroutine();

            }
     
            currentAmountUpgradeA[objectNumber] += 1;

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

        }

    }

    void DoubleEverything(int objectNumber, double[] marsUpgradeCost, int[] currentAmountUpgradeA) 
    {
        
        if(marsUpgradeCost[objectNumber] <= GlobalMoney.moneyCount)
        {

            

            GlobalMoney.moneyCount -= marsUpgradeCost[objectNumber];
            MainButtonClick.flatClickValue *= 2d;
            PerSecond.moneyPerSecond *= 2d;
            marsUpgradeCost[objectNumber] *= 3d;

            currentAmountUpgradeA[objectNumber] += 1;

            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

        }

    }

    // Auto Mechanics

    void StartAutoClickCoroutine()
    {

        StartCoroutine(AutoClickCoroutine());

    }

    IEnumerator AutoClickCoroutine()
    {

        for(; ; )
        {

            GlobalMoney.moneyCount += ((MainButtonClick.clickValue / 10d) * autoClickNumber);
            yield return new WaitForSeconds(1f);

        }

    }

    void StartOffline()
    {

     

        if (OfflineClick.timeGapResult > 0)
        {

            if (OfflineClick.timeGapResult >= clickOffTime)
            {

                GlobalMoney.moneyCount += clickOffTime * MainButtonClick.clickValue;
                OfflineClick.timeGapResult -= OfflineClick.timeGapResult;

            }

            else if (OfflineClick.timeGapResult < clickOffTime)
            {

                GlobalMoney.moneyCount += OfflineClick.timeGapResult * MainButtonClick.clickValue;

            }

        }


    }

}
