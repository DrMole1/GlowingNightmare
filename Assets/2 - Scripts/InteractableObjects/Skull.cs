using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public AudioClip[] clips;

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
    }

    public void Active()
    {
        int choice = UnityEngine.Random.Range(0, 2);

        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().PlayOneShot(clips[choice]);
        }

        StartCoroutine(UnderGround());
    }

    IEnumerator UnderGround()
    {
        while(transform.localPosition.y >= -1.5f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.05f, transform.localPosition.z);

            yield return new WaitForSeconds(0.05f);
        }

        Destroy(gameObject);
    }
}
