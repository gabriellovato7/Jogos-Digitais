using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform puck; 
    
    public float speed = 5f; 

    void Update()
    {
        Vector2 targetPos = new Vector2(puck.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -2.5f, 2.5f); 
        pos.y = Mathf.Clamp(pos.y, 0.2f, 4.5f);  
        transform.position = pos;
    }
}
