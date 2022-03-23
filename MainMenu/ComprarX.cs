using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComprarX : MonoBehaviour
{

    public static ComprarX function;

    public Button comprarButton;
    public TextMeshProUGUI comprarButtonName;
    public static int HoldMultiplier = 0;

    public Sprite comprar_button_gold;
    public Sprite comprar_button;

    [SerializeField] public Image[] buildButtonsImg = new Image[12];
    [SerializeField] public Image[] upgradeButtonsImg = new Image[9];

    [SerializeField] TextMeshProUGUI[] buildingMultiply = new TextMeshProUGUI[11];
    [SerializeField] TextMeshProUGUI upgradeMultiply;

    void Start()
    {

        function = this;

    }

    //Misc functions

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

                newValue += valuePSecond * (2f * 3d);
                valuePSecond *= 2d;

            }


        }

        newValue += valuePSecond * (2f * 3d);

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

            newCost += 3f * (fixedCost * Power(multiplier, (currentAmountA + aux)));
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

    //Change button functions


    public void ComprarMultiplier()
    {

        if (HoldMultiplier == 0)
        {

            for(int i = 0; i < buildingMultiply.Length; i++)
            {

                buildingMultiply[i].text = "x10";

            }

            upgradeMultiply.text = "x10";

            for (int i = 0; i < 12; i++)
            {

                if (i != 8 && i != 9 && i != 10 && i != 11)
                {

                    buildButtonsImg[i].sprite = comprar_button_gold;

                }

            }

            upgradeButtonsImg[0].sprite = comprar_button_gold;

            comprarButtonName.text = "Comprar 10x";

            // Upgrade

            UpgradeButtonBehaviour.marsUpgradeCost[0] = CostTimesTen(40d, 1.15d, UpgradeButtonBehaviour.currentAmountUpgradeA[0]) + (3 * (40d * Power(1.15d, (UpgradeButtonBehaviour.currentAmountUpgradeA[0] + 9))));

            UpgradeButtonBehaviour.clickNumber *= UpgradeButtonBehaviour.clickCheck ? 2d : (2d * 3d);


            // Building

            BuildButtonBehaviour.marsBuildCost[0] = CostTimesTen(40d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[0]) + (3 * (40d * Power(1.1d, (BuildButtonBehaviour.currentAmountBuildA[0] + 9))));
            BuildButtonBehaviour.marsBuildCost[1] = CostTimesTen(240d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[1]) + (3 * (240d * Power(1.1d, (BuildButtonBehaviour.currentAmountBuildA[1] + 9))));
            BuildButtonBehaviour.marsBuildCost[2] = CostTimesTen(1200d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[2]) + (3 * (1200d * Power(1.1d, (BuildButtonBehaviour.currentAmountBuildA[2] + 9))));
            BuildButtonBehaviour.marsBuildCost[3] = CostTimesTen(7200d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[3]) + (3 * (7200d * Power(1.2d, (BuildButtonBehaviour.currentAmountBuildA[3] + 9))));
            BuildButtonBehaviour.marsBuildCost[4] = CostTimesTen(36000d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[4]) + (3 * (36000d * Power(1.2d, (BuildButtonBehaviour.currentAmountBuildA[4] + 9))));
            BuildButtonBehaviour.marsBuildCost[5] = CostTimesTen(216000d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[5]) + (3 * (216000d * Power(1.2d, (BuildButtonBehaviour.currentAmountBuildA[5] + 9))));
            BuildButtonBehaviour.marsBuildCost[6] = CostTimesTen(1080000d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[6]) + (3 * (1080000d * Power(1.3d, (BuildButtonBehaviour.currentAmountBuildA[6] + 9))));
            BuildButtonBehaviour.marsBuildCost[7] = CostTimesTen(6480000d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[7]) + (3 * (6480000d * Power(1.3d, (BuildButtonBehaviour.currentAmountBuildA[7] + 9))));

            BuildButtonBehaviour.marsAsteroidCost[0] = CostTimesTen(60d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[8]);
            BuildButtonBehaviour.marsAsteroidCost[1] = CostTimesTen(720d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[9]);
            BuildButtonBehaviour.marsAsteroidCost[2] = CostTimesTen(10000d, 1.5d, BuildButtonBehaviour.currentAmountBuildA[10]);

            BuildButtonBehaviour.marsAsteroidPoints[0] *= Power(1.2d, 9d);
            BuildButtonBehaviour.marsAsteroidPoints[1] *= Power(1.3d, 9d);
            BuildButtonBehaviour.marsAsteroidPoints[2] *= Power(1.5d, 9d);


            BuildButtonBehaviour.marsBuildPSecond[0] *= BuildButtonBehaviour.checkArray[0] ? (1.8d) : (1.8d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[1] *= BuildButtonBehaviour.checkArray[1] ? (1.8d) : (1.8d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[2] *= BuildButtonBehaviour.checkArray[2] ? (1.8d) : (1.8d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[3] *= BuildButtonBehaviour.checkArray[3] ? (2.2d) : (2.2d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[4] *= BuildButtonBehaviour.checkArray[4] ? (2.2d) : (2.2d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[5] *= BuildButtonBehaviour.checkArray[5] ? (2.6d) : (2.6d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[6] *= BuildButtonBehaviour.checkArray[6] ? (2.6d) : (2.6d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[7] *= BuildButtonBehaviour.checkArray[7] ? (3d) : (3d * 3d);

            HoldMultiplier += 1;

        }

        else if (HoldMultiplier == 1)
        {


            for (int i = 0; i < buildingMultiply.Length; i++)
            {

                buildingMultiply[i].text = "x100";

            }

            upgradeMultiply.text = "x100";

            comprarButtonName.text = "Comprar 100x";

            // Upgrade

            UpgradeButtonBehaviour.marsUpgradeCost[0] = CostTimesHundred(40d, 1.15d, UpgradeButtonBehaviour.currentAmountUpgradeA[0]) + BonucCostPerTen(40d, 1.15d, UpgradeButtonBehaviour.currentAmountUpgradeA[0]);

            UpgradeButtonBehaviour.clickNumber = (UpgradeButtonBehaviour.clickNumber / 6) * Power(2d, 10d) * (2f * 3d);


            // Building

            BuildButtonBehaviour.marsBuildCost[0] = CostTimesHundred(40d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[0]) + BonucCostPerTen(40d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[0]);
            BuildButtonBehaviour.marsBuildCost[1] = CostTimesHundred(240d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[1]) + BonucCostPerTen(240d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[1]);
            BuildButtonBehaviour.marsBuildCost[2] = CostTimesHundred(1200d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[2]) + BonucCostPerTen(1200d, 1.1d, BuildButtonBehaviour.currentAmountBuildA[2]);
            BuildButtonBehaviour.marsBuildCost[3] = CostTimesHundred(7200d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[3]) + BonucCostPerTen(7200d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[3]);
            BuildButtonBehaviour.marsBuildCost[4] = CostTimesHundred(36000d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[4]) + BonucCostPerTen(36000d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[4]);
            BuildButtonBehaviour.marsBuildCost[5] = CostTimesHundred(216000d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[5]) + BonucCostPerTen(216000d, 1.2d, BuildButtonBehaviour.currentAmountBuildA[5]);
            BuildButtonBehaviour.marsBuildCost[6] = CostTimesHundred(1080000d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[6]) + BonucCostPerTen(1080000d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[6]);
            BuildButtonBehaviour.marsBuildCost[7] = CostTimesHundred(6480000d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[7]) + BonucCostPerTen(6480000d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[7]);

            BuildButtonBehaviour.marsAsteroidCost[0] = CostTimesHundred(60d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[8]);
            BuildButtonBehaviour.marsAsteroidCost[1] = CostTimesHundred(720d, 1.3d, BuildButtonBehaviour.currentAmountBuildA[9]);
            BuildButtonBehaviour.marsAsteroidCost[2] = CostTimesHundred(10000d, 1.5d, BuildButtonBehaviour.currentAmountBuildA[10]);

            BuildButtonBehaviour.marsAsteroidPoints[0] = (BuildButtonBehaviour.marsAsteroidPoints[0] / Power(1.2d, 9d)) * Power(1.2d, 99d);
            BuildButtonBehaviour.marsAsteroidPoints[1] = (BuildButtonBehaviour.marsAsteroidPoints[1] / Power(1.3d, 9d)) * Power(1.3d, 99d);
            BuildButtonBehaviour.marsAsteroidPoints[2] = (BuildButtonBehaviour.marsAsteroidPoints[2] / Power(1.5d, 9d)) * Power(1.5d, 99d);


            BuildButtonBehaviour.marsBuildPSecond[0] = (BuildButtonBehaviour.marsBuildPSecond[0] / (1.8d * 3d)) * Power(1.8d, 9d) * (1.8d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[1] = (BuildButtonBehaviour.marsBuildPSecond[1] / (1.8d * 3d)) * Power(1.8d, 9d) * (1.8d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[2] = (BuildButtonBehaviour.marsBuildPSecond[2] / (1.8d * 3d)) * Power(1.8d, 9d) * (1.8d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[3] = (BuildButtonBehaviour.marsBuildPSecond[3] / (2.2d * 3d)) * Power(2.2d, 9d) * (2.2d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[4] = (BuildButtonBehaviour.marsBuildPSecond[4] / (2.2d * 3d)) * Power(2.2d, 9d) * (2.2d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[5] = (BuildButtonBehaviour.marsBuildPSecond[5] / (2.6d * 3d)) * Power(2.6d, 9d) * (2.6d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[6] = (BuildButtonBehaviour.marsBuildPSecond[6] / (2.6d * 3d)) * Power(2.6d, 9d) * (2.6d * 3d);
            BuildButtonBehaviour.marsBuildPSecond[7] = (BuildButtonBehaviour.marsBuildPSecond[7] / (3d * 3d)) * Power(3d, 9d) * (3d * 3d);


            HoldMultiplier += 1;

        }


        else if (HoldMultiplier == 2)
        {


            for (int i = 0; i < buildingMultiply.Length; i++)
            {

                buildingMultiply[i].text = "x1";

            }

            upgradeMultiply.text = "x1";

            for (int i = 0; i < 8; i++)
            {

                if (BuildButtonBehaviour.checkArray[i] == false)
                {

                    buildButtonsImg[i].sprite = comprar_button;

                }

            }


            if (UpgradeButtonBehaviour.clickCheck == false)
            {

                upgradeButtonsImg[0].sprite = comprar_button;

            }

            comprarButtonName.GetComponent<TextMeshProUGUI>().text = "Comprar 1x";

            //Upgrade

            UpgradeButtonBehaviour.clickNumber = UpgradeButtonBehaviour.clickCheck ? UpgradeButtonBehaviour.clickNumber / Power(2d, 10d) : UpgradeButtonBehaviour.clickNumber / (Power(2d, 10d) * (2f * 3d));

            if (UpgradeButtonBehaviour.clickCheck == true)
            {

                UpgradeButtonBehaviour.marsUpgradeCost[0] = 3 * (40f * Power(1.15d, (UpgradeButtonBehaviour.currentAmountUpgradeA[0] - 1)));

            }

            else
            {

                UpgradeButtonBehaviour.marsUpgradeCost[0] = 40f * Power(1.15d, UpgradeButtonBehaviour.currentAmountUpgradeA[0]);

            }


            BuildButtonBehaviour.marsAsteroidPoints[0] = BuildButtonBehaviour.marsAsteroidPoints[0] / Power(1.2d, 99d);
            BuildButtonBehaviour.marsAsteroidPoints[1] = BuildButtonBehaviour.marsAsteroidPoints[1] / Power(1.3d, 99d);
            BuildButtonBehaviour.marsAsteroidPoints[2] = BuildButtonBehaviour.marsAsteroidPoints[2] / Power(1.5d, 99d);


            //Building

            BuildButtonBehaviour.marsBuildPSecond[0] = BuildButtonBehaviour.checkArray[0] ? BuildButtonBehaviour.marsBuildPSecond[0] / Power(1.8d, 9d): BuildButtonBehaviour.marsBuildPSecond[0] / (Power(1.8d, 9d) * (1.8d * 3d));
            BuildButtonBehaviour.marsBuildPSecond[1] = BuildButtonBehaviour.checkArray[1] ? BuildButtonBehaviour.marsBuildPSecond[1] / Power(1.8d, 9d) : BuildButtonBehaviour.marsBuildPSecond[1] / (Power(1.8d, 9d) * (1.8d * 3d));
            BuildButtonBehaviour.marsBuildPSecond[2] = BuildButtonBehaviour.checkArray[2] ? BuildButtonBehaviour.marsBuildPSecond[2] / Power(1.8d, 9d) : BuildButtonBehaviour.marsBuildPSecond[2] / (Power(1.8d, 9d) * (1.8d * 3d));
            BuildButtonBehaviour.marsBuildPSecond[3] = BuildButtonBehaviour.checkArray[3] ? BuildButtonBehaviour.marsBuildPSecond[3] / Power(2.2d, 9d) : BuildButtonBehaviour.marsBuildPSecond[3] / (Power(2.2d, 9d) * (2.2d * 3d));
            BuildButtonBehaviour.marsBuildPSecond[4] = BuildButtonBehaviour.checkArray[4] ? BuildButtonBehaviour.marsBuildPSecond[4] / Power(2.2d, 9d) : BuildButtonBehaviour.marsBuildPSecond[4] / (Power(2.2d, 9d) * (2.2d * 3d));
            BuildButtonBehaviour.marsBuildPSecond[5] = BuildButtonBehaviour.checkArray[5] ? BuildButtonBehaviour.marsBuildPSecond[5] / Power(2.6d, 9d) : BuildButtonBehaviour.marsBuildPSecond[5] / (Power(2.6d, 9d) * (2.6d * 3d));
            BuildButtonBehaviour.marsBuildPSecond[6] = BuildButtonBehaviour.checkArray[6] ? BuildButtonBehaviour.marsBuildPSecond[6] / Power(2.6d, 9d) : BuildButtonBehaviour.marsBuildPSecond[6] / (Power(2.6d, 9d) * (2.6d * 3d));
            BuildButtonBehaviour.marsBuildPSecond[7] = BuildButtonBehaviour.checkArray[7] ? BuildButtonBehaviour.marsBuildPSecond[7] / Power(3d, 9d) : BuildButtonBehaviour.marsBuildPSecond[7] / (Power(3d, 9d) * (3d * 3d));

            if (BuildButtonBehaviour.checkArray[0] == true)
            {

                BuildButtonBehaviour.marsBuildCost[0] = 3 * (40f * Power(1.1d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[0] = 40f * Power(1.1d, BuildButtonBehaviour.currentAmountBuildA[0]);

            }

            if (BuildButtonBehaviour.checkArray[1] == true)
            {

                BuildButtonBehaviour.marsBuildCost[1] = 3 * (240f * Power(1.1d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[1] = 240f * Power(1.1d, BuildButtonBehaviour.currentAmountBuildA[1]);

            }

            if (BuildButtonBehaviour.checkArray[2] == true)
            {

                BuildButtonBehaviour.marsBuildCost[2] = 3 * (1200f * Power(1.1d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[2] = 1200f * Power(1.1d, BuildButtonBehaviour.currentAmountBuildA[2]);

            }

            if (BuildButtonBehaviour.checkArray[3] == true)
            {

                BuildButtonBehaviour.marsBuildCost[3] = 3 * (7200f * Power(1.2d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[3] = 7200f * Power(1.2d, BuildButtonBehaviour.currentAmountBuildA[3]);

            }

            if (BuildButtonBehaviour.checkArray[4] == true)
            {

                BuildButtonBehaviour.marsBuildCost[4] = 3 * (36000f * Power(1.2d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[4] = 36000f * Power(1.2d, BuildButtonBehaviour.currentAmountBuildA[4]);

            }

            if (BuildButtonBehaviour.checkArray[5] == true)
            {

                BuildButtonBehaviour.marsBuildCost[5] = 3 * (216000f * Power(1.2d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[5] = 216000f * Power(1.2d, BuildButtonBehaviour.currentAmountBuildA[5]);

            }

            if (BuildButtonBehaviour.checkArray[6] == true)
            {

                BuildButtonBehaviour.marsBuildCost[6] = 3 * (1080000f * Power(1.3d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[6] = 1080000f * Power(1.3d, BuildButtonBehaviour.currentAmountBuildA[6]);

            }

            if (BuildButtonBehaviour.checkArray[7] == true)
            {

                BuildButtonBehaviour.marsBuildCost[7] = 3 * (6480000f * Power(1.3d, (BuildButtonBehaviour.currentAmountBuildA[0] - 1)));

            }

            else
            {

                BuildButtonBehaviour.marsBuildCost[7] = 6480000f * Power(1.3d, BuildButtonBehaviour.currentAmountBuildA[7]);

            }


            BuildButtonBehaviour.marsAsteroidCost[0] = 60f * Power(1.3d, BuildButtonBehaviour.currentAmountBuildA[8]);
            BuildButtonBehaviour.marsAsteroidCost[1] = 720f * Power(1.3d, BuildButtonBehaviour.currentAmountBuildA[9]);
            BuildButtonBehaviour.marsAsteroidCost[2] = 10000f * Power(1.5d, BuildButtonBehaviour.currentAmountBuildA[10]);

            HoldMultiplier -= 2;

        }

        UpgradeButtonBehaviour.function.ReloadALL();

    }

}
