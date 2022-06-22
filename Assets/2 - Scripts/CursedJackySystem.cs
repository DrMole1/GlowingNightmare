using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedJackySystem : MonoBehaviour
{

    public GameObject jackyPrefab;
    private GameObject currentJacky = default;

    private Transform player = default;

    public float distance = 10f;

    public Transform[] spawnPositions = new Transform[4];

    private bool[] hasSpawned;
    
    private void Awake()
    {
        player = GameObject.Find("WAGON").transform;

        hasSpawned = new bool[spawnPositions.Length];
    }
    
    private void Update()
    {
        for (int i = 0; i < spawnPositions.Length - 1; i++)
        {
            if (playerIsCloseToPos(spawnPositions[i]) && hasSpawned[i] == false)
            {
                SpawnJacky(i);
                hasSpawned[i] = true;
            }
        }
    }

    private bool playerIsCloseToPos(Transform pos)
    {
        Vector3 pPos = pos.position;

        if (Vector3.Distance(player.position, pPos) < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
           
        
    }


    private void SpawnJacky(int id = -1)
    {
        int index = Random.Range(0, spawnPositions.Length-1);

        if (id != -1)
            index = id;

        int alea = Random.Range(0, 4);
        if(alea <= 3)
            currentJacky = Instantiate(jackyPrefab, spawnPositions[index].position, spawnPositions[index].rotation, transform);

        GetComponent<AudioSource>().Play();
    }


}
