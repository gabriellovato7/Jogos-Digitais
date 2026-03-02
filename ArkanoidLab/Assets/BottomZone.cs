using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            ScoreGame.instance.LoseLife();

            coll.gameObject.GetComponent<BallColision>().ResetBall();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
