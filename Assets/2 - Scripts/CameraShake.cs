using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private const float MICROVALUETOADD = 1f;

    private Camera cam;
    private float startingSize;
    private bool isShaking = false;

    private void Start()
    {
        cam = GetComponent<Camera>();
        startingSize = cam.fieldOfView;
    }

    public void Shake()
    {
        if (isShaking)
            return;

        StartCoroutine(CoroutineShake());
        isShaking = true;
    }


    IEnumerator CoroutineShake()
    {
        while(cam.fieldOfView < startingSize + MICROVALUETOADD * 10)
        {
            yield return new WaitForSeconds(0.005f);
            cam.fieldOfView += MICROVALUETOADD;
        }

        while (cam.fieldOfView > startingSize)
        {
            yield return new WaitForSeconds(0.005f);
            cam.fieldOfView -= MICROVALUETOADD;
        }

        print("shaked");

        isShaking = false;
    }
}
