using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuBlock : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private Button upgradeMenuButton1;
    [SerializeField] private Button upgradeMenuButton2;
    [SerializeField] private Button upgradeMenuButton3;
    [SerializeField] private Button upgradeMenuButton4;
    [SerializeField] private Button upgradeMenuButton5;
    [SerializeField] private Button upgradeMenuButton6;
    [SerializeField] private Button upgradeMenuButton7;
    [SerializeField] private Button upgradeMenuButton8;
    [SerializeField] private Button upgradeMenuButton9;

    [SerializeField] private Sprite max_buy;

    private SpriteState spriteState;

    #endregion

    void FixedUpdate()
    {
        if (GlobalMoney.moneyCount < ComprarMultiple.tempUpgradeCosts)
        {
            upgradeMenuButton1.interactable = false;
        }
        else
        {
            upgradeMenuButton1.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[1])
        {
            upgradeMenuButton2.interactable = false;
        }
        else
        {
            upgradeMenuButton2.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[2])
        {
            upgradeMenuButton3.interactable = false;
        }
        else
        {
            upgradeMenuButton3.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[3] || UpgradeMenu.exceededAmount1 == true)
        {
            upgradeMenuButton4.interactable = false;

            if(UpgradeMenu.exceededAmount1 == true)
            {
                spriteState = new SpriteState();
                spriteState.disabledSprite = max_buy;
                upgradeMenuButton4.spriteState = spriteState;
            }
        }
        else
        {
            upgradeMenuButton4.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[4])
        {
            upgradeMenuButton5.interactable = false;
        }
        else
        {
            upgradeMenuButton5.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[5] || UpgradeMenu.exceededAmount2 == true)
        {
            upgradeMenuButton6.interactable = false;

            if (UpgradeMenu.exceededAmount2 == true)
            {
                spriteState = new SpriteState();
                spriteState.disabledSprite = max_buy;
                upgradeMenuButton6.spriteState = spriteState;
            }
        }
        else
        {
            upgradeMenuButton6.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[6])
        {
            upgradeMenuButton7.interactable = false;
        }
        else
        {
            upgradeMenuButton7.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[7] || UpgradeMenu.exceededAmount3 == true)
        {
            upgradeMenuButton8.interactable = false;

            if (UpgradeMenu.exceededAmount3 == true)
            {
                spriteState = new SpriteState();
                spriteState.disabledSprite = max_buy;
                upgradeMenuButton8.spriteState = spriteState;
            }
        }
        else
        {
            upgradeMenuButton8.interactable = true;
        }

        if (GlobalMoney.moneyCount < UpgradeMenu.upgradeCosts[8])
        {
            upgradeMenuButton9.interactable = false;
        }
        else
        {
            upgradeMenuButton9.interactable = true;
        }
    }

}
