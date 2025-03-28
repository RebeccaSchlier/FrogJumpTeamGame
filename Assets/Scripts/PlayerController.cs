using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    // public collision ground;
    public bool gameOver;

    // double jump
    public bool doubleJumpUsed;
    public float doubleJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        // playerRb.AddForce(Vector3.up *1000);
       
        Physics.gravity *= gravityModifier;
        isOnGround = true;
      
        doubleJumpUsed = false;

    }

    // Update is called once per frame
    void Update()
    {
        // OnCollisionEnter(true);
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            doubleJumpUsed = false;
        }

        // if space is pressed AND the character is not on the ground AND hasn't double jumped yet
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJumpUsed)
        {
            // makes sure the player can't double jump more than 1 time
            doubleJumpUsed = true;

            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode2D.Impulse);

        }
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



