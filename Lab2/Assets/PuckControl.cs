using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public AudioSource source; 

    void Start()
    {  
        rb2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>(); 
    }

    public void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        source.Play(); 
    }
}