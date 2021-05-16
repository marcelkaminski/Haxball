using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallScript : NetworkBehaviour
{
    private Rigidbody2D rb;
    //public float kickForce = 1000;
    public GameManager GameManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager = GameObject.Find("GameManager(Clone)").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D (Collider2D collider) 
    {
        if(collider.tag == "Goal_Blue") 
        {
            GameManager.UpdateScore("red");
        }
        else if(collider.tag == "Goal_Red")
        {
            GameManager.UpdateScore("blue");
        }
    }

    /*
    void TakeDamage (int amount)
    {
        if(this.isServer)
        {
            RpcRespawn();
        }
    }


    [ClientRpc]
    void RpcRespawn()
    {
        return 0;
    }

    //void OnCollisionStay2D(Collision2D other)
    //{
    //    if((other.transform.CompareTag("Player_Red") || other.transform.CompareTag("Player_Blue")) && other.transform.GetComponent<PlayerScript>().kicking)
    //    {
    //        Vector2 direction = (other.transform.position - transform.position).normalized;
    //        rb.AddForce(-direction * kickForce);
    //    }
    //}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Goal_Red"))
        {
            gm.UpdateScore("blue");
        }
        else if (other.transform.CompareTag("Goal_Blue"))
        {
            gm.UpdateScore("red");
        }
    }

    public void ResetBallPosition()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }*/
}

