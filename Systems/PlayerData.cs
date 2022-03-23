using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData 
{

    //SelectAsteroids

    public string saveCurrentIDT1;
    public string saveCurrentIDT2;
    public string saveCurrentIDT3;

    public string saveCurrentIDBrokenT1;
    public string saveCurrentIDBrokenT2;
    public string saveCurrentIDBrokenT3;

    //Doge

    public int save1SoldInt;
    public int save2SoldInt;
    public int save3SoldInt;

    //Building

    public bool saveMarsBuildCheck1;
    public bool saveMarsBuildCheck2;
    public bool saveMarsBuildCheck3;
    public bool saveMarsBuildCheck4;
    public bool saveMarsBuildCheck5;
    public bool saveMarsBuildCheck6;
    public bool saveMarsBuildCheck7;
    public bool saveMarsBuildCheck8;

    public float saveTimeToAsteroidT3;

    public double saveMarsAsteroidCost1;
    public double saveMarsAsteroidCost2;
    public double saveMarsAsteroidCost3;

    public double saveAsteroidPoints1;
    public double saveAsteroidPoints2;
    public double saveAsteroidPoints3;

    public double saveMarsColonyValue1;
    public double saveMarsColonyValue2;
    public double saveMarsColonyValue3;
    public double saveMarsColonyValue4;
    public double saveMarsColonyValue5;
    public double saveMarsColonyValue6;
    public double saveMarsColonyValue7;
    public double saveMarsColonyValue8;
    public double saveMarsColonyValue9;
    public double saveMarsColonyValue10;
    public double saveMarsColonyValue11;
    public double saveMarsColonyValue12;

    public double saveMarsColonyPSecond1;
    public double saveMarsColonyPSecond2;
    public double saveMarsColonyPSecond3;
    public double saveMarsColonyPSecond4;
    public double saveMarsColonyPSecond5;
    public double saveMarsColonyPSecond6;
    public double saveMarsColonyPSecond7;
    public double saveMarsColonyPSecond8;

    public int saveAmountNumberA1;
    public int saveAmountNumberA2;
    public int saveAmountNumberA3;
    public int saveAmountNumberA4;
    public int saveAmountNumberA5;
    public int saveAmountNumberA6;
    public int saveAmountNumberA7;
    public int saveAmountNumberA8;
    public int saveAmountNumberA9;
    public int saveAmountNumberA10;
    public int saveAmountNumberA11;

    public int saveAmountNumberB1;
    public int saveAmountNumberB2;
    public int saveAmountNumberB3;
    public int saveAmountNumberB4;
    public int saveAmountNumberB5;
    public int saveAmountNumberB6;
    public int saveAmountNumberB7;
    public int saveAmountNumberB8;

    public double savePerSecondSlider1;
    public double savePerSecondSlider2;
    public double savePerSecondSlider3;
    public double savePerSecondSlider4;
    public double savePerSecondSlider5;
    public double savePerSecondSlider6;
    public double savePerSecondSlider7;
    public double savePerSecondSlider8;

    //Upgrade
    public bool saveUpgradeClickCheck;

    public bool saveOverCheck1;
    public bool saveOverCheck2;

    public bool saveTempCheck;
    public bool saveBombOfClicksCheck;

    public bool saveAutoClickCheck;

    public double saveClickNumber;

    public double saveclickUpgradePercentDisplay1;
    public double saveclickUpgradePercentDisplay2;

    public double saveClickBombClicks;
    public double saveClickBombTime;
    public double saveBombCountDown;
    public bool saveBombImageBool;

    public double saveClickOffTime;

    public double saveAutoClickNumber;

    public double saveMarsUpgradeValue1;
    public double saveMarsUpgradeValue2;
    public double saveMarsUpgradeValue3;
    public double saveMarsUpgradeValue4;
    public double saveMarsUpgradeValue5;
    public double saveMarsUpgradeValue6;
    public double saveMarsUpgradeValue7;
    public double saveMarsUpgradeValue8;
    public double saveMarsUpgradeValue9;


    public int saveUpgradeAmountNumberA1;
    public int saveUpgradeAmountNumberA2;
    public int saveUpgradeAmountNumberA3;
    public int saveUpgradeAmountNumberA4;
    public int saveUpgradeAmountNumberA5;
    public int saveUpgradeAmountNumberA6;
    public int saveUpgradeAmountNumberA7;
    public int saveUpgradeAmountNumberA8;
    public int saveUpgradeAmountNumberA9;

    public int saveUpgradeAmountNumberB1;


    //PerSecond

    public double saveMoneyPerSecond;

    //MainButtonClick

    public double saveClickValue;
    public double saveFlatClickValue;

    //GlobalMoney

    public double saveMoneyCount;

    public static void GetValues(PlayerData data)
    {

        //BuildButtonBehaviour
        data.saveMarsBuildCheck1 = BuildButtonBehaviour.checkArray[0];
        data.saveMarsBuildCheck2 = BuildButtonBehaviour.checkArray[1];
        data.saveMarsBuildCheck3 = BuildButtonBehaviour.checkArray[2];
        data.saveMarsBuildCheck4 = BuildButtonBehaviour.checkArray[3];
        data.saveMarsBuildCheck5 = BuildButtonBehaviour.checkArray[4];
        data.saveMarsBuildCheck6 = BuildButtonBehaviour.checkArray[5];
        data.saveMarsBuildCheck7 = BuildButtonBehaviour.checkArray[6];
        data.saveMarsBuildCheck8 = BuildButtonBehaviour.checkArray[7];

        data.saveTimeToAsteroidT3 = BuildButtonBehaviour.timeToAsteroidT3;

        data.saveMarsAsteroidCost1 = BuildButtonBehaviour.marsAsteroidCost[0];
        data.saveMarsAsteroidCost2 = BuildButtonBehaviour.marsAsteroidCost[1];
        data.saveMarsAsteroidCost3 = BuildButtonBehaviour.marsAsteroidCost[2];

        data.saveAsteroidPoints1 = BuildButtonBehaviour.marsAsteroidPoints[0];
        data.saveAsteroidPoints2 = BuildButtonBehaviour.marsAsteroidPoints[1];
        data.saveAsteroidPoints3 = BuildButtonBehaviour.marsAsteroidPoints[2];

        data.saveMarsColonyValue1 = BuildButtonBehaviour.marsBuildCost[0];
        data.saveMarsColonyValue2 = BuildButtonBehaviour.marsBuildCost[1];
        data.saveMarsColonyValue3 = BuildButtonBehaviour.marsBuildCost[2];
        data.saveMarsColonyValue4 = BuildButtonBehaviour.marsBuildCost[3];
        data.saveMarsColonyValue5 = BuildButtonBehaviour.marsBuildCost[4];
        data.saveMarsColonyValue6 = BuildButtonBehaviour.marsBuildCost[5];
        data.saveMarsColonyValue7 = BuildButtonBehaviour.marsBuildCost[6];
        data.saveMarsColonyValue8 = BuildButtonBehaviour.marsBuildCost[7];
        data.saveMarsColonyValue9 = BuildButtonBehaviour.marsBuildCost[8];

        data.saveMarsColonyPSecond1 = BuildButtonBehaviour.marsBuildPSecond[0];
        data.saveMarsColonyPSecond2 = BuildButtonBehaviour.marsBuildPSecond[1];
        data.saveMarsColonyPSecond3 = BuildButtonBehaviour.marsBuildPSecond[2];
        data.saveMarsColonyPSecond4 = BuildButtonBehaviour.marsBuildPSecond[3];
        data.saveMarsColonyPSecond5 = BuildButtonBehaviour.marsBuildPSecond[4];
        data.saveMarsColonyPSecond6 = BuildButtonBehaviour.marsBuildPSecond[5];
        data.saveMarsColonyPSecond7 = BuildButtonBehaviour.marsBuildPSecond[6];
        data.saveMarsColonyPSecond8 = BuildButtonBehaviour.marsBuildPSecond[7];

        data.saveAmountNumberA1 = BuildButtonBehaviour.currentAmountBuildA[0];
        data.saveAmountNumberA2 = BuildButtonBehaviour.currentAmountBuildA[1];
        data.saveAmountNumberA3 = BuildButtonBehaviour.currentAmountBuildA[2];
        data.saveAmountNumberA4 = BuildButtonBehaviour.currentAmountBuildA[3];
        data.saveAmountNumberA5 = BuildButtonBehaviour.currentAmountBuildA[4];
        data.saveAmountNumberA6 = BuildButtonBehaviour.currentAmountBuildA[5];
        data.saveAmountNumberA7 = BuildButtonBehaviour.currentAmountBuildA[6];
        data.saveAmountNumberA8 = BuildButtonBehaviour.currentAmountBuildA[7];
        data.saveAmountNumberA9 = BuildButtonBehaviour.currentAmountBuildA[8];
        data.saveAmountNumberA10 = BuildButtonBehaviour.currentAmountBuildA[9];
        data.saveAmountNumberA11 = BuildButtonBehaviour.currentAmountBuildA[10];

        data.saveAmountNumberB1 = BuildButtonBehaviour.currentAmountBuildB[0];
        data.saveAmountNumberB2 = BuildButtonBehaviour.currentAmountBuildB[1];
        data.saveAmountNumberB3 = BuildButtonBehaviour.currentAmountBuildB[2];
        data.saveAmountNumberB4 = BuildButtonBehaviour.currentAmountBuildB[3];
        data.saveAmountNumberB5 = BuildButtonBehaviour.currentAmountBuildB[4];
        data.saveAmountNumberB6 = BuildButtonBehaviour.currentAmountBuildB[5];
        data.saveAmountNumberB7 = BuildButtonBehaviour.currentAmountBuildB[6];
        data.saveAmountNumberB8 = BuildButtonBehaviour.currentAmountBuildB[7];

        // UpgradeButtonBehaviour

        data.saveUpgradeClickCheck = UpgradeButtonBehaviour.clickCheck;

        data.saveOverCheck1 = UpgradeButtonBehaviour.overCheck1;
        data.saveOverCheck2 = UpgradeButtonBehaviour.overCheck2;

        data.saveTempCheck = UpgradeButtonBehaviour.tempCheck;
        data.saveBombOfClicksCheck = UpgradeButtonBehaviour.bombOfClicksCheck;

        data.saveAutoClickCheck = UpgradeButtonBehaviour.autoClickCheck;

        data.saveClickNumber = UpgradeButtonBehaviour.clickNumber;

        data.saveclickUpgradePercentDisplay1 = UpgradeButtonBehaviour.clickUpgradePercentDisplay1;
        data.saveclickUpgradePercentDisplay2 = UpgradeButtonBehaviour.clickUpgradePercentDisplay2;

        data.saveClickBombClicks = UpgradeButtonBehaviour.clickBombClicks;
        data.saveClickBombTime = UpgradeButtonBehaviour.clickBombTime;
        data.saveBombCountDown = UpgradeButtonBehaviour.bombCountDown;
        data.saveBombImageBool = UpgradeButtonBehaviour.bombImageBool;

        data.saveClickOffTime = UpgradeButtonBehaviour.clickOffTime;

        data.saveAutoClickNumber = UpgradeButtonBehaviour.autoClickNumber;

        data.saveMarsUpgradeValue1 = UpgradeButtonBehaviour.marsUpgradeCost[0];
        data.saveMarsUpgradeValue2 = UpgradeButtonBehaviour.marsUpgradeCost[1];
        data.saveMarsUpgradeValue3 = UpgradeButtonBehaviour.marsUpgradeCost[2];
        data.saveMarsUpgradeValue4 = UpgradeButtonBehaviour.marsUpgradeCost[3];
        data.saveMarsUpgradeValue5 = UpgradeButtonBehaviour.marsUpgradeCost[4];
        data.saveMarsUpgradeValue6 = UpgradeButtonBehaviour.marsUpgradeCost[5];
        data.saveMarsUpgradeValue7 = UpgradeButtonBehaviour.marsUpgradeCost[6];
        data.saveMarsUpgradeValue8 = UpgradeButtonBehaviour.marsUpgradeCost[7];
        data.saveMarsUpgradeValue9 = UpgradeButtonBehaviour.marsUpgradeCost[8];

        data.saveUpgradeAmountNumberA1 = UpgradeButtonBehaviour.currentAmountUpgradeA[0];
        data.saveUpgradeAmountNumberA2 = UpgradeButtonBehaviour.currentAmountUpgradeA[1];
        data.saveUpgradeAmountNumberA3 = UpgradeButtonBehaviour.currentAmountUpgradeA[2];
        data.saveUpgradeAmountNumberA4 = UpgradeButtonBehaviour.currentAmountUpgradeA[3];
        data.saveUpgradeAmountNumberA5 = UpgradeButtonBehaviour.currentAmountUpgradeA[4];
        data.saveUpgradeAmountNumberA6 = UpgradeButtonBehaviour.currentAmountUpgradeA[5];
        data.saveUpgradeAmountNumberA7 = UpgradeButtonBehaviour.currentAmountUpgradeA[6];
        data.saveUpgradeAmountNumberA8 = UpgradeButtonBehaviour.currentAmountUpgradeA[7];
        data.saveUpgradeAmountNumberA9 = UpgradeButtonBehaviour.currentAmountUpgradeA[8];

        data.saveUpgradeAmountNumberB1 = UpgradeButtonBehaviour.currentAmountUpgradeB[0];

        // PerSecond

        data.saveMoneyPerSecond = PerSecond.moneyPerSecond;

        // MainButtonClick

        data.saveClickValue = MainButtonClick.clickValue;
        data.saveFlatClickValue = MainButtonClick.flatClickValue;

        // GlobalMoney

        data.saveMoneyCount = GlobalMoney.moneyCount;

        // Doge

        data.save1SoldInt = Doge.doget1SoldInt;
        data.save2SoldInt = Doge.doget2SoldInt;
        data.save3SoldInt = Doge.doget3SoldInt;

        // SelectAsteroids

        data.saveCurrentIDT1 = SelectAsteroids.currentIDT1;
        data.saveCurrentIDT2 = SelectAsteroids.currentIDT2;
        data.saveCurrentIDT3 = SelectAsteroids.currentIDT3;

        data.saveCurrentIDBrokenT1 = SelectAsteroids.currentIDBrokenT1;
        data.saveCurrentIDBrokenT2 = SelectAsteroids.currentIDBrokenT2;
        data.saveCurrentIDBrokenT3 = SelectAsteroids.currentIDBrokenT3;

    }

    public static void SaveToFile(PlayerData data)
    {

        GetValues(data);
        SaveSystem.SavePlayer(data);

    }
}
