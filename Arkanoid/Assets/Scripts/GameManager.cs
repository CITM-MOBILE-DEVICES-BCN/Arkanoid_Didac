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
        if(lifes == 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        isLevel1 = true;
        SceneManager.LoadScene("Level1Scene");
    }

    public void LoadLevel2()
    {
        isLevel1 = false;
        SceneManager.LoadScene("Level2Scene");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

   
}
