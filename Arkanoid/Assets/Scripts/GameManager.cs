using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;
    public List<GameObject> lifesList;
    public int lifes = 3;
    public bool isLevel1 = true;
    public bool isHorizontal = true;


    private DataSaver dataSaver = new DataSaver();

    public int score;
    public int highScore;

    
    public bool gameSaved = false;

    public enum GameState
    {
        menu,
        inGame,
        pause,
        gameOver
    }

    public GameState currentGameState = GameState.menu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        
        
    }

    private void Update()
    {
        if(lifes == 0 && currentGameState == GameState.inGame)
        {
            GameOver();
        }

    }

    public void LoadLevel1()
    {
        isLevel1 = true;
        currentGameState = GameState.inGame;
        SceneManager.LoadScene("Level1Scene");
    }

    public void LoadLevel2()
    {
        isLevel1 = false;
        currentGameState = GameState.inGame;
        SceneManager.LoadScene("Level2Scene");
    }

    public void GameOver()
    {
        gameSaved = false;
        currentGameState = GameState.gameOver;
        SceneManager.LoadScene("GameOverScene");
    }
    


}
