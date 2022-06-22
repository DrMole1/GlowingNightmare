using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int actualScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    private Transform player;

    private void Awake()
    {
        actualScore = 0;
        bestScoreText = GameObject.Find("Canvas").transform.GetChild(0).GetChild(3).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void AddScoreGreen()
    {
        actualScore += 100;

        PrintScore();
    }

    public void AddScoreBlue()
    {
        actualScore += 500;

        PrintScore();
    }

    public void AddScoreRed()
    {
        int scoreToAdd = UnityEngine.Random.Range(100, 5000);
        actualScore += scoreToAdd;

        PrintScore();
    }

    public void PrintScore()
    {
        scoreText.text = actualScore.ToString();
    }



    public void CheckScore()
    {
        if(actualScore > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", actualScore);
            bestScoreText.text = actualScore.ToString();
        }

        actualScore = 0;
    }

    public void WinScore()
    {
        actualScore += 10000;

        PrintScore();
    }
}
