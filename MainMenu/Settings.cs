using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    [SerializeField] private AudioMixer masterMixer;

    [SerializeField] private Slider generalAudio;
    [SerializeField] private Slider music;
    [SerializeField] private Slider soundEffects;

    [SerializeField] private TextMeshProUGUI generalAudioValue;
    [SerializeField] private TextMeshProUGUI musicValue;
    [SerializeField] private TextMeshProUGUI soundEffectsValue;

    [SerializeField] private TextMeshProUGUI videoQualityValue;
    
    [SerializeField] private Image[] videoQualityLevel = new Image[3];

    [SerializeField] private Sprite videoQualitySelected;
    [SerializeField] private Sprite videoQualityUnselected;

    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject privacyPolicy;

    [SerializeField] private GameObject fpsGameObject;

    private int qualityID = 0;

    private void Start()
    {

        masterMixer.SetFloat("volMaster", PlayerPrefs.GetFloat("volMaster"));
        masterMixer.SetFloat("volMusic", PlayerPrefs.GetFloat("volMusic"));
        masterMixer.SetFloat("volSoundEffects", PlayerPrefs.GetFloat("volSoundEffects"));

        generalAudioValue.SetText(Mathf.Round((generalAudio.value + 80f) * 1.25f) + "%");
        musicValue.SetText(Mathf.Round((music.value + 80f) * 1.25f) + "%");
        soundEffectsValue.SetText(Mathf.Round((soundEffects.value + 80f) * 1.25f) + "%");

        videoQualityLevel[0].sprite = videoQualitySelected;

    }

    // Toggle FPS counter

    public void FPSCounterToggle(bool fpsToggle)
    {

        fpsGameObject.SetActive(fpsToggle);

    }

    // Change volume - Sliders

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

    // Change volume - Arrows

    public void GeneralAudioArrow(int direction)
    {

        switch (direction)
        {

            case 0:
                generalAudio.value = (Mathf.Round((generalAudio.value + 80f) * 1.25f)) <= 9 ? -80 : generalAudio.value - 8;
                break;

            case 1:
                generalAudio.value = (Mathf.Round((generalAudio.value + 80f) * 1.25f)) >= 91 ? 0 : generalAudio.value + 8;
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
                break;

            case 1:
                music.value = (Mathf.Round((music.value + 80f) * 1.25f)) >= 91 ? 0 : music.value + 8;
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
                break;

            case 1:
                soundEffects.value = (Mathf.Round((soundEffects.value + 80f) * 1.25f)) >= 91 ? 0 : soundEffects.value + 8;
                break;

        }

        SoundEffectsVolume(soundEffects.value);

    }

    // Change video quality

    public void VideoQualityChange(int counter)
    {

        qualityID = (qualityID + counter) < 3 && (qualityID + counter) > -1 ? qualityID + counter : qualityID;

        switch (qualityID)
        {

            case 0:
                QualitySettings.SetQualityLevel(0, true);
                videoQualityLevel[0].sprite = videoQualitySelected;
                for(int i = 1; i <= 2; i++) videoQualityLevel[i].sprite = videoQualityUnselected;
                videoQualityValue.SetText("Baixa");
                break;

            case 1:
                QualitySettings.SetQualityLevel(3, true);
                videoQualityLevel[1].sprite = videoQualitySelected;
                for (int i = 0; i <= 2; i++) videoQualityLevel[i].sprite = i != 1 ? videoQualityUnselected : videoQualitySelected;
                videoQualityValue.SetText("Média");
                break;

            case 2:
                QualitySettings.SetQualityLevel(6, true);
                videoQualityLevel[2].sprite = videoQualitySelected;
                for (int i = 1; i >= 0; i--) videoQualityLevel[i].sprite = videoQualityUnselected;
                videoQualityValue.SetText("Alta");
                break;

        }

    }

    // Privacy policy

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

}
