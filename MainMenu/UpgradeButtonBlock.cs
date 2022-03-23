using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonBlock : MonoBehaviour
{

    public Button UpgradeB1;
    public Button UpgradeB2;
    public Button UpgradeB3;
    public Button UpgradeB4;
    public Button UpgradeB5;
    public Button UpgradeB6;
    public Button UpgradeB7;
    public Button UpgradeB8;
    public Button UpgradeB9;

    SpriteState spriteState = new SpriteState();

    public Sprite max_buy;

    // Change button interactability

    void Update()
    {

        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[0])
        {

            UpgradeB1.interactable = false;

        }

        else
        {

            UpgradeB1.interactable = true;

        }

        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[1])
        {

            UpgradeB2.interactable = false;

        }

        else
        {

            UpgradeB2.interactable = true;

        }


        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[2])
        {

            UpgradeB3.interactable = false;

        }

        else
        {

            UpgradeB3.interactable = true;

        }


        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[3] || UpgradeButtonBehaviour.overCheck1 == true)
        {

            UpgradeB4.interactable = false;

            if(UpgradeButtonBehaviour.overCheck1 == true)
            {

                spriteState.disabledSprite = max_buy;
                UpgradeB4.spriteState = spriteState;

            }

        }

        else
        {

            UpgradeB4.interactable = true;

        }


        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[4])
        {

            UpgradeB5.interactable = false;

        }

        else
        {

            UpgradeB5.interactable = true;

        }


        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[5] || UpgradeButtonBehaviour.overCheck2 == true)
        {

            UpgradeB6.interactable = false;

            if (UpgradeButtonBehaviour.overCheck2 == true)
            {

                spriteState.disabledSprite = max_buy;
                UpgradeB6.spriteState = spriteState;

            }

        }

        else
        {

            UpgradeB6.interactable = true;

        }


        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[6])
        {

            UpgradeB7.interactable = false;

        }

        else
        {

            UpgradeB7.interactable = true;

        }


        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[7])
        {

            UpgradeB8.interactable = false;

        }

        else
        {

            UpgradeB8.interactable = true;

        }


        if (GlobalMoney.moneyCount < UpgradeButtonBehaviour.marsUpgradeCost[8])
        {

            UpgradeB9.interactable = false;

        }

        else
        {

            UpgradeB9.interactable = true;

        }

    }

}
