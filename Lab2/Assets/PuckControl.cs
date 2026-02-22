using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {  
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
