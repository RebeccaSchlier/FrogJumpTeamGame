using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
 
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public GameManager gameManager;
    // public collision ground;
    public bool gameOver;

    private GameObject babyFrog;
    

    private GameObject mamaFrog;

    // // double jump
    // public bool doubleJumpUsed;
    // public float doubleJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // mamaRb = GetComponent<Rigidbody2D>();
        // playerRb.AddForce(Vector3.up *1000);
       
        Physics.gravity *= gravityModifier;
        isOnGround = true;
      
        // doubleJumpUsed = false;

        babyFrog = GameObject.Find("FrogGameSon");
        mamaFrog = GameObject.Find("FrogGameMom (1)");
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
           

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            gameManager.UpdateLives(-1);
            Destroy(gameObject);
           
        }
        else if (collision.gameObject.CompareTag("Fly"))
        {
            gameManager.UpdateScore(+3);
            Destroy(gameObject);
        }

    }

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

}



