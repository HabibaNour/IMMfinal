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
    public TextMeshProUGUI highScoreText;
    
    
    private int score;
    // inital value for timer
    public  float timer = 60.0f;
    public bool isGameActive;
    public GameObject scoreGame;
   
    // game over scene objects
    public Image endScene;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public Button mainMenu;



    // Start is called before the first frame update
    void Start()
    {
       
        score = 50;   //when the game starts the score will start from 50. 
                      //the score will decrease each time the player get a bone
       
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
        if (score > 0) { 
        score += newScore;
        }
        else
        {
            GameOver();
        }
    }
    //will update text
    public void UpdateScore()
    {
        

        scoreText.text = "Score: " + score;  //the score will be showing in the scoring text in unity when the game is on
    }
   
   public void highScoreUpdate(){
       if(PlayerPrefs.HasKey("saveHighScore")){

        if(score > PlayerPrefs.GetInt("saveHighScore")){
            PlayerPrefs.SetInt("saveHighScore", score);
        }
       }
       else {
           PlayerPrefs.SetInt("saveHighScore", score);
       }
       finalScoreText.text = score.ToString();
       highScoreText.text = PlayerPrefs.GetInt("saveHighScore").ToString();
   }

    // will change what appears when the game is over
    public void GameOver()
    {

        gameOverText.gameObject.SetActive(true);   
        restartButton.gameObject.SetActive(true);   
        mainMenu.gameObject.SetActive(true);
        endScene.gameObject.SetActive(true);
        isGameActive = false;
    }
    //will restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
    // will load start menu
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
