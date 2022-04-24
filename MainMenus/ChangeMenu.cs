using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMenu : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private GameObject block;

    [SerializeField] private GameObject buildMenu;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject settingsMenu;

    [SerializeField] private Image buildButton;
    [SerializeField] private Image upgradeButton;
    [SerializeField] private Image settingsButton;

    [SerializeField] private Sprite[] buttonOff = new Sprite[3];
    [SerializeField] private Sprite[] buttonOn = new Sprite[3];

    private List<GameObject> menuList = new List<GameObject>();
    private List<bool> menuBool = new List<bool>();
    private List<Image> menuButtonList = new List<Image>();

    private bool buildBool = false;
    private bool upgradeBool = false;
    private bool settingsBool = false;

    public bool sameMenuCheck = false;

    public Animator Test;

    #endregion

    void Start()
    {
        menuList.Add(buildMenu);
        menuList.Add(upgradeMenu);
        menuList.Add(settingsMenu);

        menuBool.Add(buildBool);
        menuBool.Add(upgradeBool);
        menuBool.Add(settingsBool);

        menuButtonList.Add(buildButton);
        menuButtonList.Add(upgradeButton);
        menuButtonList.Add(settingsButton);
    }

    public void MenuOpen(int buttonNumber)
    {
        sameMenuCheck = true;

        block.SetActive(true);

        if (menuBool[buttonNumber] == true)
        {
            sameMenuCheck = false;

            block.SetActive(false);

            menuBool[buttonNumber] = false;
            menuButtonList[buttonNumber].sprite = buttonOff[buttonNumber];
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (i != buttonNumber)
                {
                    menuList[i].SetActive(false);
                    menuBool[i] = false;
                    menuButtonList[i].sprite = buttonOff[i];
                }
                else
                {
                    menuList[i].SetActive(true);
                    menuBool[i] = true;
                    menuButtonList[i].sprite = buttonOn[i];

                }
            }
        }

        if (sameMenuCheck == true) 
        {
            Test.SetBool("var", false);
            Test.SetBool("trig", true); 
        }
        else
        {
            Test.SetBool("var", true);
        }
    }

}
