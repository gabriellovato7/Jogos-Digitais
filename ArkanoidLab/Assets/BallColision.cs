using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColision : MonoBehaviour
{

    public float speed = 100f; 
    public Rigidbody2D rb;

    public bool isGameStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 initialDirection = new Vector2(-1, -1).normalized;
            rb.velocity = initialDirection * speed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Brick"){
            ScoreGame.instance.AddScore(1);
            Destroy(coll.gameObject);  
        }
    }

    public void ResetBall()
    {
        transform.position = new Vector3(0f, -2f, 0f); 

        Vector2 initialDirection = new Vector2(-1, -1).normalized;
        rb.velocity = initialDirection * speed;
    }

}
