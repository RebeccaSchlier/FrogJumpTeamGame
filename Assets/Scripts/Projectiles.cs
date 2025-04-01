using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectiles : MonoBehaviour
{
    //declarations
    private Rigidbody2D targetRb;
    private float minSpeed;
    private float maxSpeed;
    // private float maxTorque;
    // private float yRange;
    // private float xPos;
    private GameManager gameManager;
    public int pointValue;
    // private int lifeCount;
    public TextMeshProUGUI lifeText;
    private PlayerController playerControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        //value definitions
        minSpeed = 1.5f;
        maxSpeed = 3f;
        // maxTorque = 10;
        // xPos = 17;
        // yRange = 1;
        // lifeCount = 3;

        //reg code
        targetRb = GetComponent<Rigidbody2D>();
        targetRb.AddForce (RandomForce(),ForceMode2D.Impulse);
        // transform.position = RandomSpawnPos();
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
        playerControllerScript = GameObject.Find ("PlayerControllerScript").GetComponent<PlayerController>();
        // TongueOut();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.left * Time.deltaTime * Random.Range(minSpeed, maxSpeed));
    }
        
    

    Vector3 RandomForce()
    {
        return Vector3.left * Random.Range(minSpeed, maxSpeed);
    }
    

    

    // Vector3 RandomSpawnPos()
    // {
    //     return new Vector3(xPos,Random.Range(-yRange, yRange));
    // }

    // private void TongueOut()
    // {
    //     if (gameManager.isGameActive)
    //     { if (Input.GetKey(KeyCode.Z))
    //         {Destroy(gameObject);
    //         gameManager.UpdateScore(pointValue);

    //         if (gameObject.CompareTag("Bad") && gameManager.isGameActive)
    //         {
    //             gameManager.UpdateLives(-1);
           
    //         } 
    //         }
    //     }
    // }

    // private void OnTriggerEnter (Collider other)
    // {
    //     Destroy(gameObject);
       
    // }


    
}
