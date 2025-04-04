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
    private float maxTorque;
    private float yRange;
    private float xPos;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    private int lifeCount;
    public TextMeshProUGUI lifeText;
    

    // Start is called before the first frame update
    void Start()
    {
        //value definitions
        minSpeed = 12;
        maxSpeed = 16;
        maxTorque = 10;
        xPos = 17;
        yRange = 1;
        lifeCount = 3;

        //reg code
        targetRb = GetComponent<Rigidbody2D>();
        targetRb.AddForce (RandomForce(),ForceMode2D.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.left * Random.Range(minSpeed, maxSpeed);
    }
    

    

    Vector3 RandomSpawnPos()
    {
        return new Vector3(xPos,Random.Range(-yRange, yRange));
    }

    private void TongueOut()
    {
        if (gameManager.isGameActive)
        {if
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);

            if (gameObject.CompareTag("Bad") && gameManager.isGameActive)
            {
                gameManager.UpdateLives(-1);
           
            } 

        }
    }

    // private void OnTriggerEnter (Collider other)
    // {
    //     Destroy(gameObject);
       
    // }

    public void UpdateLives ()
    {
        lifeCount -= 1;
        lifeText.text = "Lives: " + lifeCount;
    }
}
