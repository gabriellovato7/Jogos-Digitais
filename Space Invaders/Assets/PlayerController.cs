using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    
    public float xLimit = 10f; 

    public GameObject missilPrefab; 
    public Transform firePoint;     
    
    public int lives = 3; 

    public float tempoEntreTiros = 0.5f; 
    private float proximoTiro = 0f;

    void Update()
    {
        Movimentar();
        Atirar();
    }

    void Movimentar()
    {
        float inputX = Input.GetAxis("Horizontal"); 

        Vector3 novaPosicao = transform.position + Vector3.right * inputX * speed * Time.deltaTime;


        novaPosicao.x = Mathf.Clamp(novaPosicao.x, -xLimit, xLimit);

        transform.position = novaPosicao;
    }

    void Atirar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > proximoTiro)
        {
            proximoTiro = Time.time + tempoEntreTiros;
            if (missilPrefab != null && firePoint != null)
            {
                Instantiate(missilPrefab, firePoint.position, Quaternion.identity);
            }
        }
    }

    public void TomarDano()
    {
        lives--;

        if (lives <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
