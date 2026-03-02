using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI textScore;    
    
    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        
        if (textScore != null)
        {
            textScore.text = "Pontuação Final: " + finalScore;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("IntroScene"); 
        }
    }
}
