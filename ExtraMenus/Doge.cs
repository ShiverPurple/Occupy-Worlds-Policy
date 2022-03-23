using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Doge : MonoBehaviour
{

    //Save System

    public PlayerData dogeData = new PlayerData();

    [SerializeField] GameObject dogeShop;

    [SerializeField] Button doget1sold;
    [SerializeField] Button doget2sold;
    [SerializeField] Button doget3sold;

    public static int doget1SoldInt = 0;
    public static int doget2SoldInt = 0;
    public static int doget3SoldInt = 0;

    void Start()
    {
        
        if (File.Exists(Path.Combine(Application.persistentDataPath, "savetest.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "savetestcloud.k")))
        {

            dogeData = SaveSystem.LoadPlayer();
            InputValues(dogeData);

        }
        
        if (doget1SoldInt == 1)
        {

            doget1sold.interactable = false;

        }

        if (doget2SoldInt == 1)
        {

            doget2sold.interactable = false;

        }

        if (doget3SoldInt == 1)
        {

            doget3sold.interactable = false;

        }

    }

    void InputValues(PlayerData data)
    {


        doget1SoldInt = data.save1SoldInt;
        doget2SoldInt = data.save2SoldInt;
        doget3SoldInt = data.save3SoldInt;

    }


    public void OpenDogeShop()
    {

        if (!dogeShop.activeSelf)
        {

            dogeShop.SetActive(true);

        }

        else {

            dogeShop.SetActive(false);

        }

    }

    public void CloseDogeShop()
    {

        if (dogeShop.activeSelf)
        {

            dogeShop.SetActive(false);

        }

    }

    public void BuyDogeT1()
    {

        IAPManager.instance.BuyDogeT1();

    }

    public void BuyDogeT2()
    {

        IAPManager.instance.BuyDogeT2();

    }

    public void BuyDogeT3()
    {

        IAPManager.instance.BuyDogeT3();

    }

}
