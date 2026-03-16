using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMae : MonoBehaviour
{
    public float speed = 5.0f; 
    public float limiteDireito = 12f;
    public int pontosAoDestruir = 50; 

    private bool isPoint = false; 
    public int lifes = 3;
    public bool isDead = false;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        if (transform.position.x > limiteDireito)
        {
            Destroy(gameObject);
        }
    }
    
void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MissilPlayer")) 
        {       
            Destroy(collision.gameObject);

            lifes--;

            // StartCoroutine(EfeitoDano());

            if (lifes <= 0 && !isPoint)
            {
                isPoint = true; 

                if (PontuacaoManager.instancia != null)
                {
                    PontuacaoManager.instancia.AdicionarPontos(pontosAoDestruir);
                }

                Destroy(gameObject);
            }
        }
    }
}