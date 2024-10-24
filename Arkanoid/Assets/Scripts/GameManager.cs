using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;
    public List<GameObject> lifesList;
    public int lifes = 3;
    public bool isLevel1 = true;
    public bool isHorizontal = true;
    
    

    public int score;
    public int highScore;

    public enum GameState
    {
        menu,
        inGame,
        pause,
        gameOver
    }

    public GameState currentGameState = GameState.menu;

    private void Start()
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

    public void StartGame()
    {
        isLevel1 = true;
        currentGameState = GameState.inGame;
        lifes = 3;
        score = 0;
        SceneManager.LoadScene("Level1Scene");
       
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
        currentGameState = GameState.gameOver;
        SceneManager.LoadScene("GameOverScene");
    }


}
