using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public AudioClip clip;

    private int incr = 0;
    private float rot;
    private Vector3 currentRot;
    private Quaternion currentQuaternionRot;


    public void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        rot = transform.localRotation.y;
    }

    public void Active()
    {
        if(!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().PlayOneShot(clip);

        incr = 0;

        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (incr < 360)
        {
            rot++;

            currentRot = new Vector3(0, rot, 0);
            currentQuaternionRot.eulerAngles = currentRot;
            transform.localRotation = currentQuaternionRot;

            yield return new WaitForSeconds(0.01f);

            incr++;
        }
    }
}
