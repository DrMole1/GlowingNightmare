using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    public float newSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            print("Vitesse changée");
            other.GetComponent<Chariot_Movement>().speed = newSpeed;
        }
    }


}
