using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMenu : MonoBehaviour
{

    private bool buildBool = false;
    private bool upgradeBool = false;
    private bool settingsBool = false;

    [SerializeField] private int buttonNumber;

    [SerializeField] private GameObject block;

    [SerializeField] private GameObject buildMenu;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject settingsMenu;

    [SerializeField] private Image buildButton;
    [SerializeField] private Image upgradeButton;
    [SerializeField] private Image settingsButton;

    private List<GameObject> menuList = new List<GameObject>();
    private List<bool> buttonBool = new List<bool>();
    private List<Image> buttonList = new List<Image>();


    [SerializeField] private Sprite[] buttonOff = new Sprite[3];
    [SerializeField] private Sprite[] buttonOn = new Sprite[3];

    public bool Change = false;

    public Animator Test;

    private void Start()
    {

        menuList.Add(buildMenu);
        menuList.Add(upgradeMenu);
        menuList.Add(settingsMenu);

        buttonBool.Add(buildBool);
        buttonBool.Add(upgradeBool);
        buttonBool.Add(settingsBool);

        buttonList.Add(buildButton);
        buttonList.Add(upgradeButton);
        buttonList.Add(settingsButton);

    }

    public void Click(int buttonNumber)
    {

        Change = true;

        block.SetActive(true);

        if (buttonBool[buttonNumber] == true)
        {

            Change = false;
            block.SetActive(false);
            buttonBool[buttonNumber] = false;
            buttonList[buttonNumber].sprite = buttonOff[buttonNumber];

        }
        else
        {

            for (int i = 0; i < 3; i++)
            {

                if (i != buttonNumber)
                {

                    menuList[i].SetActive(false);
                    buttonBool[i] = false;
                    buttonList[i].sprite = buttonOff[i];

                }
                else
                {

                    menuList[i].SetActive(true);
                    buttonBool[i] = true;
                    buttonList[i].sprite = buttonOn[i];

                }

            }

        }

        if (Change == true) {
            Test.SetBool("var", false);
            Test.SetBool("trig", true); }
        else Test.SetBool("var", true);

    }

}
