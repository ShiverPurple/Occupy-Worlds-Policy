using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class MainButtonClick : MonoBehaviour{

    // Save System

    public PlayerData mainButtonData = new PlayerData();

    public static MainButtonClick functions;

    [SerializeField] Camera mainCamera;

    [SerializeField] TextMeshProUGUI clickValueDisplay;
    [SerializeField] TextMeshProUGUI autoClickNumberDisplay;
    [SerializeField] TextMeshProUGUI popUpValues;

    [SerializeField] GameObject gameSounds;

    public static double clickValue = 1d;
    public static double flatClickValue = 1d;

    double oldFlatClickValue = flatClickValue;
    double oldClickValue = clickValue;
    double oldAutoClick = UpgradeButtonBehaviour.autoClickNumber;

    AudioSource clickSound;

    List<int> SpawnList = new List<int>{ 0, 1, 3, 5, 8 };

    void Awake()
    {

        functions = this;

    }

    void Start()
    {
        
        if (File.Exists(Path.Combine(Application.persistentDataPath, "savetest.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "savetestcloud.k")))
        {

            mainButtonData = SaveSystem.LoadPlayer();
            InputValues(mainButtonData);

        }

        clickSound = gameSounds.GetComponents<AudioSource>()[1];

        autoClickNumberDisplay.text = FormatNumber(UpgradeButtonBehaviour.autoClickNumber) + "\n<size=30>Auto Clicks</size>";
        clickValueDisplay.text = FormatNumber(clickValue) + "\n<size=30>Valor do Click</size>";
        popUpValues.text = "<sprite=12>" + FormatNumber(clickValue);       

    }

    void InputValues(PlayerData data)
    {


        clickValue = data.saveClickValue;
        flatClickValue = data.saveFlatClickValue;

    }

    // Functions and Behaviours

    public string FormatNumber(double number)
    {
        string formatedNum;
        double aux;

        if (number >= Math.Pow(10d, 4d) && number < Math.Pow(10d, 6d))
        {

            aux = number / Math.Pow(10d, 3d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "k") : aux + "k";
            return formatedNum;

        }

        else if (number >= Math.Pow(10d, 6d) && number < Math.Pow(10d, 9d))
        {

            aux = number / Math.Pow(10d, 6d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "M") : aux + "M";
            return formatedNum;

        }

        else if (number >= Math.Pow(10d, 9d) && number < Math.Pow(10d, 12d))
        {

            aux = number / Math.Pow(10d, 9d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "B") : aux + "B";
            return formatedNum;

        }

        else if (number >= Math.Pow(10d, 12d) && number < Math.Pow(10d, 15d))
        {

            aux = number / Math.Pow(10d, 12d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "T") : aux + "T";
            return formatedNum;

        }

        else if (number >= Math.Pow(10d, 15d) && number < Math.Pow(10d, 18d))
        {

            aux = number / Math.Pow(10d, 15d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "Q") : aux + "Q";
            return formatedNum;

        }

        else if (number >= Math.Pow(10d, 18d) && number < Math.Pow(10d, 21d))
        {

            aux = number / Math.Pow(10d, 18d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "Qui") : aux + "Qui";
            return formatedNum;

        }

        else if (number >= Math.Pow(10d, 21d) && number < Math.Pow(10d, 24d))
        {

            aux = number / Math.Pow(10d, 21d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "Sexti") : aux + "Sexti";
            return formatedNum;

        }

        else if (number >= Math.Pow(10d, 24d))
        {

            aux = number / Math.Pow(10d, 24d);
            formatedNum = Math.Round(aux) != aux ? aux.ToString("0.00" + "Septi") : aux + "Septi";
            return formatedNum;

        }

        else if (number == 0)
        {

            formatedNum = "0";
            return formatedNum;

        }

        return Math.Round(number) != number ? number.ToString("0.00") : number.ToString();

    }

    public void PopUpFunction()
    {

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        GameObject popUp = ObjectPoolPopUp.current.GetPool();

        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        if (!hit.collider)
        {

            if (popUp != null)
            {
                uint seedValue = Convert.ToUInt32(SpawnList[UnityEngine.Random.Range(0, 4)]);

                popUp.transform.position = ray.origin;
                popUp.GetComponent<ParticleSystem>().randomSeed = seedValue;
                popUp.SetActive(true);
                popUp.GetComponent<ParticleSystem>().Play();

                clickSound.Play();

            }

        }

        else if (hit.collider.CompareTag("Planet"))
        {

            clickSound.Play();

        }

    }

    public void ClickMainButton()
    {
 
        GlobalMoney.moneyCount += clickValue;

    }

    void Update()
    { 

        if (oldAutoClick != UpgradeButtonBehaviour.autoClickNumber)
        {

            autoClickNumberDisplay.text = FormatNumber(UpgradeButtonBehaviour.autoClickNumber) + "\n<size=30>Auto Clicks</size>";

            oldAutoClick = UpgradeButtonBehaviour.autoClickNumber;

        }

        if(oldClickValue != clickValue || oldFlatClickValue != flatClickValue)
        {

            clickValue = flatClickValue + (flatClickValue * (UpgradeButtonBehaviour.clickUpgradePercentDisplay1 / 100)) + (flatClickValue * (UpgradeButtonBehaviour.clickUpgradePercentDisplay2 / 100));

            clickValueDisplay.text = FormatNumber(clickValue) + "\n<size=30>Valor do Click</size>";
            popUpValues.text = "<sprite=12>" + FormatNumber(clickValue);

            oldClickValue = clickValue;
            oldFlatClickValue = flatClickValue;

        }

    }

}
