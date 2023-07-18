using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;

    public Toggle fullscreenToggle;

    public bool fullscreenMode = true;

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown languageDropdown;
    public TMP_Dropdown graphicsDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        LoadSettingsUI();
    }

    private void LoadSettingsUI()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentWidth = PlayerPrefs.GetInt("width", Screen.currentResolution.width);
        int currentHeight = PlayerPrefs.GetInt("height", Screen.currentResolution.height);
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == currentWidth &&
                resolutions[i].height == currentHeight)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            languageDropdown.value = 1;
        }
        else
        {
            languageDropdown.value = 0;
        }

        languageDropdown.RefreshShownValue();

        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1);

        graphicsDropdown.value = PlayerPrefs.GetInt("qualityIndex", 0);

        if (PlayerPrefs.GetInt("fullscreenMode", 1) == 1)
        {
            fullscreenMode = true;
        }
        else
        {
            fullscreenMode = false;
        }

        fullscreenToggle.isOn = fullscreenMode;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("width", resolution.width);
        PlayerPrefs.SetInt("height", resolution.height);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if (isFullscreen)
        {
            PlayerPrefs.SetInt("fullscreenMode", 1);
        } else
        {
            PlayerPrefs.SetInt("fullscreenMode", 0);
        }
    }

    public void SetWindowed(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        fullscreenMode = isFullscreen;

        if (isFullscreen)
        {
            PlayerPrefs.SetInt("fullscreenMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreenMode", 0);
        }
    }

    public void SetLanguage(int languageIndex)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
        PlayerPrefs.SetInt("languageIndex", languageIndex);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
