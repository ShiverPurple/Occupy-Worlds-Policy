using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonBlock : MonoBehaviour
{

    public Button BuildingB1;
    public Button BuildingB2;
    public Button BuildingB3;
    public Button BuildingB4;
    public Button BuildingB5;
    public Button BuildingB6;
    public Button BuildingB7;
    public Button BuildingB8;
    public Button BuildingB9;
    public Button BuildingB10;
    public Button BuildingB11;
    public Button BuildingB12;

    // Change button interactability

    void Update()
    {

        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[0])
        {

            BuildingB1.interactable = false;

        }

        else
        {

            BuildingB1.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[1])
        {

            BuildingB2.interactable = false;

        }

        else
        {

            BuildingB2.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[2])
        {

            BuildingB3.interactable = false;

        }

        else
        {

            BuildingB3.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[3])
        {

            BuildingB4.interactable = false;

        }

        else
        {

            BuildingB4.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[4])
        {

            BuildingB5.interactable = false;

        }

        else
        {

            BuildingB5.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[5])
        {

            BuildingB6.interactable = false;

        }

        else
        {

            BuildingB6.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[6])
        {

            BuildingB7.interactable = false;

        }

        else
        {

            BuildingB7.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[7])
        {

            BuildingB8.interactable = false;

        }

        else
        {

            BuildingB8.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsAsteroidCost[0])
        {

            BuildingB9.interactable = false;

        }

        else
        {

            BuildingB9.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsAsteroidCost[1])
        {

            BuildingB10.interactable = false;

        }

        else
        {

            BuildingB10.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsAsteroidCost[2])
        {

            BuildingB11.interactable = false;

        }

        else
        {

            BuildingB11.interactable = true;

        }


        if (GlobalMoney.moneyCount < BuildButtonBehaviour.marsBuildCost[8])
        {

            BuildingB12.interactable = false;

        }

        else
        {

            BuildingB12.interactable = true;

        }

    }

}
