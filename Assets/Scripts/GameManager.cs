using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //declarations
    public List <GameObject> targets;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    public GameObject titleScreen;
    private int lifeCount;
    public TextMeshProUGUI lifeText;

   
    // Start is called before the first frame update
    void Start()
    {
        // value definitions
      
    }

    public void StartGame(int difficulty)
    {
        spawnRate = spawnRate/difficulty;
        isGameActive = true;
        score = 0;
        

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
         
    }

    public void UpdateScore (int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
    public void UpdateLives (int livesToChange)
    {
        lifeCount += livesToChange;
        lifeText.text = "Lives: " + lifeCount;
        if (lifeCount <= 0)
        {
            GameOver();
        }
    }

    }
