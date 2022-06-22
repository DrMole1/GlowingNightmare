using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedJacky : MonoBehaviour
{
    // ==============================================
    public GameObject ptcPrefab;
    public AudioClip clip;
    public Transform rigged;

    private AudioSource audio;
    private ScoreManager scoreManager;
    private LoadingAndTransitions loadings;

    private int incr = 0;
    private float rot;
    private Vector3 currentRot;
    private Quaternion currentQuaternionRot;
    // ==============================================

    private void Start()
    {
        StartCoroutine(Kill());
        audio = GameObject.Find("CursedJackySystem").GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        loadings = GameObject.Find("Canvas").GetComponent<LoadingAndTransitions>();
    }

    public void Die()
    {
        GameObject ptc;
        ptc = Instantiate(ptcPrefab, transform.position, Quaternion.identity);
        Destroy(ptc, 4f);

        audio.Stop();

        Destroy(gameObject);
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(4f);

        if(gameObject == null)
        {
            yield return null;
        }

        GameObject cam = GameObject.Find("Camera");

        cam.GetComponent<CameraShake>().Shake();

        cam.GetComponent<SmoothMouseLook>().enabled = false;

        currentRot = new Vector3(-8.7f, 90f, 0f);
        currentQuaternionRot.eulerAngles = currentRot;
        cam.transform.localRotation = currentQuaternionRot;

        audio.PlayOneShot(clip);

        transform.SetParent(cam.transform.parent);
        transform.localPosition = new Vector3(2.86f, 0.43f, 0.6f);

        currentRot = new Vector3(0f, -100f, 0f);
        currentQuaternionRot.eulerAngles = currentRot;
        transform.localRotation = currentQuaternionRot;

        StartCoroutine(Rotate());

        scoreManager.CheckScore();

        loadings.EndGame();
    }

    IEnumerator Rotate()
    {
        while (incr < 260)
        {
            rot++;

            currentRot = new Vector3(rot, 0, 0);
            currentQuaternionRot.eulerAngles = currentRot;
            rigged.localRotation = currentQuaternionRot;

            yield return new WaitForSeconds(0.003f);

            incr++;
        }
    }
}
