using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded = true;
    private Rigidbody2D rigidBody2D;
    private float moveInput;
    public float speed;
    public float jumpForce;

    public float jumpTimeCounter;
    public float jumpTime;
    public float jumpCharge;
    public bool isJumping;
    public bool isCharging;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && (isGrounded))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidBody2D.velocity = new Vector2(moveInput * speed, jumpForce);
        }*/
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Space) )
        {
            
            if (jumpCharge <= 1.5)
            {
                jumpCharge += Time.deltaTime;
            }
            

        }
        

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigidBody2D.velocity = new Vector2(moveInput * speed, jumpForce * jumpCharge * 2);
            isCharging = false;
            jumpCharge = .20f;
            //isJumping = false;

        }

    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        //rigidBody2D.velocity = new Vector2(moveInput * speed, rigidBody2D.velocity.y);
    }
}

// grab horizontal movement. longer button is held, increase distance.
// grab jumpforce movement. longer space is held, increase height of jump.