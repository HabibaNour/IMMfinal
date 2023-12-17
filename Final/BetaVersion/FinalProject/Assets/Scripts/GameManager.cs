using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

//adding scoring Script
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finalScoreText;
 
    
    
    private int score;

    // inital value for timer
    public  float timer = 60.0f;
    public bool isGameActive;
    public GameObject scoreGame;
   
    // game over scene objects
    public Image endScene;
    public Button restartButton;
    public Button levelOneEndScene;
    public TextMeshProUGUI gameOverText;
    public Button mainMenu;
    public PlayerController playerController;



    // Start is called before the first frame update
    void Start()
    {
       
        score = 0;   //the score will start from 0 
       
    } 

    public void StartGame()
    {
        isGameActive = true;
        
        UpdateScore();
        

   
    }
    public void Update(){
       UpdateScore();
        // will create timer and make it decrease
        timer -= Time.deltaTime;
        timerText.SetText("Time: " + Mathf.Round(timer));
        
        if (timer < 1)
        {
            GameOver();
        }


    }
    // will update scores when bones are got
    public void AddScore(int newScore)
    {
        if (score < 50) { 
        score += newScore;
        timer += 5;   //the timer is going up for 5 seconds every time the player is scoring
        
        }
        else
        {
            SceneManager.LoadScene("LevelTwo");
        }
    }
    //will update text
    public void UpdateScore()
    {
        

        scoreText.text = "Score: " + score;  //the score will be showing in the scoring text in unity when the game is on
    }
   // will show final score on game over scene 
   public void finalScoreUpdate(){
       
       
       finalScoreText.text = "Final Score: " + score.ToString();
       
   }

    // will change what appears when the game is over
    public void GameOver()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
            endScene.gameObject.SetActive(true);
            finalScoreText.gameObject.SetActive(true);
           
            isGameActive = false;

            finalScoreUpdate();
        }
        else if  (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            // adds button so player can go to previous level
            levelOneEndScene.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
            endScene.gameObject.SetActive(true);
            finalScoreText.gameObject.SetActive(true);
           
            isGameActive = false;
            finalScoreUpdate();
        }
    }
    //will restart game to active scene
    public void RestartGame()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne") {
            SceneManager.LoadScene("LevelOne");
        }
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            SceneManager.LoadScene("LevelTwo");
        }
                    
    }
    // will load level one
    public void LevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }
    // will load start menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Opening");
    }


}
