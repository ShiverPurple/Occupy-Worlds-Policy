using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class BuildButtonBehaviour : MonoBehaviour
{

    public BuildButtonBehaviour current;
    public PlayerData buildButtonData = new PlayerData();

    // Save System

    [SerializeField] private Button[] buildButtons = new Button[12];
    [SerializeField] private Image[] buildButtonsImg = new Image[12];

    public static bool[] checkArray = new bool[8];

    public static float timeToAsteroidT3 = 120f;

    double costBuildMult1 = 1.1d;
    double costBuildMult2 = 1.1d;
    double costBuildMult3 = 1.1d;
    double costBuildMult4 = 1.2d;
    double costBuildMult5 = 1.2d;
    double costBuildMult6 = 1.2d;
    double costBuildMult7 = 1.3d;
    double costBuildMult8 = 1.3d;


    double pointBuildMult1 = 1.8d;
    double pointBuildMult2 = 1.8d;
    double pointBuildMult3 = 1.8d;
    double pointBuildMult4 = 2.2d;
    double pointBuildMult5 = 2.2d;
    double pointBuildMult6 = 2.6d;
    double pointBuildMult7 = 2.6d;
    double pointBuildMult8 = 3d;


    double costAsteroidMult1 = 1.3d;
    double costAsteroidMult2 = 1.3d;
    double costAsteroidMult3 = 1.5d;

    double asteroidMult1 = 1.2d;
    double asteroidMult2 = 1.3d;
    double asteroidMult3 = 1.5d;

    double fixMarsBuildCost1 = 40d;
    double fixMarsBuildCost2 = 240d;
    double fixMarsBuildCost3 = 1200d;
    double fixMarsBuildCost4 = 7200d;
    double fixMarsBuildCost5 = 36000d;
    double fixMarsBuildCost6 = 216000d;
    double fixMarsBuildCost7 = 1080000d;
    double fixMarsBuildCost8 = 6480000d;

    double fixMarsAsteroidCost1 = 60d;
    double fixMarsAsteroidCost2 = 720d;
    double fixMarsAsteroidCost3 = 10000d;
     

    public static double[] marsBuildCost = { 40d, 240d, 1200d, 7200d, 36000d, 216000d, 1080000d, 6480000d, 1000000000000d };
    public static double[] marsAsteroidCost = { 60d, 720d, 10000d };
    public static double[] marsBuildPSecond = { 1d, 3d, 9d, 32d, 96d, 300d, 900d, 3200d };
    public static double[] marsAsteroidPoints = { 5d, 60d, 900d };


    public static int[] currentAmountBuildA = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] currentAmountBuildB = { 10, 10, 10, 10, 10, 10, 10, 10 };


    [SerializeField] private TextMeshProUGUI[] totalAmountBuildDisplay = new TextMeshProUGUI[11];
    [SerializeField] private TextMeshProUGUI[] bonusAmountBuildDisplay = new TextMeshProUGUI[8];
    [SerializeField] private TextMeshProUGUI[] buildCostDisplay = new TextMeshProUGUI[9];
    [SerializeField] private TextMeshProUGUI[] asteroidCostDisplay = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[] buildPSecondDisplay = new TextMeshProUGUI[8];

    [SerializeField] private TextMeshProUGUI[] buildInfoDisplay = new TextMeshProUGUI[3];

    [SerializeField] GameObject endingPanel;
    [SerializeField] GameObject block;


    //Retornar
    [SerializeField] Sprite comprar_button_gold;
    [SerializeField] Sprite comprar_button;

    void Start()
    {

        if (File.Exists(Path.Combine(Application.persistentDataPath, "savetest.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "savetestcloud.k")))
        {

            buildButtonData = SaveSystem.LoadPlayer();
            InputValues(buildButtonData);

        }
     

        buildButtons[0].onClick.AddListener(delegate { BuildButtonSection1(0, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost1, costBuildMult1, pointBuildMult1); });
        buildButtons[1].onClick.AddListener(delegate { BuildButtonSection1(1, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost2, costBuildMult2, pointBuildMult2); });
        buildButtons[2].onClick.AddListener(delegate { BuildButtonSection1(2, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost3, costBuildMult3, pointBuildMult3); });
        buildButtons[3].onClick.AddListener(delegate { BuildButtonSection1(3, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost4, costBuildMult4, pointBuildMult4); });
        buildButtons[4].onClick.AddListener(delegate { BuildButtonSection1(4, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost5, costBuildMult5, pointBuildMult5); });
        buildButtons[5].onClick.AddListener(delegate { BuildButtonSection1(5, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost6, costBuildMult6, pointBuildMult6); });
        buildButtons[6].onClick.AddListener(delegate { BuildButtonSection1(6, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost7, costBuildMult7, pointBuildMult7); });
        buildButtons[7].onClick.AddListener(delegate { BuildButtonSection1(7, checkArray, marsBuildPSecond, marsBuildCost, currentAmountBuildA, currentAmountBuildB, fixMarsBuildCost8, costBuildMult8, pointBuildMult8); });
        
        buildButtons[8].onClick.AddListener(delegate { BButtonSection2(8, 0, currentAmountBuildA, marsAsteroidCost, marsAsteroidPoints, fixMarsAsteroidCost1, costAsteroidMult1, asteroidMult1); });
        buildButtons[9].onClick.AddListener(delegate { BButtonSection2(9, 1, currentAmountBuildA, marsAsteroidCost, marsAsteroidPoints, fixMarsAsteroidCost2, costAsteroidMult2, asteroidMult2); });
        buildButtons[10].onClick.AddListener(delegate { BButtonSection2(10, 2, currentAmountBuildA, marsAsteroidCost, marsAsteroidPoints, fixMarsAsteroidCost3, costAsteroidMult3, asteroidMult3); });
        
        buildButtons[11].onClick.AddListener(MainBuildingBehaviour12);

        ReloadALL();

    }

    void InputValues(PlayerData data)
    {

        checkArray[0] = data.saveMarsBuildCheck1;
        checkArray[1] = data.saveMarsBuildCheck2;
        checkArray[2] = data.saveMarsBuildCheck3;
        checkArray[3] = data.saveMarsBuildCheck4;
        checkArray[4] = data.saveMarsBuildCheck5;
        checkArray[5] = data.saveMarsBuildCheck6;
        checkArray[6] = data.saveMarsBuildCheck7;
        checkArray[7] = data.saveMarsBuildCheck8;

        timeToAsteroidT3 = data.saveTimeToAsteroidT3;

        marsAsteroidCost[0] = data.saveMarsAsteroidCost1;
        marsAsteroidCost[1] = data.saveMarsAsteroidCost2;
        marsAsteroidCost[2] = data.saveMarsAsteroidCost3;

        marsAsteroidPoints[0] = data.saveAsteroidPoints1;
        marsAsteroidPoints[1] = data.saveAsteroidPoints2;
        marsAsteroidPoints[2] = data.saveAsteroidPoints3;

        marsBuildCost[0] = data.saveMarsColonyValue1;
        marsBuildCost[1] = data.saveMarsColonyValue2;
        marsBuildCost[2] = data.saveMarsColonyValue3;
        marsBuildCost[3] = data.saveMarsColonyValue4;
        marsBuildCost[4] = data.saveMarsColonyValue5;
        marsBuildCost[5] = data.saveMarsColonyValue6;
        marsBuildCost[6] = data.saveMarsColonyValue7;
        marsBuildCost[7] = data.saveMarsColonyValue8;
        marsBuildCost[8] = data.saveMarsColonyValue9;

        marsBuildPSecond[0] = data.saveMarsColonyPSecond1;
        marsBuildPSecond[1] = data.saveMarsColonyPSecond2;
        marsBuildPSecond[2] = data.saveMarsColonyPSecond3;
        marsBuildPSecond[3] = data.saveMarsColonyPSecond4;
        marsBuildPSecond[4] = data.saveMarsColonyPSecond5;
        marsBuildPSecond[5] = data.saveMarsColonyPSecond6;
        marsBuildPSecond[6] = data.saveMarsColonyPSecond7;
        marsBuildPSecond[7] = data.saveMarsColonyPSecond8;

        currentAmountBuildA[0] = data.saveAmountNumberA1;
        currentAmountBuildA[1] = data.saveAmountNumberA2;
        currentAmountBuildA[2] = data.saveAmountNumberA3;
        currentAmountBuildA[3] = data.saveAmountNumberA4;
        currentAmountBuildA[4] = data.saveAmountNumberA5;
        currentAmountBuildA[5] = data.saveAmountNumberA6;
        currentAmountBuildA[6] = data.saveAmountNumberA7;
        currentAmountBuildA[7] = data.saveAmountNumberA8;
        currentAmountBuildA[8] = data.saveAmountNumberA9;
        currentAmountBuildA[9] = data.saveAmountNumberA10;
        currentAmountBuildA[10] = data.saveAmountNumberA11;

        currentAmountBuildB[0] = data.saveAmountNumberB1;
        currentAmountBuildB[1] = data.saveAmountNumberB2;
        currentAmountBuildB[2] = data.saveAmountNumberB3;
        currentAmountBuildB[3] = data.saveAmountNumberB4;
        currentAmountBuildB[4] = data.saveAmountNumberB5;
        currentAmountBuildB[5] = data.saveAmountNumberB6;
        currentAmountBuildB[6] = data.saveAmountNumberB7;
        currentAmountBuildB[7] = data.saveAmountNumberB8;

    }


    // Reload functions

    public void ReloadALL()
    {

        for(int i = 0; i < 11; i++)
        {

            totalAmountBuildDisplay[i].text = currentAmountBuildA[i].ToString();

        }

        for(int i = 0; i < 8; i++)
        {

            bonusAmountBuildDisplay[i].text = currentAmountBuildA[i] + "/" + currentAmountBuildB[i];

        }

        for(int i = 0; i < 9; i++)
        {

            buildCostDisplay[i].text = MainButtonClick.functions.FormatNumber(marsBuildCost[i]);

        }

        for(int i = 0; i < 8; i++)
        {

            buildPSecondDisplay[i].text = MainButtonClick.functions.FormatNumber(marsBuildPSecond[i]) + "/s";

        }

        for (int i = 0; i < 3; i++)
        {

            asteroidCostDisplay[i].text = MainButtonClick.functions.FormatNumber(marsAsteroidCost[i]);
            buildInfoDisplay[i].text = "Valor atual\ndo asteroid: " + MainButtonClick.functions.FormatNumber(marsAsteroidPoints[i]);

        }


    }


    public void ReloadTotalAmount(int objectNumber) {

        totalAmountBuildDisplay[objectNumber].text = currentAmountBuildA[objectNumber].ToString();

    } 
    public void ReloadBonusAmount(int objectNumber)
    {

        bonusAmountBuildDisplay[objectNumber].text = currentAmountBuildA[objectNumber] + "/" + currentAmountBuildB[objectNumber];

    }
    public void ReloadPSecond(int objectNumber)
    {

        buildPSecondDisplay[objectNumber].text = MainButtonClick.functions.FormatNumber(marsBuildPSecond[objectNumber]) + "/s";

    }
    public void ReloadCost(int objectNumber)
    {

        buildCostDisplay[objectNumber].text = MainButtonClick.functions.FormatNumber(marsBuildCost[objectNumber]);

    }
    public void ReloadAsteroidCost(int objectNumber)
    {

        asteroidCostDisplay[objectNumber].text = MainButtonClick.functions.FormatNumber(marsAsteroidCost[objectNumber]);
        buildInfoDisplay[objectNumber].text = "Valor atual\ndo asteroid: " + MainButtonClick.functions.FormatNumber(marsAsteroidPoints[objectNumber]);

    }

    void BuildButtonSection1(int objectNumber, bool[] Check, double[] marsPSecondValue, double[] marsBuildCost, int[] currentAmountA, int[] currentAmountB, double fixedMarsCost, double costMultiply, double pointMultiply) {

        if (marsBuildCost[objectNumber] <= GlobalMoney.moneyCount)
        {

            if (ComprarX.HoldMultiplier == 0)
            {
                if (Check[objectNumber] == true)
                {

                    PerSecond.moneyPerSecond += marsPSecondValue[objectNumber];
                    GlobalMoney.moneyCount -= marsBuildCost[objectNumber];
                    marsBuildCost[objectNumber] = marsBuildCost[objectNumber] / 3d;
                    marsPSecondValue[objectNumber] = marsPSecondValue[objectNumber] / 3d;
                    marsBuildCost[objectNumber] *= costMultiply;

                    Check[objectNumber] = false;

                    buildButtonsImg[objectNumber].sprite = comprar_button;

                }

                else
                {

                    PerSecond.moneyPerSecond += marsPSecondValue[objectNumber];
                    GlobalMoney.moneyCount -= marsBuildCost[objectNumber];

                    currentAmountA[objectNumber] += 1;

                    if (currentAmountA[objectNumber] == currentAmountB[objectNumber])
                    {

                        marsBuildCost[objectNumber] *= 3d;
                        marsPSecondValue[objectNumber] *= (pointMultiply * 3d);
                        Check[objectNumber] = true;

                        buildButtonsImg[objectNumber].sprite = comprar_button_gold;

                    }

                    else
                    {

                        marsBuildCost[objectNumber] *= costMultiply;

                    }

                }

                if (currentAmountA[objectNumber] > currentAmountB[objectNumber])
                {

                    currentAmountB[objectNumber] += 10;

                }

            }

            else if (ComprarX.HoldMultiplier == 1)
            {

                marsPSecondValue[objectNumber] = marsPSecondValue[objectNumber] / (pointMultiply * 3d);

                GlobalMoney.moneyCount -= marsBuildCost[objectNumber];
                PerSecond.moneyPerSecond += (10d * marsPSecondValue[objectNumber]) + ((pointMultiply * 3d) * marsPSecondValue[objectNumber]);
                currentAmountA[objectNumber] += 10;
                marsBuildCost[objectNumber] = ComprarX.function.CostTimesTen(fixedMarsCost, costMultiply, currentAmountA[objectNumber]) + (3d * (fixedMarsCost * ComprarX.function.Power(costMultiply, (currentAmountA[objectNumber] + 9))));
                marsPSecondValue[objectNumber] *= (pointMultiply * (pointMultiply * 3d));

                Check[objectNumber] = false;

                currentAmountB[objectNumber] += 10;

            }


            else if (ComprarX.HoldMultiplier == 2)
            {

                marsPSecondValue[objectNumber] = marsPSecondValue[objectNumber] / (ComprarX.function.Power(pointMultiply, 9d) * (pointMultiply * 3d));

                GlobalMoney.moneyCount -= marsBuildCost[objectNumber];
                PerSecond.moneyPerSecond += ComprarX.function.HundredPS(marsPSecondValue[objectNumber]);
                currentAmountA[objectNumber] += 100;
                marsBuildCost[objectNumber] = ComprarX.function.CostTimesHundred(fixedMarsCost, costMultiply, currentAmountA[objectNumber]) + ComprarX.function.BonucCostPerTen(fixedMarsCost, costMultiply, currentAmountA[objectNumber]);
                marsPSecondValue[objectNumber] *= ComprarX.function.Power(ComprarX.function.Power(pointMultiply, 9d) * (pointMultiply * 3d), 2d);

                Check[objectNumber] = false;

                currentAmountB[objectNumber] += 100;

            }

            ReloadBonusAmount(objectNumber);
            ReloadPSecond(objectNumber);
            ReloadTotalAmount(objectNumber);
            ReloadCost(objectNumber);

        }

    }

    void BButtonSection2(int objectNumber, int asteroidNumber, int[] currentAmountA, double[] marsAsteroidCost, double[] marsAsteroidPoints, double fixedAsteroidCost, double costMultiply, double meteorValueMultiply) {

        if (marsAsteroidCost[asteroidNumber] <= GlobalMoney.moneyCount)
        {

            if (ComprarX.HoldMultiplier == 0)
            {

                GlobalMoney.moneyCount -= marsAsteroidCost[asteroidNumber];
                currentAmountA[objectNumber] += 1;
                marsAsteroidCost[asteroidNumber] *= costMultiply;

                marsAsteroidPoints[asteroidNumber] *= meteorValueMultiply;

            }

            else if (ComprarX.HoldMultiplier == 1)
            {

                marsAsteroidPoints[asteroidNumber] = marsAsteroidPoints[asteroidNumber] / ComprarX.function.Power(meteorValueMultiply, 9d);

                GlobalMoney.moneyCount -= marsAsteroidCost[asteroidNumber];
                currentAmountA[objectNumber] += 10;

                marsAsteroidCost[asteroidNumber] = ComprarX.function.CostTimesTen(fixedAsteroidCost, costMultiply, currentAmountA[objectNumber]);
                marsAsteroidPoints[asteroidNumber] *= ComprarX.function.Power(meteorValueMultiply, 9d) * ComprarX.function.Power(meteorValueMultiply, 9d);

            }

            else if (ComprarX.HoldMultiplier == 2)
            {

                marsAsteroidPoints[asteroidNumber] = marsAsteroidPoints[asteroidNumber] / ComprarX.function.Power(meteorValueMultiply, 99);

                GlobalMoney.moneyCount -= marsAsteroidCost[asteroidNumber];
                currentAmountA[objectNumber] += 100;

                marsAsteroidCost[asteroidNumber] = ComprarX.function.CostTimesHundred(fixedAsteroidCost, costMultiply, currentAmountA[objectNumber]);
                marsAsteroidPoints[asteroidNumber] *= ComprarX.function.Power(meteorValueMultiply, 99d) * ComprarX.function.Power(meteorValueMultiply, 99d);

            }

            ReloadTotalAmount(objectNumber);
            ReloadAsteroidCost(asteroidNumber);

        }

    }

    void MainBuildingBehaviour12()
    {
        if(marsBuildCost[8] <= GlobalMoney.moneyCount)
        {

            endingPanel.SetActive(true);
            block.SetActive(true);

        }

    }

    public void EndingClick()
    {

        endingPanel.SetActive(false);
        block.SetActive(false);

    }

}