using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveComum : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float shotTimer = 0.0f; 
    
    public float waitTime = 1.0f; 
    public float speed = 0.2f;    
    public float descidaY = 0.1f; 

    public Sprite imagemMissilInimigo;
    public float minTimeBetweenShots = 2.0f;
    public float chanceDeTiro = 0.1f;
    public int pontosAoDestruir = 10;

    public int lifes = 2;
    public bool isDead = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 vel = rb2d.velocity; 
        vel.x = speed;
        rb2d.velocity = vel;
        
        shotTimer = Random.Range(0f, minTimeBetweenShots);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime) 
        {
            ChangeState(); 
            timer = 0.0f;  
        }

        shotTimer += Time.deltaTime;
        if (shotTimer >= minTimeBetweenShots)
        {
            
            if (Random.value < chanceDeTiro)
            {
                AtirarMissilInimigo();
                shotTimer = 0.0f; 
            }
        }
    }

    void ChangeState() 
    {
        Vector2 vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
        transform.position = new Vector3(transform.position.x, transform.position.y - descidaY, transform.position.z); 
    }

    void AtirarMissilInimigo()
    {
        GameObject novoMissil = new GameObject("Missil_Inimigo"); 
        novoMissil.transform.position = transform.position;

        SpriteRenderer sr = novoMissil.AddComponent<SpriteRenderer>();
        sr.sprite = imagemMissilInimigo;
        sr.color = Color.red;

        Rigidbody2D rb = novoMissil.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        BoxCollider2D col = novoMissil.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        novoMissil.AddComponent<MissilEnemy>();
    }

    bool isPoint = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MissilPlayer"))
        {
            Destroy(collision.gameObject);

            lifes--;

            GetComponent<SpriteRenderer>().color = Color.gray; 

            if (lifes <= 0 && !isDead)
            {
                isDead = true; 

                if (PontuacaoManager.instancia != null)
                {
                    PontuacaoManager.instancia.AdicionarPontos(pontosAoDestruir);
                }

                Destroy(gameObject);
            }
        }
    }
}