using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawnManager : MonoBehaviour
{
    public GameObject[] flyPrefabs;
  
    private float spawnMaxX = -.6f;
    private float spawnMinY = -1f;
    private float spawnMaxY = 1.21f;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Spawn animals automatically every startDeley(2sec). 
        InvokeRepeating("SpawnFly",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S)) SpawnRandomAnimal();

    }
    public void SpawnFly()
    {
        //randomly create an animal from the animalPrefabs 
        int flyIndex = Random.Range(0, flyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnMaxX, Random.Range(spawnMinY, spawnMaxY), 0);
        Instantiate(flyPrefabs[flyIndex], spawnPos, flyPrefabs[flyIndex].transform.rotation);
    }
}
