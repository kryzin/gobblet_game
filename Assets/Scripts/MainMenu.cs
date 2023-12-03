using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // this is GameEasy3
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetFromMainMenu() // this is definitely wrong, but was the fastest way to fix not resetting on gameStartUp
    {
        PlayerPrefs.SetInt("ScoreRed", 0);
        PlayerPrefs.SetInt("ScoreBlue", 0);
        PlayerPrefs.Save();
    }
}
