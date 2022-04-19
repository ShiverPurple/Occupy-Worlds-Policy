using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Doge : MonoBehaviour
{

    #region Initialization / Declaration

    public PlayerData dogeData = new PlayerData();

    [SerializeField] private GameObject dogeShop;

    [SerializeField] private Button buyDogeT1;
    [SerializeField] private Button buyDogeT2;
    [SerializeField] private Button buyDogeT3;

    public static bool soldDogeT1 = false;
    public static bool soldDogeT2 = false;
    public static bool soldDogeT3 = false;

    #endregion

    void Start()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
        {

            dogeData = SaveSystem.LoadPlayer();
            InputValues(dogeData);

        }

        #region Doge Sale Check

        if (soldDogeT1 == true)
        {
            buyDogeT1.interactable = false;
        }

        if (soldDogeT2 == true)
        {
            buyDogeT2.interactable = false;
        }

        if (soldDogeT3 == true)
        {
            buyDogeT3.interactable = false;
        }

        #endregion
    }

    void InputValues(PlayerData data)
    {
        soldDogeT1 = data.saveSoldDogeT1;
        soldDogeT2 = data.saveSoldDogeT2;
        soldDogeT3 = data.saveSoldDogeT3;
    }

    #region Main Methods

    public void OpenDogeShop()
    {
        if (!dogeShop.activeSelf)
        {
            dogeShop.SetActive(true);
        }
        else 
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

    #endregion

}
