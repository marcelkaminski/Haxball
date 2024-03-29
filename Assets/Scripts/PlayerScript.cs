﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    public float playerSpeed;
    public bool kicking = false;
    public Sprite normalSprite;
    public Sprite kickSprite;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerKick();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * playerSpeed;
    }

    private void PlayerKick()
    {
        if (Input.GetKeyDown("space"))
        {
            kicking = true;
            sr.sprite = kickSprite; 
            Invoke("StopKicking", 0.05f);
        }
    }

    private void StopKicking()
    {
        kicking = false;
        sr.sprite = normalSprite; 
    }
}
