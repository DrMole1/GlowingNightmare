using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            other.GetComponent<Diode>().OnTouch();
        }

        if (other.gameObject.name == "JackyEye")
        {
            other.transform.parent.GetComponent<CursedJacky>().Die();
        }
    }

    



}
