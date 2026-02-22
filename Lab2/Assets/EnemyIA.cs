using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform puck; 
    public float speed = 15f; 
    
    private Rigidbody2D rb2d;
    private Vector2 startPosition;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position; 
    }

    void Update()
    {
        Vector2 targetPos;

        if (puck.position.y > 0)
        {
            targetPos = new Vector2(puck.position.x, puck.position.y);
        }
        else
        {
            targetPos = startPosition;
        }

        targetPos.x = Mathf.Clamp(targetPos.x, -2.5f, 2.5f); 
        targetPos.y = Mathf.Clamp(targetPos.y, 0.2f, 4.5f);  

        Vector2 dir = targetPos - (Vector2)transform.position;

        if (dir.magnitude < 0.1f)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }

        rb2d.velocity = dir.normalized * speed;
    }
}