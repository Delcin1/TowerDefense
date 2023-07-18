using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public int nextLevel = 2;

    public void Continue()
    {
        if (PlayerPrefs.GetInt("levelReached", nextLevel) < nextLevel)
            PlayerPrefs.SetInt("levelReached", nextLevel);
        SceneManager.LoadScene(nextLevel + 2);
    }

    public void Menu()
    {
        if (PlayerPrefs.GetInt("levelReached", nextLevel) < nextLevel)
            PlayerPrefs.SetInt("levelReached", nextLevel);
        SceneManager.LoadScene(0);
    }
}
