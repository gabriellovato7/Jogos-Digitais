using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    public float speed = 25f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 playerPos = transform.position; 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        mousePos.y = Mathf.Clamp(mousePos.y, -4.5f, -0.2f);
        mousePos.x = Mathf.Clamp(mousePos.x, -4f, 4f);

        Vector3 dir = mousePos - playerPos; 

        dir.Normalize(); 
        Vector3 speedVec = dir * speed; 

        Vector2 vel = rb2d.velocity; 
        vel.x = speedVec.x;
        vel.y = speedVec.y; 
        rb2d.velocity = vel;
    }
}
