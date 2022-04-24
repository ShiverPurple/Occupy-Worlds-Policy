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

    void Start()
    {
        instance = this;
    }

    #region Main Methods

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

            UpgradeMenu.upgradeCosts[0] = CostTimesTen(40d, 1.135d, UpgradeMenu.currentAmountUpgradeA[0]) + (3 * (40d * Power(1.135d, (UpgradeMenu.currentAmountUpgradeA[0] + 9))));

            UpgradeMenu.additionalClickValue *= UpgradeMenu.doubleClickCost ? 2d : (2d * 3d);

            #endregion

            #region Build x10

            BuildMenu.buildCosts[0] = CostTimesTen(40d, 1.1d, BuildMenu.currentAmountBuildA[0]) + (3 * (40d * Power(1.1d, (BuildMenu.currentAmountBuildA[0] + 9))));
            BuildMenu.buildCosts[1] = CostTimesTen(240d, 1.1d, BuildMenu.currentAmountBuildA[1]) + (3 * (240d * Power(1.1d, (BuildMenu.currentAmountBuildA[1] + 9))));
            BuildMenu.buildCosts[2] = CostTimesTen(1200d, 1.1d, BuildMenu.currentAmountBuildA[2]) + (3 * (1200d * Power(1.1d, (BuildMenu.currentAmountBuildA[2] + 9))));
            BuildMenu.buildCosts[3] = CostTimesTen(7200d, 1.2d, BuildMenu.currentAmountBuildA[3]) + (3 * (7200d * Power(1.2d, (BuildMenu.currentAmountBuildA[3] + 9))));
            BuildMenu.buildCosts[4] = CostTimesTen(36000d, 1.2d, BuildMenu.currentAmountBuildA[4]) + (3 * (36000d * Power(1.2d, (BuildMenu.currentAmountBuildA[4] + 9))));
            BuildMenu.buildCosts[5] = CostTimesTen(216000d, 1.2d, BuildMenu.currentAmountBuildA[5]) + (3 * (216000d * Power(1.2d, (BuildMenu.currentAmountBuildA[5] + 9))));
            BuildMenu.buildCosts[6] = CostTimesTen(1080000d, 1.3d, BuildMenu.currentAmountBuildA[6]) + (3 * (1080000d * Power(1.3d, (BuildMenu.currentAmountBuildA[6] + 9))));
            BuildMenu.buildCosts[7] = CostTimesTen(6480000d, 1.3d, BuildMenu.currentAmountBuildA[7]) + (3 * (6480000d * Power(1.3d, (BuildMenu.currentAmountBuildA[7] + 9))));

            BuildMenu.asteroidCosts[0] = CostTimesTen(60d, 1.215d, BuildMenu.currentAmountBuildA[8]);
            BuildMenu.asteroidCosts[1] = CostTimesTen(540d, 1.32d, BuildMenu.currentAmountBuildA[9]);
            BuildMenu.asteroidCosts[2] = CostTimesTen(7200d, 1.5d, BuildMenu.currentAmountBuildA[10]);

            BuildMenu.tempAsteroidValues[0] *= Power(1.215d, 9d);
            BuildMenu.tempAsteroidValues[1] *= Power(1.32d, 9d);
            BuildMenu.tempAsteroidValues[2] *= Power(1.5d, 9d);


            BuildMenu.perSecondValues[0] *= BuildMenu.buildCheckArray[0] ? (1.9d) : (1.9d * 3d);
            BuildMenu.perSecondValues[1] *= BuildMenu.buildCheckArray[1] ? (1.9d) : (1.9d * 3d);
            BuildMenu.perSecondValues[2] *= BuildMenu.buildCheckArray[2] ? (1.9d) : (1.9d * 3d);
            BuildMenu.perSecondValues[3] *= BuildMenu.buildCheckArray[3] ? (2.3d) : (2.3d * 3d);
            BuildMenu.perSecondValues[4] *= BuildMenu.buildCheckArray[4] ? (2.3d) : (2.3d * 3d);
            BuildMenu.perSecondValues[5] *= BuildMenu.buildCheckArray[5] ? (2.7d) : (2.7d * 3d);
            BuildMenu.perSecondValues[6] *= BuildMenu.buildCheckArray[6] ? (2.7d) : (2.7d * 3d);
            BuildMenu.perSecondValues[7] *= BuildMenu.buildCheckArray[7] ? (3.1d) : (3.1d * 3d);

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

            UpgradeMenu.upgradeCosts[0] = CostTimesHundred(40d, 1.135d, UpgradeMenu.currentAmountUpgradeA[0]) + BonucCostPerTen(40d, 1.135d, UpgradeMenu.currentAmountUpgradeA[0]);

            UpgradeMenu.additionalClickValue = (UpgradeMenu.additionalClickValue / 6) * Power(2d, 10d) * (2f * 3d);

            #endregion

            #region Build x100

            BuildMenu.buildCosts[0] = CostTimesHundred(40d, 1.1d, BuildMenu.currentAmountBuildA[0]) + BonucCostPerTen(40d, 1.1d, BuildMenu.currentAmountBuildA[0]);
            BuildMenu.buildCosts[1] = CostTimesHundred(240d, 1.1d, BuildMenu.currentAmountBuildA[1]) + BonucCostPerTen(240d, 1.1d, BuildMenu.currentAmountBuildA[1]);
            BuildMenu.buildCosts[2] = CostTimesHundred(1200d, 1.1d, BuildMenu.currentAmountBuildA[2]) + BonucCostPerTen(1200d, 1.1d, BuildMenu.currentAmountBuildA[2]);
            BuildMenu.buildCosts[3] = CostTimesHundred(7200d, 1.2d, BuildMenu.currentAmountBuildA[3]) + BonucCostPerTen(7200d, 1.2d, BuildMenu.currentAmountBuildA[3]);
            BuildMenu.buildCosts[4] = CostTimesHundred(36000d, 1.2d, BuildMenu.currentAmountBuildA[4]) + BonucCostPerTen(36000d, 1.2d, BuildMenu.currentAmountBuildA[4]);
            BuildMenu.buildCosts[5] = CostTimesHundred(216000d, 1.2d, BuildMenu.currentAmountBuildA[5]) + BonucCostPerTen(216000d, 1.2d, BuildMenu.currentAmountBuildA[5]);
            BuildMenu.buildCosts[6] = CostTimesHundred(1080000d, 1.3d, BuildMenu.currentAmountBuildA[6]) + BonucCostPerTen(1080000d, 1.3d, BuildMenu.currentAmountBuildA[6]);
            BuildMenu.buildCosts[7] = CostTimesHundred(6480000d, 1.3d, BuildMenu.currentAmountBuildA[7]) + BonucCostPerTen(6480000d, 1.3d, BuildMenu.currentAmountBuildA[7]);

            BuildMenu.asteroidCosts[0] = CostTimesHundred(60d, 1.215d, BuildMenu.currentAmountBuildA[8]);
            BuildMenu.asteroidCosts[1] = CostTimesHundred(540d, 1.32d, BuildMenu.currentAmountBuildA[9]);
            BuildMenu.asteroidCosts[2] = CostTimesHundred(7200d, 1.5d, BuildMenu.currentAmountBuildA[10]);

            BuildMenu.tempAsteroidValues[0] = (BuildMenu.tempAsteroidValues[0] / Power(1.215d, 9d)) * Power(1.215d, 99d);
            BuildMenu.tempAsteroidValues[1] = (BuildMenu.tempAsteroidValues[1] / Power(1.32d, 9d)) * Power(1.32d, 99d);
            BuildMenu.tempAsteroidValues[2] = (BuildMenu.tempAsteroidValues[2] / Power(1.5d, 9d)) * Power(1.5d, 99d);

            BuildMenu.perSecondValues[0] = (BuildMenu.perSecondValues[0] / (1.9d * 3d)) * Power(1.9d, 9d) * (1.9d * 3d);
            BuildMenu.perSecondValues[1] = (BuildMenu.perSecondValues[1] / (1.9d * 3d)) * Power(1.9d, 9d) * (1.9d * 3d);
            BuildMenu.perSecondValues[2] = (BuildMenu.perSecondValues[2] / (1.9d * 3d)) * Power(1.9d, 9d) * (1.9d * 3d);
            BuildMenu.perSecondValues[3] = (BuildMenu.perSecondValues[3] / (2.3d * 3d)) * Power(2.3d, 9d) * (2.3d * 3d);
            BuildMenu.perSecondValues[4] = (BuildMenu.perSecondValues[4] / (2.3d * 3d)) * Power(2.3d, 9d) * (2.3d * 3d);
            BuildMenu.perSecondValues[5] = (BuildMenu.perSecondValues[5] / (2.7d * 3d)) * Power(2.7d, 9d) * (2.7d * 3d);
            BuildMenu.perSecondValues[6] = (BuildMenu.perSecondValues[6] / (2.7d * 3d)) * Power(2.7d, 9d) * (2.7d * 3d);
            BuildMenu.perSecondValues[7] = (BuildMenu.perSecondValues[7] / (3.1d * 3d)) * Power(3.1d, 9d) * (3.1d * 3d);

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

            UpgradeMenu.additionalClickValue = UpgradeMenu.doubleClickCost ? UpgradeMenu.additionalClickValue / Power(2d, 10d) : UpgradeMenu.additionalClickValue / (Power(2d, 10d) * (2f * 3d));

            if (UpgradeMenu.doubleClickCost == true)
            {
                UpgradeMenu.upgradeCosts[0] = 3 * (40d * Power(1.135d, (UpgradeMenu.currentAmountUpgradeA[0] - 1)));
            }
            else
            {
                UpgradeMenu.upgradeCosts[0] = 40d * Power(1.135d, UpgradeMenu.currentAmountUpgradeA[0]);
            }

            #endregion

            #region Build x1

            BuildMenu.tempAsteroidValues[0] = BuildMenu.tempAsteroidValues[0] / Power(1.215d, 99d);
            BuildMenu.tempAsteroidValues[1] = BuildMenu.tempAsteroidValues[1] / Power(1.32d, 99d);
            BuildMenu.tempAsteroidValues[2] = BuildMenu.tempAsteroidValues[2] / Power(1.5d, 99d);

            BuildMenu.perSecondValues[0] = BuildMenu.buildCheckArray[0] ? BuildMenu.perSecondValues[0] / Power(1.9d, 9d) : BuildMenu.perSecondValues[0] / (Power(1.9d, 9d) * (1.9d * 3d));
            BuildMenu.perSecondValues[1] = BuildMenu.buildCheckArray[1] ? BuildMenu.perSecondValues[1] / Power(1.9d, 9d) : BuildMenu.perSecondValues[1] / (Power(1.9d, 9d) * (1.9d * 3d));
            BuildMenu.perSecondValues[2] = BuildMenu.buildCheckArray[2] ? BuildMenu.perSecondValues[2] / Power(1.9d, 9d) : BuildMenu.perSecondValues[2] / (Power(1.9d, 9d) * (1.9d * 3d));
            BuildMenu.perSecondValues[3] = BuildMenu.buildCheckArray[3] ? BuildMenu.perSecondValues[3] / Power(2.3d, 9d) : BuildMenu.perSecondValues[3] / (Power(2.3d, 9d) * (2.3d * 3d));
            BuildMenu.perSecondValues[4] = BuildMenu.buildCheckArray[4] ? BuildMenu.perSecondValues[4] / Power(2.3d, 9d) : BuildMenu.perSecondValues[4] / (Power(2.3d, 9d) * (2.3d * 3d));
            BuildMenu.perSecondValues[5] = BuildMenu.buildCheckArray[5] ? BuildMenu.perSecondValues[5] / Power(2.7d, 9d) : BuildMenu.perSecondValues[5] / (Power(2.7d, 9d) * (2.7d * 3d));
            BuildMenu.perSecondValues[6] = BuildMenu.buildCheckArray[6] ? BuildMenu.perSecondValues[6] / Power(2.7d, 9d) : BuildMenu.perSecondValues[6] / (Power(2.7d, 9d) * (2.7d * 3d));
            BuildMenu.perSecondValues[7] = BuildMenu.buildCheckArray[7] ? BuildMenu.perSecondValues[7] / Power(3.1d, 9d) : BuildMenu.perSecondValues[7] / (Power(3.1d, 9d) * (3.1d * 3d));

            if (BuildMenu.buildCheckArray[0] == true)
            {
                BuildMenu.buildCosts[0] = 3 * (40d * Power(1.1d, (BuildMenu.currentAmountBuildA[0] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[0] = 40d * Power(1.1d, BuildMenu.currentAmountBuildA[0]);
            }

            if (BuildMenu.buildCheckArray[1] == true)
            {
                BuildMenu.buildCosts[1] = 3 * (240d * Power(1.1d, (BuildMenu.currentAmountBuildA[1] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[1] = 240d * Power(1.1d, BuildMenu.currentAmountBuildA[1]);
            }

            if (BuildMenu.buildCheckArray[2] == true)
            {
                BuildMenu.buildCosts[2] = 3 * (1200d * Power(1.1d, (BuildMenu.currentAmountBuildA[2] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[2] = 1200d * Power(1.1d, BuildMenu.currentAmountBuildA[2]);
            }

            if (BuildMenu.buildCheckArray[3] == true)
            {
                BuildMenu.buildCosts[3] = 3 * (7200d * Power(1.2d, (BuildMenu.currentAmountBuildA[3] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[3] = 7200d * Power(1.2d, BuildMenu.currentAmountBuildA[3]);
            }

            if (BuildMenu.buildCheckArray[4] == true)
            {
                BuildMenu.buildCosts[4] = 3 * (36000d * Power(1.2d, (BuildMenu.currentAmountBuildA[4] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[4] = 36000d * Power(1.2d, BuildMenu.currentAmountBuildA[4]);
            }

            if (BuildMenu.buildCheckArray[5] == true)
            {
                BuildMenu.buildCosts[5] = 3 * (216000d * Power(1.2d, (BuildMenu.currentAmountBuildA[5] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[5] = 216000d * Power(1.2d, BuildMenu.currentAmountBuildA[5]);
            }

            if (BuildMenu.buildCheckArray[6] == true)
            {
                BuildMenu.buildCosts[6] = 3 * (1080000d * Power(1.3d, (BuildMenu.currentAmountBuildA[6] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[6] = 1080000d * Power(1.3d, BuildMenu.currentAmountBuildA[6]);
            }

            if (BuildMenu.buildCheckArray[7] == true)
            {
                BuildMenu.buildCosts[7] = 3 * (6480000d * Power(1.3d, (BuildMenu.currentAmountBuildA[7] - 1)));
            }
            else
            {
                BuildMenu.buildCosts[7] = 6480000d * Power(1.3d, BuildMenu.currentAmountBuildA[7]);
            }

            BuildMenu.asteroidCosts[0] = 60d * Power(1.215d, BuildMenu.currentAmountBuildA[8]);
            BuildMenu.asteroidCosts[1] = 540d * Power(1.32d, BuildMenu.currentAmountBuildA[9]);
            BuildMenu.asteroidCosts[2] = 7200d * Power(1.5d, BuildMenu.currentAmountBuildA[10]);

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

        aux = fixedCost * Power(multiplier, (currentAmountA));
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

        aux = fixedCost * Power(multiplier, (currentAmountA));
        newCost += aux;

        while (counter > 0)
        {
            aux = aux * multiplier;
            newCost += aux;
            counter--;
        }

        return newCost;
    }

    public double BonucCostPerTen(double fixedCost, double multiplier, double currentAmountA)
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
