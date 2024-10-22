using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;

    

    private void Start()
    {
        instance = this;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1Scene");
    }

   
}
