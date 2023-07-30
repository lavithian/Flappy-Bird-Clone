using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOver;
    public PipeMove pipeMove;
    public int highscore = 0;
    public Text highscoreText;
    // [ContextMenu("Increase Score")]

    private string highScoreKey = "HighScore";

    private void Start()
    {
        pipeMove = GameObject.FindGameObjectWithTag("pipemove").GetComponent<PipeMove>();
    }
    
    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
        if (score % 5 == 0)
        {
            pipeMove.moveSpeed += 1;
            Debug.Log("moveSpeed: " + pipeMove.moveSpeed);
        }
    }
    
    public void restartScene()
    {
        SaveHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void gameOverScreen()
    {
        SaveHighScore();
        gameOver.SetActive(true);
    }

    private void LoadHighScore()
    {
        highscore = PlayerPrefs.GetInt(highScoreKey, 0);
        highscoreText.text = "High Score: " + highscore.ToString();
    }

    private void SaveHighScore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(highScoreKey, highscore);
            PlayerPrefs.Save();
            highscoreText.text = "High Score: " + highscore.ToString();
        }
    }
}
