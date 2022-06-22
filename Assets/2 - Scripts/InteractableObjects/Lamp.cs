using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private int increment = 0;
    public ParticleSystem ptc;
    public AudioClip clip;

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().volume = 0.2f;
    }

    public void Active()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);

        transform.parent.GetChild(9).gameObject.GetComponent<Renderer>().enabled = false;
        transform.parent.GetChild(10).gameObject.GetComponent<Renderer>().enabled = false;
        transform.parent.GetChild(11).gameObject.GetComponent<Renderer>().enabled = false;
        transform.parent.GetChild(12).gameObject.GetComponent<Renderer>().enabled = false;
        transform.parent.GetChild(13).gameObject.SetActive(false);
        transform.parent.GetChild(14).gameObject.SetActive(false);
        transform.parent.GetChild(15).gameObject.SetActive(false);
        transform.parent.GetChild(16).gameObject.SetActive(false);
        transform.parent.GetChild(17).gameObject.SetActive(false);
        transform.parent.GetChild(18).gameObject.SetActive(false);
        transform.parent.GetChild(19).gameObject.SetActive(false);
        transform.parent.GetChild(20).gameObject.SetActive(false);
    }
}
