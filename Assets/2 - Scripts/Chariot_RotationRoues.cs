using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chariot_RotationRoues : MonoBehaviour
{
    public Transform leftWheel;
    public Transform rightWheel;
    public Transform backWheel1;
    public Transform backWheel2;

    public float rotatingSpeed = - 10;

    private void Update()
    {

        rotateWheel(leftWheel);
        rotateWheel(rightWheel);
        rotateWheel(backWheel1);
        rotateWheel(backWheel2);

    }

    public void rotateWheel(Transform wheel)
    {
        if (wheel)
            wheel.Rotate(Vector3.up, rotatingSpeed * -1);
    }
}
