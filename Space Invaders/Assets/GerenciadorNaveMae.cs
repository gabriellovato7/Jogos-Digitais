using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorNaveMae : MonoBehaviour
{
    public Sprite spriteNaveMae; 
    public float yPos = 4.5f;    
    public float xSpawn = -12f;  

    void Start()
    {
        Invoke("SpawnNaveMae", 10f); 
    }

    void SpawnNaveMae()
    {
        GameObject nave = new GameObject("NaveMae");
        nave.transform.position = new Vector3(xSpawn, yPos, 0);
        nave.tag = "Enemy";

        SpriteRenderer sr = nave.AddComponent<SpriteRenderer>();
        sr.sprite = spriteNaveMae;
        sr.sortingOrder = 1;

        Rigidbody2D rb = nave.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        BoxCollider2D col = nave.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        nave.AddComponent<NaveMae>();

        Invoke("SpawnNaveMae", 10f); 
    }
}
