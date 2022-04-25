using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class BuildMenu : MonoBehaviour
{

    #region Initialization / Declaration

    public static BuildMenu instance;
    public PlayerData buildMenuData = new PlayerData();

    [SerializeField] private Button[] buildMenuButtons = new Button[12];

    [SerializeField] private TextMeshProUGUI[] asteroidCostDisplay = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[] buildCostDisplay = new TextMeshProUGUI[9];
    [SerializeField] private TextMeshProUGUI[] buildInfoDisplay = new TextMeshProUGUI[3];
    [SerializeField] private TextMeshProUGUI[] perSecondDisplay = new TextMeshProUGUI[8];
    [SerializeField] private TextMeshProUGUI[] currentAmountBuildDisplay = new TextMeshProUGUI[11];
    [SerializeField] private TextMeshProUGUI[] bonusAmountBuildDisplay = new TextMeshProUGUI[8];

    [SerializeField] private GameObject endingMessage;
    [SerializeField] private GameObject block;

    [SerializeField] private Sprite comprar_button_gold;
    [SerializeField] private Sprite comprar_button;

    public static double[] buildCosts = { 40d, 240d, 1200d, 7200d, 36000d, 216000d, 1080000d, 6480000d, 1000000000000d };
    public static double[] asteroidCosts = { 60d, 540d, 7200d };

    public static double[] perSecondValues = { 1d, 3d, 9d, 32d, 96d, 300d, 900d, 3200d };
    public static double[] asteroidValues = { 5d, 60d, 900d };
    public static double[] tempAsteroidValues = { 5d, 60d, 900d };

    public static int[] currentAmountBuildA = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] currentAmountBuildB = { 10, 10, 10, 10, 10, 10, 10, 10 };

    public static bool[] buildCheckArray = new bool[8];

    public static bool gameFinishedCheck = false;

    public static float timeToAsteroidT3 = 120f;

    private double buildCostMultiplier1 = 1.1d;
    private double buildCostMultiplier2 = 1.1d;
    private double buildCostMultiplier3 = 1.1d;
    private double buildCostMultiplier4 = 1.2d;
    private double buildCostMultiplier5 = 1.2d;
    private double buildCostMultiplier6 = 1.2d;
    private double buildCostMultiplier7 = 1.3d;
    private double buildCostMultiplier8 = 1.3d;

    private double perSecondMultiplier1 = 1.9d;
    private double perSecondMultiplier2 = 1.9d;
    private double perSecondMultiplier3 = 1.9d;
    private double perSecondMultiplier4 = 2.3d;
    private double perSecondMultiplier5 = 2.3d;
    private double perSecondMultiplier6 = 2.7d;
    private double perSecondMultiplier7 = 2.7d;
    private double perSecondMultiplier8 = 3.1d;

    private double asteroidCostMultiplier1 = 1.215d;
    private double asteroidCostMultiplier2 = 1.32d;
    private double asteroidCostMultiplier3 = 1.5d;

    private double asteroidValueMultiplier1 = 1.215d;
    private double asteroidValueMultiplier2 = 1.32d;
    private double asteroidValueMultiplier3 = 1.5d;

    private double fixBuildCost1 = 40d;
    private double fixBuildCost2 = 240d;
    private double fixBuildCost3 = 1200d;
    private double fixBuildCost4 = 7200d;
    private double fixBuildCost5 = 36000d;
    private double fixBuildCost6 = 216000d;
    private double fixBuildCost7 = 1080000d;
    private double fixBuildCost8 = 6480000d;

    private double fixAsteroidCost1 = 60d;
    private double fixAsteroidCost2 = 540d;
    private double fixAsteroidCost3 = 7200d;


    #endregion

    void Start()
    {
        instance = this;

        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
        {
            buildMenuData = SaveSystem.LoadPlayer();
            InputValues(buildMenuData);
        }

        #region Button Method Assignment

        buildMenuButtons[0].onClick.AddListener(delegate {
            PerSecondIncrease(0, buildCheckArray, 
            perSecondValues, 
            buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost1, 
            buildCostMultiplier1,
            perSecondMultiplier1); });

        buildMenuButtons[1].onClick.AddListener(delegate {
            PerSecondIncrease(1, buildCheckArray, 
            perSecondValues, 
            buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost2, 
            buildCostMultiplier2,
            perSecondMultiplier2); });

        buildMenuButtons[2].onClick.AddListener(delegate {
            PerSecondIncrease(2, buildCheckArray, 
            perSecondValues, 
            buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost3, 
            buildCostMultiplier3,
            perSecondMultiplier3); });

        buildMenuButtons[3].onClick.AddListener(delegate {
            PerSecondIncrease(3, buildCheckArray, 
            perSecondValues, 
            buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost4, 
            buildCostMultiplier4,
            perSecondMultiplier4); });

        buildMenuButtons[4].onClick.AddListener(delegate {
            PerSecondIncrease(4, buildCheckArray, 
            perSecondValues, buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost5, 
            buildCostMultiplier5,
            perSecondMultiplier5); });

        buildMenuButtons[5].onClick.AddListener(delegate {
            PerSecondIncrease(5, buildCheckArray, 
            perSecondValues, 
            buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost6, 
            buildCostMultiplier6,
            perSecondMultiplier6); });

        buildMenuButtons[6].onClick.AddListener(delegate {
            PerSecondIncrease(6, buildCheckArray, 
            perSecondValues, 
            buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost7, 
            buildCostMultiplier7,
            perSecondMultiplier7); });

        buildMenuButtons[7].onClick.AddListener(delegate {
            PerSecondIncrease(7, buildCheckArray, 
            perSecondValues, 
            buildCosts, 
            currentAmountBuildA, 
            currentAmountBuildB, 
            fixBuildCost8, 
            buildCostMultiplier8,
            perSecondMultiplier8); });
        

        buildMenuButtons[8].onClick.AddListener(delegate { 
            AsteroidValueIncrease(8, 0, currentAmountBuildA, 
            asteroidCosts, 
            asteroidValues,
            tempAsteroidValues,
            fixAsteroidCost1, 
            asteroidCostMultiplier1, 
            asteroidValueMultiplier1); });

        buildMenuButtons[9].onClick.AddListener(delegate {
            AsteroidValueIncrease(9, 1, currentAmountBuildA, 
            asteroidCosts, 
            asteroidValues,
            tempAsteroidValues,
            fixAsteroidCost2, 
            asteroidCostMultiplier2, 
            asteroidValueMultiplier2); });

        buildMenuButtons[10].onClick.AddListener(delegate {
            AsteroidValueIncrease(10, 2, currentAmountBuildA, 
            asteroidCosts, 
            asteroidValues,
            tempAsteroidValues,
            fixAsteroidCost3, 
            asteroidCostMultiplier3, 
            asteroidValueMultiplier3); });
        
        buildMenuButtons[11].onClick.AddListener(EndGame);

        #endregion

        ReloadALL();
    }

    void InputValues(PlayerData data)
    {
        gameFinishedCheck = data.saveGameFinishedCheck;

        timeToAsteroidT3 = data.saveTimeToAsteroidT3;

        buildCheckArray[0] = data.saveBuildCheckArray1;
        buildCheckArray[1] = data.saveBuildCheckArray2;
        buildCheckArray[2] = data.saveBuildCheckArray3;
        buildCheckArray[3] = data.saveBuildCheckArray4;
        buildCheckArray[4] = data.saveBuildCheckArray5;
        buildCheckArray[5] = data.saveBuildCheckArray6;
        buildCheckArray[6] = data.saveBuildCheckArray7;
        buildCheckArray[7] = data.saveBuildCheckArray8;

        asteroidCosts[0] = data.saveAsteroidCosts1;
        asteroidCosts[1] = data.saveAsteroidCosts2;
        asteroidCosts[2] = data.saveAsteroidCosts3;

        asteroidValues[0] = data.saveAsteroidValues1;
        asteroidValues[1] = data.saveAsteroidValues2;
        asteroidValues[2] = data.saveAsteroidValues3;

        tempAsteroidValues[0] = data.saveTempAsteroidValues1;
        tempAsteroidValues[1] = data.saveTempAsteroidValues2;
        tempAsteroidValues[2] = data.saveTempAsteroidValues3;

        buildCosts[0] = data.saveBuildCosts1;
        buildCosts[1] = data.saveBuildCosts2;
        buildCosts[2] = data.saveBuildCosts3;
        buildCosts[3] = data.saveBuildCosts4;
        buildCosts[4] = data.saveBuildCosts5;
        buildCosts[5] = data.saveBuildCosts6;
        buildCosts[6] = data.saveBuildCosts7;
        buildCosts[7] = data.saveBuildCosts8;
        buildCosts[8] = data.saveBuildCosts9;

        perSecondValues[0] = data.savePerSecondValues1;
        perSecondValues[1] = data.savePerSecondValues2;
        perSecondValues[2] = data.savePerSecondValues3;
        perSecondValues[3] = data.savePerSecondValues4;
        perSecondValues[4] = data.savePerSecondValues5;
        perSecondValues[5] = data.savePerSecondValues6;
        perSecondValues[6] = data.savePerSecondValues7;
        perSecondValues[7] = data.savePerSecondValues8;

        currentAmountBuildA[0] = data.saveCurrentAmountBuildA1;
        currentAmountBuildA[1] = data.saveCurrentAmountBuildA2;
        currentAmountBuildA[2] = data.saveCurrentAmountBuildA3;
        currentAmountBuildA[3] = data.saveCurrentAmountBuildA4;
        currentAmountBuildA[4] = data.saveCurrentAmountBuildA5;
        currentAmountBuildA[5] = data.saveCurrentAmountBuildA6;
        currentAmountBuildA[6] = data.saveCurrentAmountBuildA7;
        currentAmountBuildA[7] = data.saveCurrentAmountBuildA8;
        currentAmountBuildA[8] = data.saveCurrentAmountBuildA9;
        currentAmountBuildA[9] = data.saveCurrentAmountBuildA10;
        currentAmountBuildA[10] = data.saveCurrentAmountBuildA11;

        currentAmountBuildB[0] = data.saveCurrentAmountBuildB1;
        currentAmountBuildB[1] = data.saveCurrentAmountBuildB2;
        currentAmountBuildB[2] = data.saveCurrentAmountBuildB3;
        currentAmountBuildB[3] = data.saveCurrentAmountBuildB4;
        currentAmountBuildB[4] = data.saveCurrentAmountBuildB5;
        currentAmountBuildB[5] = data.saveCurrentAmountBuildB6;
        currentAmountBuildB[6] = data.saveCurrentAmountBuildB7;
        currentAmountBuildB[7] = data.saveCurrentAmountBuildB8;
    }

    #region Reload Methods

    public void ReloadALL()
    {
        for(int i = 0; i < 11; i++)
        {
            currentAmountBuildDisplay[i].text = currentAmountBuildA[i].ToString();
        }

        for(int i = 0; i < 8; i++)
        {
            bonusAmountBuildDisplay[i].SetText(currentAmountBuildA[i] + "/" + currentAmountBuildB[i]);
        }

        for(int i = 0; i < 9; i++)
        {
            buildCostDisplay[i].text = MainClickButton.instance.FormatNumber(buildCosts[i]);
        }

        for(int i = 0; i < 8; i++)
        {
            perSecondDisplay[i].SetText(MainClickButton.instance.FormatNumber(perSecondValues[i]) + "/s");
        }

        for (int i = 0; i < 3; i++)
        {
            asteroidCostDisplay[i].text = MainClickButton.instance.FormatNumber(asteroidCosts[i]);
            buildInfoDisplay[i].SetText("Valor atual do\nasteroide: " + MainClickButton.instance.FormatNumber(asteroidValues[i]));
        }
    }

    public void ReloadAmount(int objectNumber) 
    {
        currentAmountBuildDisplay[objectNumber].text = currentAmountBuildA[objectNumber].ToString();
    } 

    public void ReloadBonusAmount(int objectNumber)
    {
        bonusAmountBuildDisplay[objectNumber].SetText(currentAmountBuildA[objectNumber] + "/" + currentAmountBuildB[objectNumber]);
    }

    public void ReloadPSecond(int objectNumber)
    {
        perSecondDisplay[objectNumber].SetText(MainClickButton.instance.FormatNumber(perSecondValues[objectNumber]) + "/s");
    }

    public void ReloadCost(int objectNumber)
    {
        buildCostDisplay[objectNumber].text = MainClickButton.instance.FormatNumber(buildCosts[objectNumber]);
    }

    public void ReloadAsteroidCost(int objectNumber)
    {
        asteroidCostDisplay[objectNumber].text = MainClickButton.instance.FormatNumber(asteroidCosts[objectNumber]);
        buildInfoDisplay[objectNumber].SetText("Valor atual do\nasteroide: " + MainClickButton.instance.FormatNumber(asteroidValues[objectNumber]));
    }

    #endregion

    #region Main Methods

    void PerSecondIncrease(int objectNumber, 
        bool[] Check, 
        double[] marsPSecondValue, 
        double[] buildCosts, 
        int[] currentAmountA, 
        int[] currentAmountB, 
        double fixedMarsCost, 
        double costMultiply, 
        double pointMultiply) {

        if (buildCosts[objectNumber] <= GlobalMoney.moneyCount)
        {
            if (ComprarMultiple.holdMultiplier == 0)
            {
                if (Check[objectNumber] == true)
                {
                    PerSecond.moneyPerSecond += marsPSecondValue[objectNumber];
                    GlobalMoney.moneyCount -= buildCosts[objectNumber];

                    buildCosts[objectNumber] = buildCosts[objectNumber] / 3d;
                    marsPSecondValue[objectNumber] = marsPSecondValue[objectNumber] / 3d;
                    buildCosts[objectNumber] *= costMultiply;

                    Check[objectNumber] = false;

                    buildMenuButtons[objectNumber].image.sprite = comprar_button;
                }
                else
                {
                    PerSecond.moneyPerSecond += marsPSecondValue[objectNumber];
                    GlobalMoney.moneyCount -= buildCosts[objectNumber];

                    currentAmountA[objectNumber] += 1;

                    if (currentAmountA[objectNumber] == currentAmountB[objectNumber])
                    {
                        buildCosts[objectNumber] *= 3d;
                        marsPSecondValue[objectNumber] *= (pointMultiply * 3d);
                        Check[objectNumber] = true;

                        buildMenuButtons[objectNumber].image.sprite = comprar_button_gold;
                    }
                    else
                    {
                        buildCosts[objectNumber] *= costMultiply;
                    }
                }

                if (currentAmountA[objectNumber] > currentAmountB[objectNumber])
                {
                    currentAmountB[objectNumber] += 10;
                }

            }
            else if (ComprarMultiple.holdMultiplier == 1)
            {
                marsPSecondValue[objectNumber] = marsPSecondValue[objectNumber] / (pointMultiply * 3d);

                GlobalMoney.moneyCount -= buildCosts[objectNumber];
                PerSecond.moneyPerSecond += (10d * marsPSecondValue[objectNumber]) + ((pointMultiply * 3d) * marsPSecondValue[objectNumber]);

                currentAmountA[objectNumber] += 10;
                buildCosts[objectNumber] = ComprarMultiple.instance.CostTimesTen(fixedMarsCost, costMultiply, currentAmountA[objectNumber]) + 
                    (3d * (fixedMarsCost * ComprarMultiple.instance.Power(costMultiply, (currentAmountA[objectNumber] + 9))));

                marsPSecondValue[objectNumber] *= (pointMultiply * (pointMultiply * 3d));

                Check[objectNumber] = false;

                currentAmountB[objectNumber] += 10;
            }
            else if (ComprarMultiple.holdMultiplier == 2)
            {
                marsPSecondValue[objectNumber] = marsPSecondValue[objectNumber] / (ComprarMultiple.instance.Power(pointMultiply, 9d) * (pointMultiply * 3d));

                GlobalMoney.moneyCount -= buildCosts[objectNumber];
                PerSecond.moneyPerSecond += ComprarMultiple.instance.HundredPS(marsPSecondValue[objectNumber]);

                currentAmountA[objectNumber] += 100;
                buildCosts[objectNumber] = ComprarMultiple.instance.CostTimesHundred(fixedMarsCost, costMultiply, currentAmountA[objectNumber]) + 
                    ComprarMultiple.instance.BonucCostPerTen(fixedMarsCost, costMultiply, currentAmountA[objectNumber]);
                marsPSecondValue[objectNumber] *= ComprarMultiple.instance.Power(ComprarMultiple.instance.Power(pointMultiply, 9d) * (pointMultiply * 3d), 2d);

                Check[objectNumber] = false;

                currentAmountB[objectNumber] += 100;
            }

            ReloadBonusAmount(objectNumber);
            ReloadPSecond(objectNumber);
            ReloadAmount(objectNumber);
            ReloadCost(objectNumber);
        }
    }

    void AsteroidValueIncrease(int objectNumber, 
        int asteroidNumber, 
        int[] currentAmountA, 
        double[] asteroidCosts, 
        double[] asteroidValues,
        double[] tempAsteroidValues,
        double fixedAsteroidCost, 
        double costMultiply,
        double meteorValueMultiply) {

        if (asteroidCosts[asteroidNumber] <= GlobalMoney.moneyCount)
        {
            if (ComprarMultiple.holdMultiplier == 0)
            {

                GlobalMoney.moneyCount -= asteroidCosts[asteroidNumber];

                currentAmountA[objectNumber] += 1;
                asteroidCosts[asteroidNumber] *= costMultiply;

                asteroidValues[asteroidNumber] *= meteorValueMultiply;
                tempAsteroidValues[asteroidNumber] *= meteorValueMultiply;
            }
            else if (ComprarMultiple.holdMultiplier == 1)
            {
                asteroidValues[asteroidNumber] = tempAsteroidValues[asteroidNumber];

                GlobalMoney.moneyCount -= asteroidCosts[asteroidNumber];

                currentAmountA[objectNumber] += 10;

                asteroidCosts[asteroidNumber] = ComprarMultiple.instance.CostTimesTen(fixedAsteroidCost, costMultiply, currentAmountA[objectNumber]);
                tempAsteroidValues[asteroidNumber] *= ComprarMultiple.instance.Power(meteorValueMultiply, 10d);

            }
            else if (ComprarMultiple.holdMultiplier == 2)
            {

                asteroidValues[asteroidNumber] = tempAsteroidValues[asteroidNumber];

                GlobalMoney.moneyCount -= asteroidCosts[asteroidNumber];

                currentAmountA[objectNumber] += 100;

                asteroidCosts[asteroidNumber] = ComprarMultiple.instance.CostTimesHundred(fixedAsteroidCost, costMultiply, currentAmountA[objectNumber]);
                tempAsteroidValues[asteroidNumber] *= ComprarMultiple.instance.Power(meteorValueMultiply, 100d);

            }

            ReloadAmount(objectNumber);
            ReloadAsteroidCost(asteroidNumber);
        }
    }

    void EndGame()
    {
        if(buildCosts[8] <= GlobalMoney.moneyCount)
        {
            endingMessage.SetActive(true);
            block.SetActive(true);
            gameFinishedCheck = true;
        }

    }

    public void CloseEnding()
    {
        endingMessage.SetActive(false);
        block.SetActive(false);
    }

    #endregion

}