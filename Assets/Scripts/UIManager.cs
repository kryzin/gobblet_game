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
    public TMP_Text playerTurn;

    void Start()
    {
        popUp.SetActive(false); // dont show pop up at start
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
        DisplayPlayer();
    }

    void DisplayTimer()
    {
        int min = Mathf.FloorToInt(timer / 60);
        int sec = Mathf.FloorToInt(timer - min * 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", min, sec); // MM:SS
    }

    void DisplayTally()
    {
        tally.text = string.Format("{0:00} - {1:00}", PlayerPrefs.GetInt("ScoreBlue"), PlayerPrefs.GetInt("ScoreRed"));
    }

    void DisplayPlayer()
    {
        playerTurn.text = gameManager.currentPlayer.ToString();
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
        SceneManager.LoadScene(1); // Go to GameEasy3
    }

    public void QuitToMenu()
    {
        Debug.Log("quitting");
        PlayerPrefs.SetInt("ScoreRed", 0);
        PlayerPrefs.SetInt("ScoreBlue", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0); // this is MainMenu
    }

    public void NewRound()
    {
        SceneManager.LoadScene(1); // reload the scene, tally stays saved in PlayerPrefs
    }
}
