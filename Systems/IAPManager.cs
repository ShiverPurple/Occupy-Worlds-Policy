using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    public PlayerData IAPGameData = new PlayerData();

    public int check1 = 0;
    public int check2 = 0;
    public int check3 = 0;

    //Step 1 create your products

    [SerializeField] GameObject spawn;
    [SerializeField] GameObject temp;

    [SerializeField] Button buy1;
    [SerializeField] Button buy2;
    [SerializeField] Button buy3;

    private string dogeT1 = "doget1";
    private string dogeT2 = "doget2";
    private string dogeT3 = "doget3";

    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable

        builder.AddProduct(dogeT1, ProductType.NonConsumable);
        builder.AddProduct(dogeT2, ProductType.NonConsumable);
        builder.AddProduct(dogeT3, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods

    public void BuyDogeT1()
    {

        check1 = 1;
        BuyProductID(dogeT1);

    }

    public void BuyDogeT2()
    {

        check2 = 1;
        BuyProductID(dogeT2);

    }

    public void BuyDogeT3()
    {
        check3 = 1;
        BuyProductID(dogeT3);

    }

    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, dogeT1, StringComparison.Ordinal))
        {

            IAPGameData = SaveSystem.LoadPlayer();

            if(check1 != 0)
            {
                SelectAsteroids.functions.currentDogeT1();

                spawn.GetComponent<SpawnField>().enabled = false;

                AsteroidPool.current.SmallAsteroids.Clear();
                AsteroidPool.current.SmallShattered.Clear();

                AsteroidPool.current.ReloadBrokenS();

                AsteroidPool.current.CreatePoolS();
                AsteroidPool.current.CreatePoolShatteredS();

                spawn.GetComponent<SpawnField>().enabled = true;

                Doge.doget1SoldInt = 1;
                buy1.interactable = false;

                check1 = 0;

                PlayerData.SaveToFile(IAPGameData);
                temp.GetComponent<CloudSaveManager>().SaveToCloud();
            }
   

        }
        else if (String.Equals(args.purchasedProduct.definition.id, dogeT2, StringComparison.Ordinal))
        {

            IAPGameData = SaveSystem.LoadPlayer();

            if (check2 != 0)
            {
                SelectAsteroids.functions.currentDogeT2();

                spawn.GetComponent<SpawnField>().enabled = false;

                AsteroidPool.current.MediumAsteroids.Clear();
                AsteroidPool.current.MediumShattered.Clear();

                AsteroidPool.current.ReloadBrokenM();

                AsteroidPool.current.CreatePoolM();
                AsteroidPool.current.CreatePoolShatteredM();

                spawn.GetComponent<SpawnField>().enabled = true;


                Doge.doget2SoldInt = 1;
                buy2.interactable = false;

                check2 = 0;

                PlayerData.SaveToFile(IAPGameData);
                temp.GetComponent<CloudSaveManager>().SaveToCloud();
            }


        }
        else if (String.Equals(args.purchasedProduct.definition.id, dogeT3, StringComparison.Ordinal))
        {

            IAPGameData = SaveSystem.LoadPlayer();

            if (check3 != 0) {

                SelectAsteroids.functions.currentDogeT3();

                spawn.GetComponent<SpawnField>().enabled = false;

                AsteroidPool.current.GreatAsteroids.Clear();
                AsteroidPool.current.GreatShattered.Clear();

                AsteroidPool.current.ReloadBrokenG();

                AsteroidPool.current.CreatePoolG();
                AsteroidPool.current.CreatePoolShatteredG();

                spawn.GetComponent<SpawnField>().enabled = true;

                Doge.doget3SoldInt = 1;
                buy3.interactable = false;

                check3 = 0;

                PlayerData.SaveToFile(IAPGameData);
                temp.GetComponent<CloudSaveManager>().SaveToCloud();
            }

        }
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }










    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}