using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticles : MonoBehaviour
{
    public GameObject hitPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (hitPrefab)
        {
            GameObject hit = Instantiate(hitPrefab, transform.position, Quaternion.identity);
            Destroy(hit, 2f);
        }
    }
}
