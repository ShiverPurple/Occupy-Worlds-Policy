using UnityEngine;

[System.Serializable]
public class PlayerData 
{

    #region Profile Data

    public double saveTotalMoneyCount;
    public double saveTotalClickCount;
    public int saveDestroyedAsteroidT1;
    public int saveDestroyedAsteroidT2;
    public int saveDestroyedAsteroidT3;
    public int saveActivatedClickBombs;

    #endregion

    #region Select Asteroid

    public string saveCurrentIDT1;
    public string saveCurrentIDT2;
    public string saveCurrentIDT3;

    public string saveCurrentIDBrokenT1;
    public string saveCurrentIDBrokenT2;
    public string saveCurrentIDBrokenT3;

    #endregion

    #region Doge

    public bool saveSoldDogeT1;
    public bool saveSoldDogeT2;
    public bool saveSoldDogeT3;

    #endregion

    #region Build Menu

    public bool saveGameFinishedCheck;

    public bool saveBuildCheckArray1;
    public bool saveBuildCheckArray2;
    public bool saveBuildCheckArray3;
    public bool saveBuildCheckArray4;
    public bool saveBuildCheckArray5;
    public bool saveBuildCheckArray6;
    public bool saveBuildCheckArray7;
    public bool saveBuildCheckArray8;

    public float saveTimeToAsteroidT3;

    public double saveAsteroidCosts1;
    public double saveAsteroidCosts2;
    public double saveAsteroidCosts3;

    public double saveAsteroidValues1;
    public double saveAsteroidValues2;
    public double saveAsteroidValues3;

    public double saveBuildCosts1;
    public double saveBuildCosts2;
    public double saveBuildCosts3;
    public double saveBuildCosts4;
    public double saveBuildCosts5;
    public double saveBuildCosts6;
    public double saveBuildCosts7;
    public double saveBuildCosts8;
    public double saveBuildCosts9;
    public double saveBuildCosts10;
    public double saveBuildCosts11;
    public double saveBuildCosts12;

    public double savePerSecondValues1;
    public double savePerSecondValues2;
    public double savePerSecondValues3;
    public double savePerSecondValues4;
    public double savePerSecondValues5;
    public double savePerSecondValues6;
    public double savePerSecondValues7;
    public double savePerSecondValues8;

    public int saveCurrentAmountBuildA1;
    public int saveCurrentAmountBuildA2;
    public int saveCurrentAmountBuildA3;
    public int saveCurrentAmountBuildA4;
    public int saveCurrentAmountBuildA5;
    public int saveCurrentAmountBuildA6;
    public int saveCurrentAmountBuildA7;
    public int saveCurrentAmountBuildA8;
    public int saveCurrentAmountBuildA9;
    public int saveCurrentAmountBuildA10;
    public int saveCurrentAmountBuildA11;

    public int saveCurrentAmountBuildB1;
    public int saveCurrentAmountBuildB2;
    public int saveCurrentAmountBuildB3;
    public int saveCurrentAmountBuildB4;
    public int saveCurrentAmountBuildB5;
    public int saveCurrentAmountBuildB6;
    public int saveCurrentAmountBuildB7;
    public int saveCurrentAmountBuildB8;

    #endregion

    #region Upgrade Menu

    public bool saveDoubleClickCost;

    public bool saveExceededAmount1;
    public bool saveExceededAmount2;
    public bool saveExceededAmount3;

    public bool saveClickBombCheck;

    public bool saveAutoClickCheck;

    public double saveAdditionalClickValue;

    public double saveAdditionalClickPercent1;
    public double saveAdditionalClickPercent2;

    public double saveClickBombClicks;
    public double saveClickBombTime;
    public double saveClickBombCountDown;

    public double saveClickOfflineTime;

    public double saveAutoClickValue;

    public double saveUpgradeCosts1;
    public double saveUpgradeCosts2;
    public double saveUpgradeCosts3;
    public double saveUpgradeCosts4;
    public double saveUpgradeCosts5;
    public double saveUpgradeCosts6;
    public double saveUpgradeCosts7;
    public double saveUpgradeCosts8;
    public double saveUpgradeCosts9;

    public int saveCurrentAmountUpgradeA1;
    public int saveCurrentAmountUpgradeA2;
    public int saveCurrentAmountUpgradeA3;
    public int saveCurrentAmountUpgradeA4;
    public int saveCurrentAmountUpgradeA5;
    public int saveCurrentAmountUpgradeA6;
    public int saveCurrentAmountUpgradeA7;
    public int saveCurrentAmountUpgradeA8;
    public int saveCurrentAmountUpgradeA9;

    public int saveCurrentAmountUpgradeB1;

    #endregion

    #region PerSecond

    public double saveMoneyPerSecond;

    #endregion

    #region Main Click Button

    public double saveClickValue;
    public double saveFlatClickValue;

    #endregion

    #region Global Money

