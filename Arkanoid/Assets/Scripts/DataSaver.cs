using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver
{
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("Lifes", GameManager.instance.lifes);
        PlayerPrefs.SetInt("Score", GameManager.instance.score);
        PlayerPrefs.SetInt("HighScore", GameManager.instance.highScore);
        if(GameManager.instance.isLevel1)
        {
            PlayerPrefs.SetInt("Level Number", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Level Number", 2);
        }
        
    }
    public void SaveBricksPrefs(int lifeBrick, int indexBrick)
    {
        string numBrick = indexBrick.ToString();
       
        PlayerPrefs.SetInt(numBrick, lifeBrick);
    }
    public void LoadPlayerPrefs()
    {
        GameManager.instance.lifes = PlayerPrefs.GetInt("Lifes", 3);
        GameManager.instance.score = PlayerPrefs.GetInt("Score", 0);
        GameManager.instance.highScore = PlayerPrefs.GetInt("HighScore", 0);
        int numLevel = PlayerPrefs.GetInt("Level Number", 1);
        if(numLevel == 1)
        {
            GameManager.instance.isLevel1 = true;
            GameManager.instance.LoadLevel1();
        }
        else
        {
            GameManager.instance.isLevel1 = false;
            GameManager.instance.LoadLevel2();
        }
    }
    public int LoadBricksPrefs(int indexBrick)
    {
        int lifeBrick = PlayerPrefs.GetInt(indexBrick.ToString(), 0);
        Debug.Log(lifeBrick);
        return lifeBrick;
    }
}
