using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class UpgradeMenu : MonoBehaviour
{

    #region Initialization / Declaration

    public static UpgradeMenu instance;
    private PlayerData upgradeMenuData = new PlayerData();

    [SerializeField] private Button[] upgradeMenuButtons = new Button[9];

    [SerializeField] private TextMeshProUGUI[] currentAmountUpgradeDisplay = new TextMeshProUGUI[9];
    [SerializeField] private TextMeshProUGUI[] upgradeCostDisplay = new TextMeshProUGUI[9];
    [SerializeField] private TextMeshProUGUI[] upgradeInfoDisplay = new TextMeshProUGUI[9];

    [SerializeField] private TextMeshProUGUI bombTimeDisplay;
    [SerializeField] private GameObject bombIcon;

    [SerializeField] private GameObject welcomeBackPopUp;
    [SerializeField] private TextMeshProUGUI welcomeBackText;

    [SerializeField] private Sprite comprar_button_gold;
    [SerializeField] private Sprite comprar_button;
    [SerializeField] private Sprite comprar_max;

    public static double[] upgradeCosts = { 40d, 20000d, 40000d, 60000d, 100000d, 400000d, 20000d, 30000d, 100000000d };
    public static int[] currentAmountUpgradeA = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] currentAmountUpgradeB = { 10 };

    public static bool doubleClickCost = false;
    public static double additionalClickValue = 1d;

    public static bool exceededAmount1 = false;
    public static bool exceededAmount2 = false;
    public static bool exceededAmount3 = false;

    public static bool clickBombCheck = false;
    public static int activatedClickBombs = 0;

    public static double additionalClickPercent1 = 0;
    public static double additionalClickPercent2 = 0;

    public static double clickBombClicks = 100d;
    public static double clickBombCountDown = 1200d;
    public static double clickBombTime = 1200d;

    public static double clickOfflineTime = 300d;

    public static bool autoClickCheck = false;
    public static double autoClickValue = 0d;

    private double upgradeCostMultiplier1 = 1.3d;
    private double upgradeCostMultiplier2 = 1.5d;

    #endregion

    void Start()
    {
        instance = this;

        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
        {
            upgradeMenuData = SaveSystem.LoadPlayer();
            InputValues(upgradeMenuData);
        }

        #region Button Method Assignment

        upgradeMenuButtons[0].onClick.AddListener(delegate { PointPerClickButton(0, upgradeCosts, currentAmountUpgradeA, currentAmountUpgradeB); });
        upgradeMenuButtons[1].onClick.AddListener(delegate { MultiplyClickValue(1, upgradeCosts, currentAmountUpgradeA, upgradeCostMultiplier1); });
        upgradeMenuButtons[2].onClick.AddListener(delegate { MultiplyClickValue(2, upgradeCosts, currentAmountUpgradeA, upgradeCostMultiplier2); });

        upgradeMenuButtons[3].onClick.AddListener(delegate { ReduceT3Wait(3, upgradeCosts, currentAmountUpgradeA); });

        upgradeMenuButtons[4].onClick.AddListener(delegate { BombOfClicks(4, upgradeCosts,  currentAmountUpgradeA); });
        upgradeMenuButtons[5].onClick.AddListener(delegate { BombClickRemoveTime(5, upgradeCosts, currentAmountUpgradeA); });

        upgradeMenuButtons[6].onClick.AddListener(delegate { AutoClickButton(6, upgradeCosts, currentAmountUpgradeA); });

        upgradeMenuButtons[7].onClick.AddListener(delegate { OfflineClickButton(7, upgradeCosts,  currentAmountUpgradeA); });

        upgradeMenuButtons[8].onClick.AddListener(delegate { DoubleEverything(8, upgradeCosts, currentAmountUpgradeA); });

        #endregion

        if (clickBombCheck == true)
        {
            bombIcon.SetActive(true);
            bombTimeDisplay.gameObject.SetActive(true);
            StartBombOfClicks();
        }

        if(autoClickCheck == true)
        {
            StartAutoClickCoroutine();
        }

        StartOffline();
        ComprarMultiple.instance.DisplayValueReload();
        ReloadALL();
    }

    void InputValues(PlayerData data)
    {
        doubleClickCost = data.saveDoubleClickCost;

        exceededAmount1 = data.saveExceededAmount1;
        exceededAmount2 = data.saveExceededAmount2;
        exceededAmount3 = data.saveExceededAmount3;

        autoClickCheck = data.saveAutoClickCheck;
        autoClickValue = data.saveAutoClickValue;

        additionalClickValue = data.saveAdditionalClickValue;

        additionalClickPercent1 = data.saveAdditionalClickPercent1;
        additionalClickPercent2 = data.saveAdditionalClickPercent2;

        clickBombClicks = data.saveClickBombClicks;
        clickBombTime = data.saveClickBombTime;
        clickBombCountDown = data.saveClickBombCountDown;
        activatedClickBombs = data.saveActivatedClickBombs;
        clickBombCheck = data.saveClickBombCheck;

        clickOfflineTime = data.saveClickOfflineTime;

        upgradeCosts[0] = data.saveUpgradeCosts1;
        upgradeCosts[1] = data.saveUpgradeCosts2;
        upgradeCosts[2] = data.saveUpgradeCosts3;
        upgradeCosts[3] = data.saveUpgradeCosts4;
        upgradeCosts[4] = data.saveUpgradeCosts5;
        upgradeCosts[5] = data.saveUpgradeCosts6;
        upgradeCosts[6] = data.saveUpgradeCosts7;
        upgradeCosts[7] = data.saveUpgradeCosts8;
        upgradeCosts[8] = data.saveUpgradeCosts9;

        currentAmountUpgradeA[0] = data.saveCurrentAmountUpgradeA1;
        currentAmountUpgradeA[1] = data.saveCurrentAmountUpgradeA2;
        currentAmountUpgradeA[2] = data.saveCurrentAmountUpgradeA3;
        currentAmountUpgradeA[3] = data.saveCurrentAmountUpgradeA4;
        currentAmountUpgradeA[4] = data.saveCurrentAmountUpgradeA5;
        currentAmountUpgradeA[5] = data.saveCurrentAmountUpgradeA6;
        currentAmountUpgradeA[6] = data.saveCurrentAmountUpgradeA7;
        currentAmountUpgradeA[7] = data.saveCurrentAmountUpgradeA8;
        currentAmountUpgradeA[8] = data.saveCurrentAmountUpgradeA9;

        currentAmountUpgradeB[0] = data.saveCurrentAmountUpgradeB1;
    }

    #region Reload Methods

    public void ReloadCost(int objectNumber)
    {
        if(objectNumber == 0)
        {
            upgradeCostDisplay[objectNumber].text = MainClickButton.instance.FormatNumber(ComprarMultiple.tempUpgradeCosts);
        }
        else
        {
            upgradeCostDisplay[objectNumber].text = MainClickButton.instance.FormatNumber(upgradeCosts[objectNumber]);
        }
    }

    public void ReloadAmount(int objectNumber)
    {
        if(objectNumber == 0)
        {
            currentAmountUpgradeDisplay[objectNumber].SetText(currentAmountUpgradeA[objectNumber] + "/" + currentAmountUpgradeB[objectNumber]);
        }
        else 
        {
            currentAmountUpgradeDisplay[objectNumber].text = currentAmountUpgradeA[objectNumber].ToString();
        }
    }

    public void ReloadDescriptions(int objectNumber)
    {
        switch (objectNumber)
        {
            case 0:
                upgradeInfoDisplay[objectNumber].SetText("Click Adicional: " + MainClickButton.instance.FormatNumber(ComprarMultiple.tempAdditionalClickValue));
                break;
            case 1:
                upgradeInfoDisplay[objectNumber].SetText("10% de Click adicional\nMultiplicador atual: " + additionalClickPercent1 + "%");
                break;
            case 2:
                upgradeInfoDisplay[objectNumber].SetText("20% de Click adicional\nMultiplicador atual: " + additionalClickPercent2 + "%");
                break;
            case 3:
                upgradeInfoDisplay[objectNumber].SetText("Diminuir a espera do Asteroide T3 para: " + (BuildMenu.timeToAsteroidT3 - 2) + "s");
                break;
            case 4:
                upgradeInfoDisplay[objectNumber].SetText("Bomba de " + clickBombClicks + "\nclicks em " + MainClickButton.instance.FormatNumber(clickBombTime / 60d) + " min");
                break;
            case 5:
                upgradeInfoDisplay[objectNumber].SetText("Diminuir tempo da\nbomba para: " + (MainClickButton.instance.FormatNumber((clickBombTime - 20d) / 60d)) + " min");
                break;
            case 6:
                upgradeInfoDisplay[objectNumber].SetText("Valor do Auto Click: " + MainClickButton.instance.FormatNumber(MainClickButton.clickValue / 10d));
                break;
            case 7:
                if((clickOfflineTime / 60d) > 60d)
                    upgradeInfoDisplay[objectNumber].SetText("Tempo de Auto Play\ncom o jogo fechado: " + MainClickButton.instance.FormatNumber((clickOfflineTime / 60d) / 60d) + " h");
                else
                    upgradeInfoDisplay[objectNumber].SetText("Tempo de Auto Play\ncom o jogo fechado: " + MainClickButton.instance.FormatNumber(clickOfflineTime / 60d) + " min");
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
                currentAmountUpgradeDisplay[i].SetText(currentAmountUpgradeA[i] + "/" + currentAmountUpgradeB[i]);
            }
            else
            {
                currentAmountUpgradeDisplay[i].text = currentAmountUpgradeA[i].ToString();
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if(i == 0)
            {
                upgradeCostDisplay[i].text = MainClickButton.instance.FormatNumber(ComprarMultiple.tempUpgradeCosts);
            }
            else
            {
                upgradeCostDisplay[i].text = MainClickButton.instance.FormatNumber(upgradeCosts[i]);
            }
        }

        for (int i = 0; i < 9; i++)
        {
            switch (i)
            {
                case 0:
                    upgradeInfoDisplay[i].SetText("Click Adicional: " + MainClickButton.instance.FormatNumber(ComprarMultiple.tempAdditionalClickValue));
                    break;
                case 1:
                    upgradeInfoDisplay[i].SetText("10% de Click adicional\nMultiplicador atual: " + additionalClickPercent1 + "%");
                    break;
                case 2:
                    upgradeInfoDisplay[i].SetText("20% de Click adicional\nMultiplicador atual: " + additionalClickPercent2 + "%");
                    break;
                case 3:
                    upgradeInfoDisplay[i].SetText("Diminuir a espera do Asteroide T3 para: " + (BuildMenu.timeToAsteroidT3 - 2) + "s");
                    break;
                case 4:
                    upgradeInfoDisplay[i].SetText("Bomba de " + clickBombClicks + "\nclicks em " + MainClickButton.instance.FormatNumber(clickBombTime / 60d) + " min");
                    break;
                case 5:
                    upgradeInfoDisplay[i].SetText("Diminuir tempo da\nbomba para: " + (MainClickButton.instance.FormatNumber((clickBombTime - 20d) / 60d)) + " min");
                    break;
                case 6:
                    upgradeInfoDisplay[i].SetText("Valor do Auto Click: " + MainClickButton.instance.FormatNumber(MainClickButton.clickValue / 10d));
                    break;
                case 7:
                    if ((clickOfflineTime / 60d) > 60d)
                        upgradeInfoDisplay[i].SetText("Tempo de Auto Play\ncom o jogo fechado: " + MainClickButton.instance.FormatNumber((clickOfflineTime / 60d) / 60d) + " h");
                    else
                        upgradeInfoDisplay[i].SetText("Tempo de Auto Play\ncom o jogo fechado: " + MainClickButton.instance.FormatNumber(clickOfflineTime / 60d) + " min");
                    break;
                case 8:
                    upgradeInfoDisplay[i].SetText("Dobra Click e Click/s");
                    break;
            }
        }
    }

    #endregion

    #region Main Methods

    void PointPerClickButton(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA, int[] currentAmountUpgradeB )
    {
        if(ComprarMultiple.tempUpgradeCosts < GlobalMoney.moneyCount)
        {
            if (ComprarMultiple.holdMultiplier == 0)
            {
                upgradeCosts[objectNumber] = ComprarMultiple.tempUpgradeCosts;

                if (doubleClickCost == true)
                {
                    GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
                    MainClickButton.flatClickValue += additionalClickValue;

                    upgradeCosts[objectNumber] = upgradeCosts[objectNumber] / 3d;
                    additionalClickValue = additionalClickValue / 3d;
                    upgradeCosts[objectNumber] *= 1.135d;

                    doubleClickCost = false;

                    upgradeMenuButtons[objectNumber].image.sprite = comprar_button;
                }
                else
                {
                    GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
                    MainClickButton.flatClickValue += additionalClickValue;

                    currentAmountUpgradeA[objectNumber] += 1;

                    if (currentAmountUpgradeA[objectNumber] == currentAmountUpgradeB[objectNumber])
                    {
                        upgradeCosts[objectNumber] *= 3d;
                        additionalClickValue *= (2d * 3d);
                        doubleClickCost = true;

                        upgradeMenuButtons[objectNumber].image.sprite = comprar_button_gold;
                    }
                    else
                    {
                        upgradeCosts[objectNumber] *= 1.135d;
                    }

                }

                if (currentAmountUpgradeA[objectNumber] > currentAmountUpgradeB[objectNumber])
                {
                    currentAmountUpgradeB[objectNumber] += 10;
                }

                ComprarMultiple.tempUpgradeCosts = upgradeCosts[objectNumber];
                ComprarMultiple.tempAdditionalClickValue = additionalClickValue;
            }
            else if (ComprarMultiple.holdMultiplier == 1)
            {
                additionalClickValue = ComprarMultiple.tempAdditionalClickValue;
                additionalClickValue = additionalClickValue / (2d * 3d);
                upgradeCosts[objectNumber] = ComprarMultiple.tempUpgradeCosts;

                GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
                MainClickButton.flatClickValue += (10d * additionalClickValue) + ((2d * 3d) * additionalClickValue);

                additionalClickValue = additionalClickValue * 2d;

                currentAmountUpgradeA[objectNumber] += 10;

                ComprarMultiple.tempUpgradeCosts = ComprarMultiple.instance.CostTimesTen(40d, 1.135d, currentAmountUpgradeA[objectNumber]) + 
                    (3 * (40d * ComprarMultiple.instance.Power(1.135d, (currentAmountUpgradeA[objectNumber] + 9))));
                ComprarMultiple.tempAdditionalClickValue *= 2d;

                doubleClickCost = false;

                currentAmountUpgradeB[objectNumber] += 10;
            }
            else if (ComprarMultiple.holdMultiplier == 2)
            {
                additionalClickValue = ComprarMultiple.tempAdditionalClickValue;
                additionalClickValue = additionalClickValue / (ComprarMultiple.instance.Power(2d, 10d) * 3d);
                upgradeCosts[objectNumber] = ComprarMultiple.tempUpgradeCosts;

                GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
                MainClickButton.flatClickValue += ComprarMultiple.instance.ClickValuePerHundred(additionalClickValue);

                additionalClickValue = additionalClickValue * ComprarMultiple.instance.Power(2d, 10d);

                currentAmountUpgradeA[objectNumber] += 100;

                ComprarMultiple.tempUpgradeCosts = ComprarMultiple.instance.CostTimesHundred(40d, 1.135d, currentAmountUpgradeA[objectNumber]) + 
                    ComprarMultiple.instance.BonusCostPerTen(40d, 1.135d, currentAmountUpgradeA[objectNumber]);
                ComprarMultiple.tempAdditionalClickValue *= ComprarMultiple.instance.Power(2d, 10d);

                doubleClickCost = false;

                currentAmountUpgradeB[objectNumber] += 100;
            }

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);
            ReloadDescriptions(6);
        }
    }

    void MultiplyClickValue(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA, double fixMultiplier)
    {
        if (upgradeCosts[objectNumber] <= GlobalMoney.moneyCount)
        {
            GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
            upgradeCosts[objectNumber] *= fixMultiplier;

            currentAmountUpgradeA[objectNumber] += 1;

            if (objectNumber == 1)
            {
                additionalClickPercent1 += 10;
            }

            if (objectNumber == 2)
            {
                additionalClickPercent2 += 20;
            }

            MainClickButton.clickValue = MainClickButton.flatClickValue + (MainClickButton.flatClickValue * (additionalClickPercent1 / 100)) + (MainClickButton.flatClickValue * (additionalClickPercent2 / 100));

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);
            ReloadDescriptions(6);
        }
    }

    void ReduceT3Wait(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA)
    {
        if (upgradeCosts[objectNumber] <= GlobalMoney.moneyCount && exceededAmount1 == false)
        {
            GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
            BuildMenu.timeToAsteroidT3 -= 2f;
            upgradeCosts[objectNumber] *= 1.52d;

            currentAmountUpgradeA[objectNumber] += 1;

            if (BuildMenu.timeToAsteroidT3 <= 28f)
            {
                upgradeMenuButtons[objectNumber].image.sprite = comprar_max;
                exceededAmount1 = true;
                PlayerData.SaveToFile(upgradeMenuData);
            }

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);
        }
    }

    void DoubleEverything(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA)
    {
        if (upgradeCosts[objectNumber] <= GlobalMoney.moneyCount)
        {
            GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
            MainClickButton.flatClickValue *= 2d;
            PerSecond.moneyPerSecond *= 2d;
            upgradeCosts[objectNumber] *= 5d;

            currentAmountUpgradeA[objectNumber] += 1;

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);
        }
    }

    //--------------------- Bomba de Clicks ---------------------//

    void BombOfClicks(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA)
    {
        if(upgradeCosts[objectNumber] <= GlobalMoney.moneyCount)
        {
            if (clickBombCheck == false)
            {
                StartBombOfClicks();
                bombIcon.SetActive(true);
                bombTimeDisplay.gameObject.SetActive(true);
            }

            GlobalMoney.moneyCount -= upgradeCosts[objectNumber];

            if (currentAmountUpgradeA[objectNumber] >= 1)
            {
                clickBombClicks += 10d;
            }

            upgradeCosts[objectNumber] *= 1.36d;
            currentAmountUpgradeA[objectNumber] += 1;

            clickBombCheck = true;

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

            ReloadAmount(5);
            ReloadCost(5);
            ReloadDescriptions(5);
        }
    }

    void BombClickRemoveTime(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA)
    {
        if(upgradeCosts[objectNumber] <= GlobalMoney.moneyCount && exceededAmount2 == false)
        {
            GlobalMoney.moneyCount -= upgradeCosts[objectNumber];

            clickBombTime -= 20d;
            clickBombCountDown -= 20d;

            upgradeCosts[objectNumber] *= 1.46d;
            currentAmountUpgradeA[objectNumber] += 1;

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);

            if (clickBombTime <= 210d)
            {
                upgradeMenuButtons[objectNumber].image.sprite = comprar_max;
                exceededAmount2 = true;
                PlayerData.SaveToFile(upgradeMenuData);
            }

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);

            ReloadAmount(4);
            ReloadCost(4);
            ReloadDescriptions(4);
        }
    }

    void StartBombOfClicks()
    {
        StartCoroutine(BombCoroutine());
    }

    IEnumerator BombCoroutine()
    {
        while(true)
        {
            while (clickBombCountDown >= 0)
            {
                bombTimeDisplay.SetText(Math.Floor(clickBombCountDown / 60d) + ":" + clickBombCountDown % 60d);

                yield return new WaitForSeconds(1f);

                clickBombCountDown -= 1d;
            }

            GlobalMoney.moneyCount += clickBombClicks * MainClickButton.clickValue;
            GlobalMoney.totalMoneyCount += clickBombClicks * MainClickButton.clickValue;
            activatedClickBombs += 1;

            clickBombCountDown = clickBombTime;
        }
    }

    //--------------------- Click Offline ---------------------//

    void OfflineClickButton(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA)
    {
        if(upgradeCosts[objectNumber] <= GlobalMoney.moneyCount && exceededAmount3 == false)
        {
            GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
            currentAmountUpgradeA[objectNumber] += 1;
            upgradeCosts[objectNumber] *= 2.3d;
        
            clickOfflineTime *= 1.25d;

            if(currentAmountUpgradeA[objectNumber] >= 25)
            {
                upgradeMenuButtons[objectNumber].image.sprite = comprar_max;
                exceededAmount3 = true;
                PlayerData.SaveToFile(upgradeMenuData);
            }

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);
        }
    }
    
    void StartOffline()
    {
        if (OfflineClick.timeGapResult > 0)
        {
            welcomeBackPopUp.SetActive(true);
            welcomeBackText.gameObject.SetActive(true);

            if (OfflineClick.timeGapResult >= clickOfflineTime)
            {
                GlobalMoney.moneyCount += clickOfflineTime * MainClickButton.clickValue;
                GlobalMoney.totalMoneyCount += clickOfflineTime * MainClickButton.clickValue;

                OfflineClick.timeGapResult -= OfflineClick.timeGapResult;

                welcomeBackText.SetText("Você ganhou   <sprite=12>" +
                    MainClickButton.instance.FormatNumber(clickOfflineTime * MainClickButton.clickValue)
                    + " enquanto estava fora");
            }
            else if (OfflineClick.timeGapResult < clickOfflineTime)
            {
                GlobalMoney.moneyCount += OfflineClick.timeGapResult * MainClickButton.clickValue;
                GlobalMoney.totalMoneyCount += OfflineClick.timeGapResult * MainClickButton.clickValue;

                welcomeBackText.SetText("Você ganhou   <sprite=12>" +
                    MainClickButton.instance.FormatNumber(OfflineClick.timeGapResult * MainClickButton.clickValue)
                    + " enquanto estava fora");
            }
        }
    }

    public void CloseWelcomeMessage()
    {
        welcomeBackPopUp.SetActive(false);
        welcomeBackText.gameObject.SetActive(false);
    }

    //--------------------- Auto Click ---------------------//

    void AutoClickButton(int objectNumber, double[] upgradeCosts, int[] currentAmountUpgradeA)
    {
        if (upgradeCosts[objectNumber] <= GlobalMoney.moneyCount)
        {
            GlobalMoney.moneyCount -= upgradeCosts[objectNumber];
            autoClickValue += 1d;
            upgradeCosts[objectNumber] *= 2.2d;

            if (autoClickCheck == false)
            {
                autoClickCheck = true;
                StartAutoClickCoroutine();
            }
     
            currentAmountUpgradeA[objectNumber] += 1;

            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
            ReloadDescriptions(objectNumber);
        }
    }

    void StartAutoClickCoroutine()
    {
        StartCoroutine(AutoClickCoroutine());
    }

    IEnumerator AutoClickCoroutine()
    {
        while (true)
        {
            GlobalMoney.moneyCount += ((MainClickButton.clickValue / 10d) * autoClickValue);
            GlobalMoney.totalMoneyCount += ((MainClickButton.clickValue / 10d) * autoClickValue);

            yield return new WaitForSeconds(1f);
        }
    }

    #endregion

}
