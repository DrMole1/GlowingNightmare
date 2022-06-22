using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Diode : MonoBehaviour
{
    public enum ColorDiode
    {
        GREEN, BLUE, RED
    };

    public enum ObjectType
    {
        SKULL, CROW, LAMP, CAT, PAINT, CANDLESTICK, SPIDER, BOOK, PENTACLE, DEMON, HAND, CROSS
    };


    // ============== VARIABLES ==============

    [Header("Managed Properties")]
    public GameObject interactableObject;
    public ColorDiode color;
    public ObjectType type;

    [Header("Materials")]
    public Material glowindGreen;
    public Material glowindBlue;
    public Material glowindRed;

    private GameObject scoreManagerGO;
    public ScoreManager scoreManager;

    // =======================================

    //private AudioSource _audioSource;


    private void Awake()
    {
        if(GameObject.Find("ScoreManager") != null)
            scoreManagerGO = GameObject.Find("ScoreManager");
        else
            print("there is no Score Manager Game Object");

        
        scoreManager = scoreManagerGO.GetComponent<ScoreManager>();

        switch (color)
        {
            case ColorDiode.GREEN:
                GetComponent<Renderer>().material = glowindGreen;
                break;
            case ColorDiode.BLUE:
                GetComponent<Renderer>().material = glowindBlue;
                break;
            case ColorDiode.RED:
                GetComponent<Renderer>().material = glowindRed;
                break;
            default:
                print("There is no color in the inspector");
                break;
        }
    }


    public void OnTouch()
    {
        switch (color)
        {
            case ColorDiode.GREEN:
                scoreManager.AddScoreGreen();
                break;
            case ColorDiode.BLUE:
                scoreManager.AddScoreBlue();
                break;
            case ColorDiode.RED:
                scoreManager.AddScoreRed();
                break;
            default:
                print("There is no color in the inspector");
                break;
        }

        if(interactableObject == null)
        {
            print("There is no object in the inspector");
            return;
        }

        switch (type)
        {
            case ObjectType.SKULL:
                interactableObject.GetComponent<Skull>().Active();
                break;
            case ObjectType.CROW:
                interactableObject.GetComponent<Crow>().Active();
                break;
            case ObjectType.LAMP:
                interactableObject.GetComponent<Lamp>().Active();
                break;
            case ObjectType.CAT:
                interactableObject.GetComponent<Cat>().Active();
                break;
            default:
                print("There is no type in the inspector");
                break;
        }

        Destroy(gameObject);
    }
}

