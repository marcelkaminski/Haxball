﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public float kickForce = 1000;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player") && other.transform.GetComponent<PlayerScript>().kicking)
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(-direction * kickForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Goal_Red"))
        {
            Debug.Log("Pilka wpadla do bramki czerwonej");
        }
        else if (other.transform.CompareTag("Goal_Blue"))
        {
            Debug.Log("Pilka wpadla do bramki niebieskiej");
        }
    }
}