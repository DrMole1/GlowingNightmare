using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairEnabler : MonoBehaviour
{
    public GameObject crosshair;

    public float time;

    private void Start()
    {
        crosshair.SetActive(false);
        StartCoroutine(activate());
    }

    IEnumerator activate()
    {
        yield return new WaitForSeconds(time);
        crosshair.SetActive(true);
    }



}
