using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreGame : MonoBehaviour
{
    public int score = 0;
    public int lives = 5;

    public int nextLive = 5;

    private int nextBallMilestone; 
    public GameObject originalBall; 
    public Transform spawnPoint;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public static ScoreGame instance;

    void Awake()
    {
        instance = this;
        score = PlayerPrefs.GetInt("CurrentScore", 0);
        lives = PlayerPrefs.GetInt("CurrentLives", 5);

        nextBallMilestone = score + 5;
    }

    void Start()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (livesText != null) livesText.text = "Vidas: " + lives;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;

        if (score >= nextLive)
        {
            lives++;

            if (livesText != null)
            {
                livesText.text = "Vidas: " + lives;
            }

            nextLive += 10;
            Debug.Log("Vida Extra: => " + lives);
        }

        if (score >= nextBallMilestone)
        {
            CreateNewBall();
            nextBallMilestone += 5; 
        }
    }

    public void CreateNewBall()
    {
       if (originalBall != null && spawnPoint != null)
        {
            GameObject novaBolinha = Instantiate(originalBall, spawnPoint.position, Quaternion.identity);
            
            Rigidbody2D rbNova = novaBolinha.GetComponent<Rigidbody2D>();
            if (rbNova != null)
            {
                Vector2 direcao = new Vector2(1, 1).normalized;
                rbNova.velocity = direcao * 5f; 
            }
        } 
    }

    public void LoseLife()
    {
        lives--;
        
        if (livesText != null)
        {
            livesText.text = "Vidas: " + lives;
        }

        if (lives <= 0)
        {
            PlayerPrefs.SetInt("FinalScore", score);

            SceneManager.LoadScene("GameOverScene");
            Debug.Log("Game Over!");
        }
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Brick");
        
        if(gos.Length == 0)
        {
            PlayerPrefs.SetInt("CurrentScore", score);
            PlayerPrefs.SetInt("CurrentLives", lives);

            if (scene.name == "SampleScene")
            {
                SceneManager.LoadScene("Scene1");
            }
            else if (scene.name == "Scene1")
            {
                SceneManager.LoadScene("Scene2");
            }
            else if (scene.name == "Scene2")
            {
                PlayerPrefs.SetInt("FinalScore", score);
                SceneManager.LoadScene("VictoryScene");
            }
        }
    }
}
