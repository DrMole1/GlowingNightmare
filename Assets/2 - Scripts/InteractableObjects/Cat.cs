using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public AudioClip clip;

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
    }

    public void Active()
    {
        if (!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().PlayOneShot(clip);      

        StartCoroutine(UnderGround());
    }

    IEnumerator UnderGround()
    {
        while (transform.localPosition.y >= 1.5f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.05f, transform.localPosition.z);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
