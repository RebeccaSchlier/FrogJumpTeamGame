
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour

{
    //background repeat
    private Vector3 startPos;
    private float repeatWidth;
    private float screenLengthMultiplier;
    
    public float speed;
    public PlayerController playerControllerScript;
    private float leftBound;
    public GameManager gameManager;

    // //Player movement and locations
    // private Vector3 transformPosition1;
    // private Vector3 transformPosition2;
    // public GameObject player1;
    // public GameObject player2;
    // private Vector3 offset = new Vector3(0, 3, 0);


    // //background movement
    // private Vector3 backgroundMovement;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent <GameManager>();
        gameManager.isGameActive = false;
    }
    void StartGame()
    {
        if (gameManager.isGameActive == true)
        {
            startPos = transform.position;
            repeatWidth = GetComponent <BoxCollider>().size.x;
            screenLengthMultiplier = 0.50f;
        
            playerControllerScript = GameObject.Find ("PlayerControllerScript").GetComponent <PlayerController> ();
        
        }
        

        // transformPosition1 = player1.transform.position + offset;
        // transformPosition2 = player2.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        //move background

         if (playerControllerScript.gameOver == false && gameManager.isGameActive == true)
        {
            transform.Translate (Vector3.left * Time.deltaTime * speed);
        }

        //Repeat background
        if ((transform.position.x)*screenLengthMultiplier < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }

    }

    // void LateUpdate()
    // {
       
    //     backgroundMovement = (transformPosition1 + transformPosition2)/2;
        
    // }
    


}
