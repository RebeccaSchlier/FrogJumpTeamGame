using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{
    public float speed = 10f;

    public Rigidbody2D babyRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public GameManager gameManager;
    // public collision ground;
    public bool gameOver;

    private GameObject babyFrog;


    private GameObject mamaFrog;

  

    // Start is called before the first frame update
    void Start()
    {
      

        Physics.gravity *= gravityModifier;
        isOnGround = true;

        // doubleJumpUsed = false;

        babyFrog = GameObject.Find("FrogGameSon");

    }

    // Update is called once per frame
    void Update()
    {


        //Baby frog code
      
        //right
        if (Input.GetKey(KeyCode.D))
        {
            babyFrog.transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            babyFrog.transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            babyRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            // isOnGround = false;
            // doubleJumpUsed = false;
        }
        //tongue out
        //if (Input.GetKey(KeyCode.Z) && !gameOver)
        //{
        //    babyFrog.transform.Translate(Vector3.left * speed * Time.deltaTime);
        //
    }
   // void OnTriggerEnter2D(Collider2D collision)
   // {
    //    if (co.gameObject.CompareTag("Ground"))
     //   {

      //      isOnGround = true;
    //    }
  //  }
        void OnTriggerEnter2D(Collider2D other)
        {
        if (other.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
            {

                gameManager.UpdateLives(-1);
                Destroy(other.gameObject);

            }
            else if (other.gameObject.CompareTag("Fly"))
            {
                gameManager.UpdateScore(+3);
                Destroy(other.gameObject);
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

