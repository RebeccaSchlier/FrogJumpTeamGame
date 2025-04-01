using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
 {   
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(5, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private int randomObstacle;
    public float speed = 30f;
    public float leftBounds = -6f;

    // Start is called before the first frame update
   void SpawnObstacle ()
    {
        if(!playerControllerScript.gameOver)
        {   
            randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomObstacle], spawnPos,
            obstaclePrefabs[randomObstacle].transform.rotation);

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x < leftBounds && gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
        }
    
    }
}