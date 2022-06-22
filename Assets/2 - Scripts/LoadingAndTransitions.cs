using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LoadingAndTransitions : MonoBehaviour
{
    private static LoadingAndTransitions instance;

    public GameObject mainMenu;
    public GameObject panel;
    public TextMeshProUGUI score;
    public GameObject logo;

    public float pas = 0.007f;
    public float waitTimeA = 1.5f;

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
        setMenu(true);
        setPanel(true);
        logo.SetActive(false);
        StartCoroutine(fadeoutPanel());
        score.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    IEnumerator startGame()
    {
        setMenu(false);
        logo.SetActive(true);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(fadeoutPanel());


    }

    public void startFadeIn() => StartCoroutine(fadeinPanel());

    IEnumerator fadeinPanel()
    {
        setPanel(true);
        panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(waitTimeA);
       
        

        Color c = panel.GetComponent<Image>().color;
        while(c.a < 1)
        {
            panel.GetComponent<Image>().color = new Color(0, 0, 0, c.a += pas);
            if(c.a > 0.99999999f)
            {
                StartCoroutine(startGame());
                //Ici load scène de jeu
            }
            yield return null;
        }
    }

    IEnumerator fadeoutPanel()
    {
        yield return new WaitForSeconds(waitTimeA);
        panel.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        setPanel(true);
        logo.SetActive(false);
        Color c = panel.GetComponent<Image>().color;
        while (c.a > 0)
        {
            panel.GetComponent<Image>().color = new Color(0, 0, 0, c.a -= pas);
            if (c.a <= 0.01f)
            {
                
                setPanel(false);
            }
            yield return null;
        }
    }

    public void setPanel(bool state)
    {
        panel.SetActive(state);
    }

    public void setMenu(bool state)
    {
        mainMenu.SetActive(state);
    }

    public void EndGame()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(waitTimeA);
        panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        setPanel(true);

        Color c = panel.GetComponent<Image>().color;
        while (c.a < 1)
        {
            panel.GetComponent<Image>().color = new Color(0, 0, 0, c.a += pas);
            if (c.a > 0.99999999f)
            {
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            }
            yield return null;
        }

        yield return new WaitForSeconds(waitTimeA);

        setMenu(true);
        setPanel(true);
        StartCoroutine(fadeoutPanel());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
