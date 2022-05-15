using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComprarMultiple : MonoBehaviour
{

    #region Initialization / Declaration

    public static ComprarMultiple instance;

    [SerializeField] private Image[] buildMenuButtonImages = new Image[12];
    [SerializeField] private Image[] upgradeMenuButtonImages;

    [SerializeField] private TextMeshProUGUI[] buildMultipleBuy = new TextMeshProUGUI[11];
    [SerializeField] private TextMeshProUGUI upgradeMultipleBuy;

    [SerializeField] private TextMeshProUGUI comprarButtonText;

    [SerializeField] private Sprite comprar_button_gold;
    [SerializeField] private Sprite comprar_button;

    public static int holdMultiplier = 0;

    #endregion

    #region Display Values

    public static double[] tempBuildCosts = new double[8];
    public static double[] tempAsteroidCosts = new double[3];

    public static double[] tempPerSecondValues = new double[8];
    public static double[] tempAsteroidValues = new double[3];

    public static double tempUpgradeCosts = 40d;
    public static double tempAdditionalClickValue = 1d;

    private double perSecondMultiplier1 = 1.6d;
    private double perSecondMultiplier2 = 1.78d;
    private double perSecondMultiplier3 = 1.96d;
    private double perSecondMultiplier4 = 2.41d;
    private double perSecondMultiplier5 = 2.6d;
    private double perSecondMultiplier6 = 3.05d;
    private double perSecondMultiplier7 = 3.25d;
    private double perSecondMultiplier8 = 4.2d;

    private double asteroidCostMultiplier1 = 1.215d;
    private double asteroidCostMultiplier2 = 1.32d;
    private double asteroidCostMultiplier3 = 1.52d;

    private double asteroidValueMultiplier1 = 1.215d;
    private double asteroidValueMultiplier2 = 1.32d;
    private double asteroidValueMultiplier3 = 1.52d;

    private double fixBuildCost1 = 40d;
    private double fixBuildCost2 = 240d;
    private double fixBuildCost3 = 1400d;
    private double fixBuildCost4 = 8400d;
    private double fixBuildCost5 = 33600d;
    private double fixBuildCost6 = 168000d;
    private double fixBuildCost7 = 672000d;
    private double fixBuildCost8 = 2560000d;

    #endregion

    void Start()
    {
        instance = this;
        DisplayValueReload();
        UpgradeMenu.instance.ReloadALL();
        BuildMenu.instance.ReloadALL();
    }

    #region Main Methods

    public void DisplayValueReload()
    {
        tempAdditionalClickValue = UpgradeMenu.additionalClickValue;
        tempUpgradeCosts = UpgradeMenu.upgradeCosts[0];

        for(int i = 0; i < tempPerSecondValues.Length; i++)
        {
            tempBuildCosts[i] = BuildMenu.buildCosts[i];
            tempPerSecondValues[i] = BuildMenu.perSecondValues[i];
        }

        for (int i = 0; i < tempAsteroidCosts.Length; i++)
        {
            tempAsteroidCosts[i] = BuildMenu.asteroidCosts[i];
            tempAsteroidValues[i] = BuildMenu.asteroidValues[i];
        }
    }

    public void ComprarMultiplier()
    {
        if (holdMultiplier == 0)
        {
            for (int i = 0; i < buildMultipleBuy.Length; i++)
            {
                buildMultipleBuy[i].text = "x10";
            }

            upgradeMultipleBuy.text = "x10";

            for (int i = 0; i < 12; i++)
            {
                if (i != 8 && i != 9 && i != 10 && i != 11)
                {
                    buildMenuButtonImages[i].sprite = comprar_button_gold;
                }
            }

            upgradeMenuButtonImages[0].sprite = comprar_button_gold;

            comprarButtonText.text = "Comprar 10x";

            #region Upgrade x10

            tempUpgradeCosts = CostTimesTen(40d, 1.135d, UpgradeMenu.currentAmountUpgradeA[0]) + (3 * (40d * Power(1.135d, (UpgradeMenu.currentAmountUpgradeA[0] + 9))));

            tempAdditionalClickValue *= UpgradeMenu.doubleClickCost ? 2d : (2d * 3d);

            #endregion

            #region Build x10

            tempBuildCosts[0] = CostTimesTen(fixBuildCost1, 1.1d, BuildMenu.currentAmountBuildA[0]) + (3 * (fixBuildCost1 * Power(1.1d, (BuildMenu.currentAmountBuildA[0] + 9))));
            tempBuildCosts[1] = CostTimesTen(fixBuildCost2, 1.1d, BuildMenu.currentAmountBuildA[1]) + (3 * (fixBuildCost2 * Power(1.1d, (BuildMenu.currentAmountBuildA[1] + 9))));
            tempBuildCosts[2] = CostTimesTen(fixBuildCost3, 1.1d, BuildMenu.currentAmountBuildA[2]) + (3 * (fixBuildCost3 * Power(1.1d, (BuildMenu.currentAmountBuildA[2] + 9))));
            tempBuildCosts[3] = CostTimesTen(fixBuildCost4, 1.2d, BuildMenu.currentAmountBuildA[3]) + (3 * (fixBuildCost4 * Power(1.2d, (BuildMenu.currentAmountBuildA[3] + 9))));
            tempBuildCosts[4] = CostTimesTen(fixBuildCost5, 1.2d, BuildMenu.currentAmountBuildA[4]) + (3 * (fixBuildCost5 * Power(1.2d, (BuildMenu.currentAmountBuildA[4] + 9))));
            tempBuildCosts[5] = CostTimesTen(fixBuildCost6, 1.3d, BuildMenu.currentAmountBuildA[5]) + (3 * (fixBuildCost6 * Power(1.3d, (BuildMenu.currentAmountBuildA[5] + 9))));
            tempBuildCosts[6] = CostTimesTen(fixBuildCost7, 1.3d, BuildMenu.currentAmountBuildA[6]) + (3 * (fixBuildCost7 * Power(1.3d, (BuildMenu.currentAmountBuildA[6] + 9))));
            tempBuildCosts[7] = CostTimesTen(fixBuildCost8, 1.315d, BuildMenu.currentAmountBuildA[7]) + (3 * (fixBuildCost8 * Power(1.315d, (BuildMenu.currentAmountBuildA[7] + 9))));

            tempAsteroidCosts[0] = CostTimesTen(60d, 1.215d, BuildMenu.currentAmountBuildA[8]);
            tempAsteroidCosts[1] = CostTimesTen(540d, 1.32d, BuildMenu.currentAmountBuildA[9]);
            tempAsteroidCosts[2] = CostTimesTen(7200d, 1.52d, BuildMenu.currentAmountBuildA[10]);

            tempAsteroidValues[0] *= Power(1.215d, 10d);
            tempAsteroidValues[1] *= Power(1.32d, 10d);
            tempAsteroidValues[2] *= Power(1.52d, 10d);

            tempPerSecondValues[0] *= BuildMenu.buildCheckArray[0] ? (perSecondMultiplier1) : (perSecondMultiplier1 * 3d);
            tempPerSecondValues[1] *= BuildMenu.buildCheckArray[1] ? (perSecondMultiplier2) : (perSecondMultiplier2 * 3d);
            tempPerSecondValues[2] *= BuildMenu.buildCheckArray[2] ? (perSecondMultiplier3) : (perSecondMultiplier3 * 3d);
            tempPerSecondValues[3] *= BuildMenu.buildCheckArray[3] ? (perSecondMultiplier4) : (perSecondMultiplier4 * 3d);
            tempPerSecondValues[4] *= BuildMenu.buildCheckArray[4] ? (perSecondMultiplier5) : (perSecondMultiplier5 * 3d);
            tempPerSecondValues[5] *= BuildMenu.buildCheckArray[5] ? (perSecondMultiplier6) : (perSecondMultiplier6 * 3d);
            tempPerSecondValues[6] *= BuildMenu.buildCheckArray[6] ? (perSecondMultiplier7) : (perSecondMultiplier7 * 3d);
            tempPerSecondValues[7] *= BuildMenu.buildCheckArray[7] ? (perSecondMultiplier8) : (perSecondMultiplier8 * 3d);

            #endregion

            holdMultiplier += 1;
        }
        else if (holdMultiplier == 1)
        {
            for (int i = 0; i < buildMultipleBuy.Length; i++)
            {
                buildMultipleBuy[i].text = "x100";
            }

            upgradeMultipleBuy.text = "x100";

            comprarButtonText.text = "Comprar 100x";

            #region Upgrade x100

            tempUpgradeCosts = CostTimesHundred(40d, 1.135d, UpgradeMenu.currentAmountUpgradeA[0]) + BonusCostPerTen(40d, 1.135d, UpgradeMenu.currentAmountUpgradeA[0]);

            tempAdditionalClickValue = (tempAdditionalClickValue / 6) * (Power(2d, 10d) * 3d);

            #endregion

            #region Build x100

            tempBuildCosts[0] = CostTimesHundred(fixBuildCost1, 1.1d, BuildMenu.currentAmountBuildA[0]) + BonusCostPerTen(fixBuildCost1, 1.1d, BuildMenu.currentAmountBuildA[0]);
            tempBuildCosts[1] = CostTimesHundred(fixBuildCost2, 1.1d, BuildMenu.currentAmountBuildA[1]) + BonusCostPerTen(fixBuildCost2, 1.1d, BuildMenu.currentAmountBuildA[1]);
            tempBuildCosts[2] = CostTimesHundred(fixBuildCost3, 1.1d, BuildMenu.currentAmountBuildA[2]) + BonusCostPerTen(fixBuildCost3, 1.1d, BuildMenu.currentAmountBuildA[2]);
            tempBuildCosts[3] = CostTimesHundred(fixBuildCost4, 1.2d, BuildMenu.currentAmountBuildA[3]) + BonusCostPerTen(fixBuildCost4, 1.2d, BuildMenu.currentAmountBuildA[3]);
            tempBuildCosts[4] = CostTimesHundred(fixBuildCost5, 1.2d, BuildMenu.currentAmountBuildA[4]) + BonusCostPerTen(fixBuildCost5, 1.2d, BuildMenu.currentAmountBuildA[4]);
            tempBuildCosts[5] = CostTimesHundred(fixBuildCost6, 1.3d, BuildMenu.currentAmountBuildA[5]) + BonusCostPerTen(fixBuildCost6, 1.3d, BuildMenu.currentAmountBuildA[5]);
            tempBuildCosts[6] = CostTimesHundred(fixBuildCost7, 1.3d, BuildMenu.currentAmountBuildA[6]) + BonusCostPerTen(fixBuildCost7, 1.3d, BuildMenu.currentAmountBuildA[6]);
            tempBuildCosts[7] = CostTimesHundred(fixBuildCost8, 1.315d, BuildMenu.currentAmountBuildA[7]) + BonusCostPerTen(fixBuildCost8, 1.315d, BuildMenu.currentAmountBuildA[7]);

            tempAsteroidCosts[0] = CostTimesHundred(60d, 1.215d, BuildMenu.currentAmountBuildA[8]);
            tempAsteroidCosts[1] = CostTimesHundred(540d, 1.32d, BuildMenu.currentAmountBuildA[9]);
            tempAsteroidCosts[2] = CostTimesHundred(7200d, 1.52d, BuildMenu.currentAmountBuildA[10]);

            tempAsteroidValues[0] = (tempAsteroidValues[0] / Power(1.215d, 10d)) * Power(1.215d, 100d);
            tempAsteroidValues[1] = (tempAsteroidValues[1] / Power(1.32d, 10d)) * Power(1.32d, 100d);
            tempAsteroidValues[2] = (tempAsteroidValues[2] / Power(1.52d, 10d)) * Power(1.52d, 100d);

            tempPerSecondValues[0] = (tempPerSecondValues[0] / (perSecondMultiplier1 * 3d)) * (Power(perSecondMultiplier1, 10d) * 3d);
            tempPerSecondValues[1] = (tempPerSecondValues[1] / (perSecondMultiplier2 * 3d)) * (Power(perSecondMultiplier2, 10d) * 3d);
            tempPerSecondValues[2] = (tempPerSecondValues[2] / (perSecondMultiplier3 * 3d)) * (Power(perSecondMultiplier3, 10d) * 3d);
            tempPerSecondValues[3] = (tempPerSecondValues[3] / (perSecondMultiplier4 * 3d)) * (Power(perSecondMultiplier4, 10d) * 3d);
            tempPerSecondValues[4] = (tempPerSecondValues[4] / (perSecondMultiplier5 * 3d)) * (Power(perSecondMultiplier5, 10d) * 3d);
            tempPerSecondValues[5] = (tempPerSecondValues[5] / (perSecondMultiplier6 * 3d)) * (Power(perSecondMultiplier6, 10d) * 3d);
            tempPerSecondValues[6] = (tempPerSecondValues[6] / (perSecondMultiplier7 * 3d)) * (Power(perSecondMultiplier7, 10d) * 3d);
            tempPerSecondValues[7] = (tempPerSecondValues[7] / (perSecondMultiplier8 * 3d)) * (Power(perSecondMultiplier8, 10d)* 3d);

            #endregion

            holdMultiplier += 1;
        }
        else if (holdMultiplier == 2)
        {
            for (int i = 0; i < buildMultipleBuy.Length; i++)
            {
                buildMultipleBuy[i].text = "x1";
            }

            upgradeMultipleBuy.text = "x1";

            for (int i = 0; i < 8; i++)
            {
                if (BuildMenu.buildCheckArray[i] == false)
                {
                    buildMenuButtonImages[i].sprite = comprar_button;
                }
            }

            if (UpgradeMenu.doubleClickCost == false)
            {
                upgradeMenuButtonImages[0].sprite = comprar_button;
            }

            comprarButtonText.text = "Comprar 1x";

            #region Upgrade x1

            tempAdditionalClickValue = UpgradeMenu.doubleClickCost ? tempAdditionalClickValue / Power(2d, 10d) : tempAdditionalClickValue / (Power(2d, 10d) * 3d);

            if (UpgradeMenu.doubleClickCost == true)
            {
                tempUpgradeCosts = 3 * (40d * Power(1.135d, (UpgradeMenu.currentAmountUpgradeA[0] - 1)));
            }
            else
            {
                tempUpgradeCosts = 40d * Power(1.135d, UpgradeMenu.currentAmountUpgradeA[0]);
            }

            #endregion

            #region Build x1

            tempAsteroidValues[0] = tempAsteroidValues[0] / Power(1.215d, 100d);
            tempAsteroidValues[1] = tempAsteroidValues[1] / Power(1.32d, 100d);
            tempAsteroidValues[2] = tempAsteroidValues[2] / Power(1.52d, 100d);

            tempPerSecondValues[0] = BuildMenu.buildCheckArray[0] ? tempPerSecondValues[0] / Power(perSecondMultiplier1, 10d) : tempPerSecondValues[0] / (Power(perSecondMultiplier1, 10d) * 3d);
            tempPerSecondValues[1] = BuildMenu.buildCheckArray[1] ? tempPerSecondValues[1] / Power(perSecondMultiplier2, 10d) : tempPerSecondValues[1] / (Power(perSecondMultiplier2, 10d) * 3d);
            tempPerSecondValues[2] = BuildMenu.buildCheckArray[2] ? tempPerSecondValues[2] / Power(perSecondMultiplier3, 10d) : tempPerSecondValues[2] / (Power(perSecondMultiplier3, 10d) * 3d);
            tempPerSecondValues[3] = BuildMenu.buildCheckArray[3] ? tempPerSecondValues[3] / Power(perSecondMultiplier4, 10d) : tempPerSecondValues[3] / (Power(perSecondMultiplier4, 10d) * 3d);
            tempPerSecondValues[4] = BuildMenu.buildCheckArray[4] ? tempPerSecondValues[4] / Power(perSecondMultiplier5, 10d) : tempPerSecondValues[4] / (Power(perSecondMultiplier5, 10d) * 3d);
            tempPerSecondValues[5] = BuildMenu.buildCheckArray[5] ? tempPerSecondValues[5] / Power(perSecondMultiplier6, 10d) : tempPerSecondValues[5] / (Power(perSecondMultiplier6, 10d) * 3d);
            tempPerSecondValues[6] = BuildMenu.buildCheckArray[6] ? tempPerSecondValues[6] / Power(perSecondMultiplier7, 10d) : tempPerSecondValues[6] / (Power(perSecondMultiplier7, 10d) * 3d);
            tempPerSecondValues[7] = BuildMenu.buildCheckArray[7] ? tempPerSecondValues[7] / Power(perSecondMultiplier8, 10d) : tempPerSecondValues[7] / (Power(perSecondMultiplier8, 10d)* 3d);

            if (BuildMenu.buildCheckArray[0] == true)
            {
                tempBuildCosts[0] = 3 * (fixBuildCost1 * Power(1.1d, (BuildMenu.currentAmountBuildA[0] - 1)));
            }
            else
            {
                tempBuildCosts[0] = fixBuildCost1 * Power(1.1d, BuildMenu.currentAmountBuildA[0]);
            }

            if (BuildMenu.buildCheckArray[1] == true)
            {
                tempBuildCosts[1] = 3 * (fixBuildCost2 * Power(1.1d, (BuildMenu.currentAmountBuildA[1] - 1)));
            }
            else
            {
                tempBuildCosts[1] = fixBuildCost2 * Power(1.1d, BuildMenu.currentAmountBuildA[1]);
            }

            if (BuildMenu.buildCheckArray[2] == true)
            {
                tempBuildCosts[2] = 3 * (fixBuildCost3 * Power(1.1d, (BuildMenu.currentAmountBuildA[2] - 1)));
            }
            else
            {
                tempBuildCosts[2] = fixBuildCost3 * Power(1.1d, BuildMenu.currentAmountBuildA[2]);
            }

            if (BuildMenu.buildCheckArray[3] == true)
            {
                tempBuildCosts[3] = 3 * (fixBuildCost4 * Power(1.2d, (BuildMenu.currentAmountBuildA[3] - 1)));
            }
            else
            {
                tempBuildCosts[3] = fixBuildCost4 * Power(1.2d, BuildMenu.currentAmountBuildA[3]);
            }

            if (BuildMenu.buildCheckArray[4] == true)
            {
                tempBuildCosts[4] = 3 * (fixBuildCost5 * Power(1.2d, (BuildMenu.currentAmountBuildA[4] - 1)));
            }
            else
            {
                tempBuildCosts[4] = fixBuildCost5 * Power(1.2d, BuildMenu.currentAmountBuildA[4]);
            }

            if (BuildMenu.buildCheckArray[5] == true)
            {
                tempBuildCosts[5] = 3 * (fixBuildCost6 * Power(1.3d, (BuildMenu.currentAmountBuildA[5] - 1)));
            }
            else
            {
                tempBuildCosts[5] = fixBuildCost6 * Power(1.3d, BuildMenu.currentAmountBuildA[5]);
            }

            if (BuildMenu.buildCheckArray[6] == true)
            {
                tempBuildCosts[6] = 3 * (fixBuildCost7 * Power(1.3d, (BuildMenu.currentAmountBuildA[6] - 1)));
            }
            else
            {
                tempBuildCosts[6] = fixBuildCost7 * Power(1.3d, BuildMenu.currentAmountBuildA[6]);
            }

            if (BuildMenu.buildCheckArray[7] == true)
            {
                tempBuildCosts[7] = 3 * (fixBuildCost8 * Power(1.315d, (BuildMenu.currentAmountBuildA[7] - 1)));
            }
            else
            {
                tempBuildCosts[7] = fixBuildCost8 * Power(1.315d, BuildMenu.currentAmountBuildA[7]);
            }

            tempAsteroidCosts[0] = 60d * Power(1.215d, BuildMenu.currentAmountBuildA[8]);
            tempAsteroidCosts[1] = 540d * Power(1.32d, BuildMenu.currentAmountBuildA[9]);
            tempAsteroidCosts[2] = 7200d * Power(1.52d, BuildMenu.currentAmountBuildA[10]);

            #endregion

            holdMultiplier -= 2;
        }

        BuildMenu.instance.ReloadALL();
        UpgradeMenu.instance.ReloadALL();
    }

    //--------------------- Métodos Auxiliares de Matemática ---------------------//

    public double Power(double valor, double expoente)
    {
        double aux = valor;

        if (expoente == 0)
        {
            return 1d;
        }
        else if (expoente == 1)
        {
            return valor;
        }
        else
        {
            while (expoente > 1)
            {
                valor *= aux;
                expoente--;
            }

            return valor;
        }
    }

    public double HundredPS(double valuePSecond)
    {
        double newValue = 0;
        int i = 0;

        for (; i < 100; i++)
        {
            newValue += valuePSecond;

            if (i % 10 == 0)
            {
                newValue += valuePSecond * (2d * 3d);
                valuePSecond *= 2d;
            }
        }

        newValue += valuePSecond * (2d * 3d);

        return newValue;
    }

    public double CostTimesTen(double fixedCost, double multiplier, double currentAmountA)
    {
        double newCost = 0d;
        double aux;
        double counter = 9d;

        aux = fixedCost * Power(multiplier, currentAmountA);
        newCost += aux;

        while (counter > 0)
        {
            aux = aux * multiplier;
            newCost += aux;
            counter--;
        }

        return newCost;
    }

    public double CostTimesHundred(double fixedCost, double multiplier, double currentAmountA)
    {
        double newCost = 0d;
        double aux;
        double counter = 99d;

        aux = fixedCost * Power(multiplier, currentAmountA);
        newCost += aux;

        while (counter > 0)
        {
            aux = aux * multiplier;
            newCost += aux;
            counter--;
        }

        return newCost;
    }

    public double BonusCostPerTen(double fixedCost, double multiplier, double currentAmountA)
    {
        double newCost = 0d;
        double counter = 10d;
        double aux = 9d;

        while (counter > 0)
        {

            newCost += 3d * (fixedCost * Power(multiplier, (currentAmountA + aux)));
            aux += 10d;
            counter--;

        }

        return newCost;
    }

    public double ClickValuePerHundred(double clickValue)
    {
        double newValue = 0;
        int counter = 0;

        for (; counter < 100; counter++)
        {
            newValue += clickValue;

            if (counter % 10 == 0)
            {
                newValue += clickValue * (2d * 3d);
                clickValue *= 2d;
            }
        }

        newValue += clickValue * (2d * 3d);

        return newValue;
    }

    #endregion

}
