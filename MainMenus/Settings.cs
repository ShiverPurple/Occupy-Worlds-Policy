using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private Image[] videoQualityLevel = new Image[3];

    [SerializeField] private TextMeshProUGUI videoQualityValue;

    [SerializeField] private Sprite videoQualitySelected;
    [SerializeField] private Sprite videoQualityUnselected;

    [SerializeField] private AudioMixer masterMixer;

    [SerializeField] private Slider generalAudio;
    [SerializeField] private Slider music;
    [SerializeField] private Slider soundEffects;

    [SerializeField] private TextMeshProUGUI generalAudioValue;
    [SerializeField] private TextMeshProUGUI musicValue;
    [SerializeField] private TextMeshProUGUI soundEffectsValue;

    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject privacyPolicy;

    [SerializeField] private GameObject fpsGameObject;

    [SerializeField] private ScrollRect privacyPoliceScroll;

    [SerializeField] private RectTransform privacyPT;
    [SerializeField] private RectTransform privacyENG;

    [SerializeField] private Image buttonPT;
    [SerializeField] private Image buttonENG;

    [SerializeField] private Sprite ptOn;
    [SerializeField] private Sprite ptOff;
    [SerializeField] private Sprite engOn;
    [SerializeField] private Sprite engOff;

    private int qualityID = 1;

    #endregion

    void Start()
    {
        #region Initializing Audio

        masterMixer.SetFloat("volMaster", PlayerPrefs.GetFloat("volMaster"));
        masterMixer.SetFloat("volMusic", PlayerPrefs.GetFloat("volMusic"));
        masterMixer.SetFloat("volSoundEffects", PlayerPrefs.GetFloat("volSoundEffects"));

        generalAudio.value = PlayerPrefs.GetFloat("generalSlider");
        music.value = PlayerPrefs.GetFloat("musicSlider");
        soundEffects.value = PlayerPrefs.GetFloat("sfxSlider");

        generalAudioValue.SetText(Mathf.Round((generalAudio.value + 80f) * 1.25f) + "%");
        musicValue.SetText(Mathf.Round((music.value + 80f) * 1.25f) + "%");
        soundEffectsValue.SetText(Mathf.Round((soundEffects.value + 80f) * 1.25f) + "%");

        #endregion

        #region Initializing Quality Settings

        if(PlayerPrefs.GetString("qualityName") == "Baixa" || PlayerPrefs.GetString("qualityName") == "Média" || PlayerPrefs.GetString("qualityName") == "Alta")
        {
            videoQualityValue.SetText(PlayerPrefs.GetString("qualityName"));
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityLevel"));
            qualityID = PlayerPrefs.GetInt("qualityID");
        }

        videoQualityLevel[qualityID].sprite = videoQualitySelected;

        #endregion
    }

    #region Main Methods

    public void FPSCounterToggle(bool fpsToggle)
    {
        fpsGameObject.SetActive(fpsToggle);
    }

    public void VideoQualityChange(int counter)
    {
        qualityID = (qualityID + counter) < 3 && (qualityID + counter) > -1 ? qualityID + counter : qualityID;

        switch (qualityID)
        {
            case 0:
                QualitySettings.SetQualityLevel(0, true);
                videoQualityLevel[0].sprite = videoQualitySelected;

                for (int i = 1; i <= 2; i++) videoQualityLevel[i].sprite = videoQualityUnselected;
                
                videoQualityValue.text = "Baixa";

                PlayerPrefs.SetInt("qualityLevel", 0);
                PlayerPrefs.SetString("qualityName", "Baixa");
                PlayerPrefs.SetInt("qualityID", 0);
                break;

            case 1:
                QualitySettings.SetQualityLevel(3, true);
                videoQualityLevel[1].sprite = videoQualitySelected;

                for (int i = 0; i <= 2; i++) videoQualityLevel[i].sprite = i != 1 ? videoQualityUnselected : videoQualitySelected;

                videoQualityValue.text = "Média";

                PlayerPrefs.SetInt("qualityLevel", 3);
                PlayerPrefs.SetString("qualityName", "Média");
                PlayerPrefs.SetInt("qualityID", 1);
                break;

            case 2:
                QualitySettings.SetQualityLevel(6, true);
                videoQualityLevel[2].sprite = videoQualitySelected;

                for (int i = 1; i >= 0; i--) videoQualityLevel[i].sprite = videoQualityUnselected;

                videoQualityValue.text = "Alta";

                PlayerPrefs.SetInt("qualityLevel", 6);
                PlayerPrefs.SetString("qualityName", "Alta");
                PlayerPrefs.SetInt("qualityID", 2);
                break;
        }
    }

    public void OpenCredits()
    {
        if (credits.activeSelf)
        {
            credits.SetActive(false);
        }
        else
        {
            credits.SetActive(true);
        }
    }

    //--------------------- Mudar Volume - Sliders ---------------------//

    public void GeneralAudioVolume(float sliderValue)
    {
        masterMixer.SetFloat("volMaster", sliderValue);
        generalAudioValue.SetText(Mathf.Round((generalAudio.value + 80f) * 1.25f) + "%");

        PlayerPrefs.SetFloat("volMaster", sliderValue);
    }

    public void MusicVolume(float sliderValue)
    {
        masterMixer.SetFloat("volMusic", sliderValue);
        musicValue.SetText(Mathf.Round((music.value + 80f) * 1.25f) + "%");

        PlayerPrefs.SetFloat("volMusic", sliderValue);
    }

    public void SoundEffectsVolume(float sliderValue)
    {
        masterMixer.SetFloat("volSoundEffects", sliderValue);
        soundEffectsValue.SetText(Mathf.Round((soundEffects.value + 80f) * 1.25f) + "%");

        PlayerPrefs.SetFloat("volSoundEffects", sliderValue);
    }

    //--------------------- Mudar Volume - Setas ---------------------//

    public void GeneralAudioArrow(int direction)
    {
        switch (direction)
        {
            case 0:
                generalAudio.value = (Mathf.Round((generalAudio.value + 80f) * 1.25f)) <= 9 ? -80 : generalAudio.value - 8;

                PlayerPrefs.SetFloat("generalSlider", generalAudio.value);
                break;

            case 1:
                generalAudio.value = (Mathf.Round((generalAudio.value + 80f) * 1.25f)) >= 91 ? 0 : generalAudio.value + 8;

                PlayerPrefs.SetFloat("generalSlider", generalAudio.value);
                break;
        }

        GeneralAudioVolume(generalAudio.value);
    }

    public void MusicArrow(int direction)
    {
        switch (direction)
        {
            case 0:
                music.value = (Mathf.Round((music.value + 80f) * 1.25f)) <= 9 ? -80 : music.value - 8;

                PlayerPrefs.SetFloat("musicSlider", music.value);
                break;

            case 1:
                music.value = (Mathf.Round((music.value + 80f) * 1.25f)) >= 91 ? 0 : music.value + 8;

                PlayerPrefs.SetFloat("musicSlider", music.value);
                break;
        }

        MusicVolume(music.value);
    }

    public void SoundEffectsArrow(int direction)
    {
        switch (direction)
        {
            case 0:
                soundEffects.value = (Mathf.Round((soundEffects.value + 80f) * 1.25f)) <= 9 ? -80 : soundEffects.value - 8;

                PlayerPrefs.SetFloat("sfxSlider", soundEffects.value);
                break;

            case 1:
                soundEffects.value = (Mathf.Round((soundEffects.value + 80f) * 1.25f)) >= 91 ? 0 : soundEffects.value + 8;

                PlayerPrefs.SetFloat("sfxSlider", soundEffects.value);
                break;
        }

        SoundEffectsVolume(soundEffects.value);
    }

    //--------------------- Política de Privacidade ---------------------//

    public void OpenPrivacy()
    {
        if (privacyPolicy.activeSelf) 
        {
            privacyPolicy.SetActive(false);
            masterMixer.SetFloat("volMaster", PlayerPrefs.GetFloat("volMaster"));
        }
        else
        {
            privacyPolicy.SetActive(true);
            GeneralAudioVolume(generalAudio.value);
            masterMixer.SetFloat("volMaster", -80);
        }
    }

    public void PolicyLanguage(string language)
    {
        if(language == "PT")
        {
            privacyPoliceScroll.content = privacyPT;
            privacyPT.gameObject.SetActive(true);
            privacyENG.gameObject.SetActive(false);

            buttonPT.sprite = ptOn;
            buttonENG.sprite = engOff;
        }
        else if(language == "ENG")
        {
            privacyPoliceScroll.content = privacyENG;
            privacyENG.gameObject.SetActive(true);
            privacyPT.gameObject.SetActive(false);

            buttonENG.sprite = engOn;
            buttonPT.sprite = ptOff;
        }
    }

    #endregion

}
