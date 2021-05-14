using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    public float playerSpeed;
    //public bool kicking = false;
    //public Sprite normalSprite;
    //public Sprite kickSprite;

    //public SpriteRenderer sr;


    //void Start()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //}

    //[Command]
    //void Update()
    //{
    //    if (!hasAuthority) {return;}
    //   PlayerKick();
    //}
    
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

    //void PlayerKick()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        kicking = true;
    //        sr.sprite = kickSprite; 
    //        Invoke("StopKicking", 0.05f);
    //    }
    //}

    //void StopKicking()
    //{
    //   kicking = false;
    //    sr.sprite = normalSprite; 
    //}
}
