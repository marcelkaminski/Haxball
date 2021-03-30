using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    public float playerSpeed;
    public bool kicking = false;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            Invoke("StopKicking", 0.1f);
        }
    }

    private void StopKicking()
    {
        kicking = false;
    }
}
