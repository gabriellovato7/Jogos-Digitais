using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    void Update()
    {
        
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Enemy");

        if (inimigos.Length == 0)
        {
            VencerJogo();
        }
    }

    void VencerJogo()
    {
        SceneManager.LoadScene("VictoryScene"); 
    }
}
