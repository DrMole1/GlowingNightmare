using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // ===================================================================
    public GameObject impactProjectilePref;

    private Quaternion rotationGenerator;
    //private bool isCollided = false;
    // ===================================================================



    void Start()
    {
        if(GameObject.Find("Generateur_Projectiles") != null)
        {
            rotationGenerator = GameObject.Find("Generateur_Projectiles").transform.rotation;
        }
        else
        {
            print("The Projectiles Generator doesn't exist.");
        }
    }

    /// <summary>
    /// Collision method.
    /// </summary>
    /// <param name="collision">The component "Collision" of the object who gets collided with.</param>
    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Canon")
        {
            //isCollided = true;

            GameObject impactProjectile;
            impactProjectile = Instantiate(impactProjectilePref, collision.contacts[0].point, Quaternion.identity);

            //ParticleSystem ps1 = impactProjectile.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
            //var rotationY1 = ps1.main.startRotationY;
            //rotationY1 = rotationGenerator.eulerAngles.y;

            //ParticleSystem ps2 = impactProjectile.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>();
            //var rotationY2 = ps2.main.startRotationY;
            //rotationY2 = rotationGenerator.eulerAngles.y;

            //ParticleSystem ps3 = impactProjectile.transform.GetChild(5).gameObject.GetComponent<ParticleSystem>();
            //var rotationY3 = ps3.main.startRotationY;
            //rotationY3 = rotationGenerator.eulerAngles.y;

            //ParticleSystem ps4 = impactProjectile.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            //var rotationY4 = ps4.main.startRotationY;
            //rotationY4 = rotationGenerator.eulerAngles.y;

            Destroy(impactProjectile, 4f);

            Destroy(gameObject);
        }
    }
}
