using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    // ===============================================
    public GameObject projectilePref;
    public Transform destination;
    public Transform firePoint;
    public Transform generator;
    public float projectileSpeed = 30f;
    public float arcRange = 1.2f;
    // ===============================================


    void Start()
    {
        StartCoroutine("ShootingProjectile");
    }


    /// <summary>
    /// Shoots a Magic Projectile every 3 seconds.
    /// </summary>
    IEnumerator ShootingProjectile()
    {
        GameObject projectile;
        projectile = Instantiate(projectilePref, firePoint.position, Quaternion.Euler(generator.rotation.x, generator.rotation.y, generator.rotation.z));

        projectile.GetComponent<Rigidbody>().velocity = (destination.position - firePoint.position).normalized * projectileSpeed;

        iTween.PunchPosition(projectile, new Vector3(UnityEngine.Random.Range(-arcRange, arcRange) * 2, UnityEngine.Random.Range(-arcRange, arcRange) * 2, 0f), 1f);
        StartCoroutine(PunchingAgain(projectile));

        yield return new WaitForSeconds(3f);

        StartCoroutine("ShootingProjectile");
    }


    /// <summary>
    /// Punch the projectile again if it not touch a wall.
    /// </summary>
    IEnumerator PunchingAgain(GameObject projectile)
    {
        yield return new WaitForSeconds(0.1f);

        if(projectile == null)
        {
            yield return 0;
        }
        else
        {
            iTween.PunchPosition(projectile, new Vector3(UnityEngine.Random.Range(-arcRange, arcRange) * 2, UnityEngine.Random.Range(-arcRange, arcRange) * 2, 0f), 1f);

            //StartCoroutine(PunchingAgain(projectile));
        }
    }
}

