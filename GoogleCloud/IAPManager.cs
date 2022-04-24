using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{

    #region Initialization / Declaration

    public static IAPManager instance;
    public PlayerData IAPGameData = new PlayerData();

    [SerializeField] private Button buy1;
    [SerializeField] private Button buy2;
    [SerializeField] private Button buy3;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    private bool checkIAP1 = false;
    private bool checkIAP2 = false;
    private bool checkIAP3 = false;

    //------------------- Produtos -------------------

    private string dogeT1 = "doget1";
    private string dogeT2 = "doget2";
    private string dogeT3 = "doget3";

    #endregion

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
        instance = this;
        CheckPurchase();
    }

    void CheckPurchase()
    {
        StartCoroutine(PurchaseCoroutine());
    }

    IEnumerator PurchaseCoroutine()
    {
        yield return new WaitForSeconds(2.5f);

        Product DOGE_T1 = m_StoreController.products.WithID("doget1");
        Product DOGE_T2 = m_StoreController.products.WithID("doget2");
        Product DOGE_T3 = m_StoreController.products.WithID("doget3");

        if (DOGE_T1 != null && DOGE_T1.hasReceipt && Doge.soldDogeT1 != true)
        {
            SelectAsteroids.instance.AsteroidChange("dogeT1");

            Doge.soldDogeT1 = true;
            buy1.interactable = false;

            SelectAsteroids.instance.toggleT1.interactable = true;
            SelectAsteroids.instance.toggleT1.image.sprite = SelectAsteroids.instance.toggleOn;
        }

        if (DOGE_T2 != null && DOGE_T2.hasReceipt && Doge.soldDogeT2 != true)
        {
            SelectAsteroids.instance.AsteroidChange("dogeT2");

            Doge.soldDogeT2 = true;
            buy2.interactable = false;

            SelectAsteroids.instance.toggleT2.interactable = true;
            SelectAsteroids.instance.toggleT2.image.sprite = SelectAsteroids.instance.toggleOn;
        }

        if (DOGE_T3 != null && DOGE_T3.hasReceipt && Doge.soldDogeT3 != true)
        {
            SelectAsteroids.instance.AsteroidChange("dogeT3");

            Doge.soldDogeT3 = true;
            buy3.interactable = false;

            SelectAsteroids.instance.toggleT3.interactable = true;
            SelectAsteroids.instance.toggleT3.image.sprite = SelectAsteroids.instance.toggleOn;
        }

    }

    #region Main Methods

    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(dogeT1, ProductType.NonConsumable);
        builder.AddProduct(dogeT2, ProductType.NonConsumable);
        builder.AddProduct(dogeT3, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void BuyDogeT1()
    {
        checkIAP1 = true;
        BuyProductID(dogeT1);
    }

    public void BuyDogeT2()
    {
        checkIAP2 = true;
        BuyProductID(dogeT2);
    }

    public void BuyDogeT3()
    {
        checkIAP3 = true;
        BuyProductID(dogeT3);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, dogeT1, StringComparison.Ordinal))
        {

            if(checkIAP1 != false)
            {
                SelectAsteroids.instance.AsteroidChange("dogeT1");

                Doge.soldDogeT1 = true;
                buy1.interactable = false;
                SelectAsteroids.instance.toggleT1.interactable = true;
                SelectAsteroids.instance.toggleT1.image.sprite = SelectAsteroids.instance.toggleOn;

                checkIAP1 = false;

                PlayerData.SaveToFile(IAPGameData);
                CloudSaveManager.isSaving = true;
                CloudSaveManager.instance.OpenCloudSave();
            }
        }
        else if (String.Equals(args.purchasedProduct.definition.id, dogeT2, StringComparison.Ordinal))
        {

            if (checkIAP2 != false)
            {
                SelectAsteroids.instance.AsteroidChange("dogeT2");

                Doge.soldDogeT2 = true;
                buy2.interactable = false;
                SelectAsteroids.instance.toggleT2.interactable = true;
                SelectAsteroids.instance.toggleT2.image.sprite = SelectAsteroids.instance.toggleOn;

                checkIAP2 = false;

                PlayerData.SaveToFile(IAPGameData);
                CloudSaveManager.isSaving = true;
                CloudSaveManager.instance.OpenCloudSave();
            }
        }
        else if (String.Equals(args.purchasedProduct.definition.id, dogeT3, StringComparison.Ordinal))
        {

            if (checkIAP3 != false) {
                SelectAsteroids.instance.AsteroidChange("dogeT3");

                Doge.soldDogeT3 = true;
                buy3.interactable = false;
                SelectAsteroids.instance.toggleT3.interactable = true;
                SelectAsteroids.instance.toggleT3.image.sprite = SelectAsteroids.instance.toggleOn;


                checkIAP3 = false;

                PlayerData.SaveToFile(IAPGameData);
                CloudSaveManager.isSaving = true;
                CloudSaveManager.instance.OpenCloudSave();
            }
        }
        else
        {
            Debug.Log("Purchase Failed");
        }

        return PurchaseProcessingResult.Complete;
    }

    #endregion

    #region Auxiliary Methods

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

    #endregion

}