    public double saveMoneyCount;

    #endregion

    public static void GetValues(PlayerData data)
    {
        # region Profile Data

        data.saveTotalMoneyCount = GlobalMoney.totalMoneyCount;
        data.saveTotalClickCount = MainClickButton.totalClickCount;
        data.saveDestroyedAsteroidT1 = HitPoint.destroyedAsteroidT1;
        data.saveDestroyedAsteroidT2 = HitPoint.destroyedAsteroidT2;
        data.saveDestroyedAsteroidT3 = HitPoint.destroyedAsteroidT3;
        data.saveActivatedClickBombs = UpgradeMenu.activatedClickBombs;

        #endregion

        #region Build Menu

        data.saveGameFinishedCheck = BuildMenu.gameFinishedCheck; 

        data.saveBuildCheckArray1 = BuildMenu.buildCheckArray[0];
        data.saveBuildCheckArray2 = BuildMenu.buildCheckArray[1];
        data.saveBuildCheckArray3 = BuildMenu.buildCheckArray[2];
        data.saveBuildCheckArray4 = BuildMenu.buildCheckArray[3];
        data.saveBuildCheckArray5 = BuildMenu.buildCheckArray[4];
        data.saveBuildCheckArray6 = BuildMenu.buildCheckArray[5];
        data.saveBuildCheckArray7 = BuildMenu.buildCheckArray[6];
        data.saveBuildCheckArray8 = BuildMenu.buildCheckArray[7];

        data.saveTimeToAsteroidT3 = BuildMenu.timeToAsteroidT3;

        data.saveAsteroidCosts1 = BuildMenu.asteroidCosts[0];
        data.saveAsteroidCosts2 = BuildMenu.asteroidCosts[1];
        data.saveAsteroidCosts3 = BuildMenu.asteroidCosts[2];

        data.saveAsteroidValues1 = BuildMenu.asteroidValues[0];
        data.saveAsteroidValues2 = BuildMenu.asteroidValues[1];
        data.saveAsteroidValues3 = BuildMenu.asteroidValues[2];

        data.saveBuildCosts1 = BuildMenu.buildCosts[0];
        data.saveBuildCosts2 = BuildMenu.buildCosts[1];
        data.saveBuildCosts3 = BuildMenu.buildCosts[2];
        data.saveBuildCosts4 = BuildMenu.buildCosts[3];
        data.saveBuildCosts5 = BuildMenu.buildCosts[4];
        data.saveBuildCosts6 = BuildMenu.buildCosts[5];
        data.saveBuildCosts7 = BuildMenu.buildCosts[6];
        data.saveBuildCosts8 = BuildMenu.buildCosts[7];
        data.saveBuildCosts9 = BuildMenu.buildCosts[8];

        data.savePerSecondValues1 = BuildMenu.perSecondValues[0];
        data.savePerSecondValues2 = BuildMenu.perSecondValues[1];
        data.savePerSecondValues3 = BuildMenu.perSecondValues[2];
        data.savePerSecondValues4 = BuildMenu.perSecondValues[3];
        data.savePerSecondValues5 = BuildMenu.perSecondValues[4];
        data.savePerSecondValues6 = BuildMenu.perSecondValues[5];
        data.savePerSecondValues7 = BuildMenu.perSecondValues[6];
        data.savePerSecondValues8 = BuildMenu.perSecondValues[7];

        data.saveCurrentAmountBuildA1 = BuildMenu.currentAmountBuildA[0];
        data.saveCurrentAmountBuildA2 = BuildMenu.currentAmountBuildA[1];
        data.saveCurrentAmountBuildA3 = BuildMenu.currentAmountBuildA[2];
        data.saveCurrentAmountBuildA4 = BuildMenu.currentAmountBuildA[3];
        data.saveCurrentAmountBuildA5 = BuildMenu.currentAmountBuildA[4];
        data.saveCurrentAmountBuildA6 = BuildMenu.currentAmountBuildA[5];
        data.saveCurrentAmountBuildA7 = BuildMenu.currentAmountBuildA[6];
        data.saveCurrentAmountBuildA8 = BuildMenu.currentAmountBuildA[7];
        data.saveCurrentAmountBuildA9 = BuildMenu.currentAmountBuildA[8];
        data.saveCurrentAmountBuildA10 = BuildMenu.currentAmountBuildA[9];
        data.saveCurrentAmountBuildA11 = BuildMenu.currentAmountBuildA[10];

        data.saveCurrentAmountBuildB1 = BuildMenu.currentAmountBuildB[0];
        data.saveCurrentAmountBuildB2 = BuildMenu.currentAmountBuildB[1];
        data.saveCurrentAmountBuildB3 = BuildMenu.currentAmountBuildB[2];
        data.saveCurrentAmountBuildB4 = BuildMenu.currentAmountBuildB[3];
        data.saveCurrentAmountBuildB5 = BuildMenu.currentAmountBuildB[4];
        data.saveCurrentAmountBuildB6 = BuildMenu.currentAmountBuildB[5];
        data.saveCurrentAmountBuildB7 = BuildMenu.currentAmountBuildB[6];
        data.saveCurrentAmountBuildB8 = BuildMenu.currentAmountBuildB[7];

        #endregion

        #region Upgrade Menu

        data.saveDoubleClickCost = UpgradeMenu.doubleClickCost;

        data.saveExceededAmount1 = UpgradeMenu.exceededAmount1;
        data.saveExceededAmount2 = UpgradeMenu.exceededAmount2;
        data.saveExceededAmount3 = UpgradeMenu.exceededAmount3;

        data.saveClickBombCheck = UpgradeMenu.clickBombCheck;

        data.saveAutoClickCheck = UpgradeMenu.autoClickCheck;

        data.saveAdditionalClickValue = UpgradeMenu.additionalClickValue;

        data.saveAdditionalClickPercent1 = UpgradeMenu.additionalClickPercent1;
        data.saveAdditionalClickPercent2 = UpgradeMenu.additionalClickPercent2;

        data.saveClickBombClicks = UpgradeMenu.clickBombClicks;
        data.saveClickBombTime = UpgradeMenu.clickBombTime;
        data.saveClickBombCountDown = UpgradeMenu.clickBombCountDown;

        data.saveClickOfflineTime = UpgradeMenu.clickOfflineTime;

        data.saveAutoClickValue = UpgradeMenu.autoClickValue;

        data.saveUpgradeCosts1 = UpgradeMenu.upgradeCosts[0];
        data.saveUpgradeCosts2 = UpgradeMenu.upgradeCosts[1];
        data.saveUpgradeCosts3 = UpgradeMenu.upgradeCosts[2];
        data.saveUpgradeCosts4 = UpgradeMenu.upgradeCosts[3];
        data.saveUpgradeCosts5 = UpgradeMenu.upgradeCosts[4];
        data.saveUpgradeCosts6 = UpgradeMenu.upgradeCosts[5];
        data.saveUpgradeCosts7 = UpgradeMenu.upgradeCosts[6];
        data.saveUpgradeCosts8 = UpgradeMenu.upgradeCosts[7];
        data.saveUpgradeCosts9 = UpgradeMenu.upgradeCosts[8];

        data.saveCurrentAmountUpgradeA1 = UpgradeMenu.currentAmountUpgradeA[0];
        data.saveCurrentAmountUpgradeA2 = UpgradeMenu.currentAmountUpgradeA[1];
        data.saveCurrentAmountUpgradeA3 = UpgradeMenu.currentAmountUpgradeA[2];
        data.saveCurrentAmountUpgradeA4 = UpgradeMenu.currentAmountUpgradeA[3];
        data.saveCurrentAmountUpgradeA5 = UpgradeMenu.currentAmountUpgradeA[4];
        data.saveCurrentAmountUpgradeA6 = UpgradeMenu.currentAmountUpgradeA[5];
        data.saveCurrentAmountUpgradeA7 = UpgradeMenu.currentAmountUpgradeA[6];
        data.saveCurrentAmountUpgradeA8 = UpgradeMenu.currentAmountUpgradeA[7];
        data.saveCurrentAmountUpgradeA9 = UpgradeMenu.currentAmountUpgradeA[8];

        data.saveCurrentAmountUpgradeB1 = UpgradeMenu.currentAmountUpgradeB[0];

        #endregion

        #region PerSecond

        data.saveMoneyPerSecond = PerSecond.moneyPerSecond;

        #endregion

        #region Main Click Button

        data.saveClickValue = MainClickButton.clickValue;
        data.saveFlatClickValue = MainClickButton.flatClickValue;

        #endregion

        #region Global Money

        data.saveMoneyCount = GlobalMoney.moneyCount;

        #endregion

        #region Doge

        data.saveSoldDogeT1 = Doge.soldDogeT1;
        data.saveSoldDogeT2 = Doge.soldDogeT2;
        data.saveSoldDogeT3 = Doge.soldDogeT3;

        #endregion

        #region Select Asteroids

        data.saveCurrentIDT1 = SelectAsteroids.currentIDT1;
        data.saveCurrentIDT2 = SelectAsteroids.currentIDT2;
        data.saveCurrentIDT3 = SelectAsteroids.currentIDT3;

        data.saveCurrentIDBrokenT1 = SelectAsteroids.currentIDBrokenT1;
        data.saveCurrentIDBrokenT2 = SelectAsteroids.currentIDBrokenT2;
        data.saveCurrentIDBrokenT3 = SelectAsteroids.currentIDBrokenT3;

        #endregion
    }

    public static void SaveToFile(PlayerData data)
    {
        GetValues(data);
        SaveSystem.SavePlayer(data);
    }

}
