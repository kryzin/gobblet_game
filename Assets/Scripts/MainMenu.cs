using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Going into GameMenu to choose difficulty");
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void SettingsMenu()
    {
        Debug.Log("the buttons in Menu should now change :) ");
    }
}
