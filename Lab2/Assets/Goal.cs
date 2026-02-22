using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Ball")) 
        {

            hitInfo.gameObject.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
