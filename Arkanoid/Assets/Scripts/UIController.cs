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

    public List<GameObject> lifes;
    public BallMovement ball;

    public int score;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue.text = "0";
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = score.ToString();
        highScoreValue.text = highScore.ToString();
    }

    public void AddPoints()
    {
        score += 100;
        if (score >= highScore)
        {
            highScore = score;
        }
    }

    public void LoseLife()
    {
        lifes[lifes.Count - 1].gameObject.SetActive(false);
        lifes.RemoveAt(lifes.Count - 1);
        ball.LaunchBall();
    }
}
