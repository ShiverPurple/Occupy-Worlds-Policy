using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class MainClickButton : MonoBehaviour
{

    #region Initialization / Declaration

    public static MainClickButton instance;
    public PlayerData mainButtonData = new PlayerData();

    [SerializeField] private Camera mainCamera;

    [SerializeField] private TextMeshProUGUI clickValueDisplay;
    [SerializeField] private TextMeshProUGUI autoClickValueDisplay;
    [SerializeField] private TextMeshProUGUI popUpValues;

    [SerializeField] private GameObject gameSounds;
    [SerializeField] private AudioClip clickAudioClip;

    private List<int> spawnArray = new List<int> { 0, 1, 3, 5, 8 };

    public static double totalClickCount = 0d;

    public static double clickValue = 1d;
    public static double flatClickValue = 1d;

    private double oldFlatClickValue = flatClickValue;
    private double oldClickValue = clickValue;
    private double oldAutoClick = UpgradeMenu.autoClickValue;

    private AudioSource clickAudioSource;

    #endregion

    void Awake()
    {
        instance = this;
    }

    void Start()
    { 
        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
        {
            mainButtonData = SaveSystem.LoadPlayer();
            InputValues(mainButtonData);
        }

        clickAudioSource = gameSounds.GetComponents<AudioSource>()[1];

        autoClickValueDisplay.SetText(FormatNumber(UpgradeMenu.autoClickValue) + "\n<size=30>Auto Clicks</size>");
        clickValueDisplay.SetText(FormatNumber(clickValue) + "\n<size=30>Valor do Click</size>");
        popUpValues.SetText("<sprite=12>" + FormatNumber(clickValue));       
    }

    void InputValues(PlayerData data)
    {
        totalClickCount = data.saveTotalClickCount;
        clickValue = data.saveClickValue;
        flatClickValue = data.saveFlatClickValue;
    }

    #region Main Methods

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

        GameObject popUp = ObjectPoolPopUp.instance.GetPopUpParticle();

        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        if (!hit.collider)
        {
            if (popUp != null)
            {
                uint seedValue = Convert.ToUInt32(spawnArray[UnityEngine.Random.Range(0, 4)]);

                popUp.transform.position = ray.origin;
                popUp.GetComponent<ParticleSystem>().randomSeed = seedValue;
                popUp.SetActive(true);
                popUp.GetComponent<ParticleSystem>().Play();

                clickAudioSource.PlayOneShot(clickAudioClip);
            }
        }
        else if (hit.collider.CompareTag("Planet"))
        {
            clickAudioSource.PlayOneShot(clickAudioClip);
        }
    }

    public void ClickMainButton()
    {
        GlobalMoney.moneyCount += clickValue;
        GlobalMoney.totalMoneyCount += clickValue;

        totalClickCount += 1d;
    }

    #endregion

    void Update()
    { 
        if (oldAutoClick != UpgradeMenu.autoClickValue)
        {
            autoClickValueDisplay.SetText(FormatNumber(UpgradeMenu.autoClickValue) + "\n<size=30>Auto Clicks</size>");

            oldAutoClick = UpgradeMenu.autoClickValue;
        }

        if(oldClickValue != clickValue || oldFlatClickValue != flatClickValue)
        {
            clickValue = flatClickValue + (flatClickValue * (UpgradeMenu.additionalClickPercent1 / 100)) + (flatClickValue * (UpgradeMenu.additionalClickPercent2 / 100));

            clickValueDisplay.SetText(FormatNumber(clickValue) + "\n<size=30>Valor do Click</size>");
            popUpValues.SetText("<sprite=12>" + FormatNumber(clickValue));

            oldClickValue = clickValue;
            oldFlatClickValue = flatClickValue;
        }
    }

}
