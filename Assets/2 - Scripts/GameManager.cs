using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        ruleObject.SetActive(false);

        if (Instance)
            Destroy(gameObject);

        Instance = this;

        if (Instance == null)
        {
            Instance = GameObject.FindObjectOfType<GameManager>();
            if (Instance == null)
            {
                GameObject container = new GameObject("GameManager");
                Instance = container.AddComponent<GameManager>();
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    public GameObject ruleObject;
    public GameObject buttons;
    public GameObject title;
    public GameObject score;


    public void displayRules()
    {
        ruleObject.SetActive(!ruleObject.activeSelf);
        title.SetActive(!ruleObject.activeSelf);
        buttons.SetActive(!ruleObject.activeSelf);
        score.SetActive(!ruleObject.activeSelf);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public GameObject onHitParticles;
    public void playParticles(float x)
    {
        GetComponent<AudioSource>().Play();

        Vector3 spawnPos = new Vector3(x, 0.16f, 40.94f);
        GameObject ptc;
        ptc = Instantiate(onHitParticles, spawnPos, Quaternion.identity);
        Destroy(ptc, 5f);
    }

}
