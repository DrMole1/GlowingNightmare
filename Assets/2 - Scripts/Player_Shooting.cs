using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Camera cam;
    
    public float bulletSpeed = 2;

    public AudioClip clip;

    public float delay = 0.15f;
    private float timer = 0;
    private bool canShoot = true;

    private void Update()
    {
        if(!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                canShoot = true;
                timer = 0;
            }
        }

        //Gère le projectile
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = false;

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //sphere.transform.position = hit.point;
                GameObject tir = Instantiate(bulletPrefab, cam.transform.position, Quaternion.identity);
                tir.GetComponent<Rigidbody>().velocity = cam.transform.forward * bulletSpeed;
                Destroy(tir, 3f);

                GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }



        

    }
}
