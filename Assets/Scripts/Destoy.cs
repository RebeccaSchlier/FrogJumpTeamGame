using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoy : MonoBehaviour
{   private float topBounds = 3f;
    private float lowerBounds = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If an object goes pass the player view in the game, remove that object
        if(transform.position.z > topBounds)
        { 
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBounds)
        {
            //show game over in the Log
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}

