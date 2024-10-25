using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    static public ButtonController instance;

    public GameObject pauseMenu;
    public GameObject continueButton;
    private DataSaver dataSaver = new DataSaver();

    private void Start()
    {
        instance = this;

        if (GameManager.instance.gameSaved)
        {
            continueButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
    public void StartGame()
    {
        GameManager.instance.isLevel1 = true;
        GameManager.instance.currentGameState = GameState.inGame;
        GameManager.instance.lifes = 3;
        GameManager.instance.score = 0;
        GameManager.instance.musicSource.Play();
        GameManager.instance.titleMusic.Stop();
        SceneManager.LoadScene("Level1Scene");

    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void SaveGame()
    {
        GameManager.instance.gameSaved = true;
        dataSaver.SavePlayerPrefs();
        UIController.instance.brickManager.SaveBricks();
    }
    public void LoadMenu()
    {
        GameManager.instance.currentGameState = GameState.menu;
        GameManager.instance.titleMusic.Play();
        GameManager.instance.musicSource.Stop();
        SceneManager.LoadScene("MainMenuScene");
    }
    public void LoadGame()
    {
        dataSaver.LoadPlayerPrefs();
        
    }
}
