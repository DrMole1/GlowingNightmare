using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private ScoreManager scoreManager;
    private LoadingAndTransitions loadings;



    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        loadings = GameObject.Find("Canvas").GetComponent<LoadingAndTransitions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WAGON")
        {
            GetComponent<AudioSource>().Play();

            scoreManager.WinScore();

            scoreManager.CheckScore();

            loadings.EndGame();
        }
    }
}
