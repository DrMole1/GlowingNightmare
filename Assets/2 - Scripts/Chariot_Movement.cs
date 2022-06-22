using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chariot_Movement : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
        StartCoroutine(temp());
    }

    [Range(0,5)]
    public float speed = .2f;

    private void Update()
    {
        anim.speed = speed;
    }

    IEnumerator temp()
    {
        yield return new WaitForSeconds(5f);
        anim.speed = speed;
    }

}
