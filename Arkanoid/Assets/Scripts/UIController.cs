using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    static public UIController instance;
    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI highScoreValue;

    
    public BallMovement ball;
    public GameObject lifePrefab;

    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (GameManager.instance.lifesList.Count == 0)
        {
            for (int i = 0; i < GameManager.instance.lifes; i++)
            {
                var life = Instantiate(lifePrefab);
                life.transform.SetParent(gameObject.transform, false);
                life.transform.position = new Vector3(life.transform.position.x + 20 * i, life.transform.position.y, life.transform.position.z);
                GameManager.instance.lifesList.Add(life);

            }
        }
        else
        {
            
            for (int i = 0; i < GameManager.instance.lifes; i++)
            {
                GameManager.instance.lifesList.RemoveAt(i);
                var life = Instantiate(lifePrefab);
                life.transform.SetParent(gameObject.transform, false);
                life.transform.position = new Vector3(life.transform.position.x + 20 * i, life.transform.position.y, life.transform.position.z);
                GameManager.instance.lifesList.Add(life);

            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = GameManager.instance.score.ToString();
        highScoreValue.text = GameManager.instance.highScore.ToString();
    }

    public void AddPoints()
    {
        GameManager.instance.score += 100;
        if (GameManager.instance.score >= GameManager.instance.highScore)
        {
            GameManager.instance.highScore = GameManager.instance.score;
        }
    }

    public void LoseLife()
    {
        GameManager.instance.lifesList[GameManager.instance.lifesList.Count - 1].gameObject.SetActive(false);
        GameManager.instance.lifesList.RemoveAt(GameManager.instance.lifesList.Count - 1);
        GameManager.instance.lifes--;
    }
}
