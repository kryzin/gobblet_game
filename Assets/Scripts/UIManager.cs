using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject popUp;

    public TMP_Text timerDisplay;
    private bool isTimer = false;
    private float timer = 0.0f;

    public TMP_Text tally;

    void Start()
    {
        popUp.SetActive(false);
        StartTimer();
    }

    void Update()
    {
        if (isTimer)
        {
            timer += Time.deltaTime;
            DisplayTimer();
        }
        DisplayTally();
    }

    void DisplayTimer()
    {
        int min = Mathf.FloorToInt(timer / 60);
        int sec = Mathf.FloorToInt(timer - min * 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void DisplayTally()
    {
        tally.text = string.Format("{0:00} - {1:00}", PlayerPrefs.GetInt("ScoreBlue"), PlayerPrefs.GetInt("ScoreRed"));
    }

    public void ShowPopUp()
    {
        popUp.SetActive(true);
    }

    public void StartTimer()
    {
        isTimer = true;
    }

    public void StopTimer()
    {
        isTimer = false;
    }

    public void ResetGame()
    {
        timer = 0.0f;
        PlayerPrefs.SetInt("ScoreRed", 0);
        PlayerPrefs.SetInt("ScoreBlue", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1); // Go to GameScene
    }

    public void QuitToMenu()
    {
        Debug.Log("quitting");
        PlayerPrefs.SetInt("ScoreRed", 0);
        PlayerPrefs.SetInt("ScoreBlue", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0); // this is mainmenu
    }

    public void NewRound()
    {
        SceneManager.LoadScene(1);
    }
}
