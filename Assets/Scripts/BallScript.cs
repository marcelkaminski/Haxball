using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float kickForce = 1000;
    public GameManager gm;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
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
    }
}
