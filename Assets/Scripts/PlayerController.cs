using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D mamaRb;
    public Rigidbody2D babyRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
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
        // OnCollisionEnter(true);

        //Baby frog code
        // if (babyFrog isOnGround)
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
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gameOver)
        {
            babyRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            // isOnGround = false;
            // doubleJumpUsed = false;
        }
        //tongue out
        if (Input.GetKey(KeyCode.Z) && !gameOver)
        {
            babyFrog.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

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
        if (Input.GetKeyDown(KeyCode.Alpha4) | Input.GetKeyDown(KeyCode.Keypad4))
        { if (isOnGround && !gameOver)
            {
                mamaRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        //inflate
        if (Input.GetKeyDown(KeyCode.Alpha7) | Input.GetKeyDown(KeyCode.Keypad7))
            {if  (isOnGround && !gameOver)
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
           

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            Debug.Log("Game Over!");
           
        }

    }

}



