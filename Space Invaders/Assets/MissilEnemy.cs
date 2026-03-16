using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilEnemy : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        if (transform.position.y < -10f) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TomarDano();
            }
            Destroy(gameObject);
        }
    }
}