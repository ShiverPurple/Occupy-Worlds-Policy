using UnityEngine;
using TMPro;

public class ProfileData : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private TextMeshProUGUI displayTotalMoneyCount;
    [SerializeField] private TextMeshProUGUI displayTotalClickCount;
    [SerializeField] private TextMeshProUGUI displayMoneyPerSecond;
    [SerializeField] private TextMeshProUGUI displayClickValue;
    [SerializeField] private TextMeshProUGUI displayAutoclickValue;
    [SerializeField] private TextMeshProUGUI displayDestroyedAsteroidT1;
    [SerializeField] private TextMeshProUGUI displayDestroyedAsteroidT2;
    [SerializeField] private TextMeshProUGUI displayDestroyedAsteroidT3;
    [SerializeField] private TextMeshProUGUI displayActivatedClickBombs;

    [SerializeField] private GameObject profile;

    #endregion

    void FixedUpdate()
    {
        displayTotalMoneyCount.SetText(MainClickButton.instance.FormatNumber(GlobalMoney.totalMoneyCount));
        displayTotalClickCount.SetText(MainClickButton.instance.FormatNumber(MainClickButton.totalClickCount));
        displayMoneyPerSecond.SetText(MainClickButton.instance.FormatNumber(PerSecond.moneyPerSecond));
        displayClickValue.SetText( MainClickButton.instance.FormatNumber(MainClickButton.clickValue));
        displayAutoclickValue.SetText(MainClickButton.instance.FormatNumber(UpgradeMenu.autoClickValue));
        displayDestroyedAsteroidT1.SetText(MainClickButton.instance.FormatNumber(HitPoint.destroyedAsteroidT1));
        displayDestroyedAsteroidT2.SetText(MainClickButton.instance.FormatNumber(HitPoint.destroyedAsteroidT2));
        displayDestroyedAsteroidT3.SetText(MainClickButton.instance.FormatNumber(HitPoint.destroyedAsteroidT3));
        displayActivatedClickBombs.SetText(MainClickButton.instance.FormatNumber(UpgradeMenu.activatedClickBombs));
    }

    public void OpenProfile()
    {
        if (profile.activeSelf)
        {
            profile.SetActive(false);
        }
        else 
        {  
            profile.SetActive(true);
        }
    }

}
