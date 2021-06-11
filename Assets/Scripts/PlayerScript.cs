using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    public float playerSpeed;
    public bool kicking = false;
    public Sprite normalSprite;
    public Sprite kickSprite;
    public SpriteRenderer sr;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!hasAuthority) {return;}
        if (Input.GetKeyDown("space"))
        {
            StartKick();
            StartKickSprite();
            Invoke("StopKick", 0.05f);
            Invoke("StopKickSprite", 0.05f);
        }
    }
    
    [Client]
    void FixedUpdate()
    {
        if (!hasAuthority) {return;}
        PlayerMovement();
    }
    
    void PlayerMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement *= Time.deltaTime * playerSpeed;
        transform.Translate(movement);
    }

    [Command]
    void StartKick()
    {
        kicking = true;
    }

    [Command]
    void StopKick()
    {
        kicking = false;
    }

    void StartKickSprite()
    {
        sr.sprite = kickSprite; 
    }

    void StopKickSprite()
    {
        sr.sprite = normalSprite; 
    }
}
