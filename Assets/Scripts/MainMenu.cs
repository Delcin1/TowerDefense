using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private int languageIndex;
    private bool fullscreenMode;

    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        languageIndex = PlayerPrefs.GetInt("languageIndex", 3);
        if (languageIndex != 3)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
        }

        if (PlayerPrefs.GetInt("fullscreenMode", 1) == 1)
        {
            fullscreenMode = true;
        }
        else
        {
            fullscreenMode = false;
        }
        Screen.SetResolution(PlayerPrefs.GetInt("width", Screen.currentResolution.width),
            PlayerPrefs.GetInt("height", Screen.currentResolution.height), fullscreenMode);

        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume", 1));

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityIndex", 0));
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
