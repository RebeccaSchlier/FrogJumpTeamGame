using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D mamaRb;
  
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public GameManager gameManager;
    // public collision ground;
    public bool gameOver;



    private GameObject mamaFrog;


    // Start is called before the first frame update
    void Start()
    {
     

        Physics.gravity *= gravityModifier;
        isOnGround = true;

        // doubleJumpUsed = false;

        mamaFrog = GameObject.Find("FrogGameMom (1)");
    }

    // Update is called once per frame
    void Update()
    {
        //Mama Frog code
        //right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mamaFrog.transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        //left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mamaFrog.transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        //jump
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (isOnGround && !gameOver)
            {
                mamaRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        //inflate
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            if (isOnGround && !gameOver)
            {
                mamaRb.AddForce(Vector3.right * jumpForce, ForceMode2D.Impulse);
            }
        }



        // if space is pressed AND the character is not on the ground AND hasn't double jumped yet
        // else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJumpUsed)
        // {
        //     // makes sure the player can't double jump more than 1 time
        //     doubleJumpUsed = true;

        //     playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode2D.Impulse);

        // }


    }


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
