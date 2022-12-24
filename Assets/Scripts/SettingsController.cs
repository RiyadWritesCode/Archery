using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsController : MonoBehaviour
{
    LevelLoader LevelLoader;

    public AudioMixerGroup musicMixer;
    public AudioMixerGroup soundMixer;

    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;


    void Start()
    {
        qualityDropdown.value = QualitySettings.GetQualityLevel();

        //resolution stuff
        LevelLoader = FindObjectOfType<LevelLoader>();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void PlayMenu()
    {
        StartCoroutine(LevelLoader.LoadSceneByName("Main Menu"));
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        musicMixer.audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetSoundVolume(float volume)
    {
        soundMixer.audioMixer.SetFloat("soundVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
