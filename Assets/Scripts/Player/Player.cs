using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : SingletonMonobehavior<Player>
{
    private Rigidbody2D rigidBody2D;
    public LayerMask groundMask;
    public PhysicsMaterial2D playerMaterial, playerBounceMaterial;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    public float moveInput;
    public float speed;
    public float jumpForce;
    public float jumpTimeCounter;
    public float jumpTime;
    public float jumpCharge;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement

        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
        CheckGroundCollision();
        SetPlayerMaterial();

        // Spacebar down 
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            ChargeJump();
        }

        // Spacebar release
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded == true)
        {
            ReleaseJump();
        }

        #endregion

    }

    void FixedUpdate()
    {
        
    }

    private void ChargeJump()
    {
        if (jumpCharge <= 1.5)
        {
            jumpCharge += Time.deltaTime * 2;
        }

    }

    private void ReleaseJump()
    { 
        rigidBody2D.velocity = new Vector2(moveInput * speed, jumpForce * jumpCharge * 2);
        //jumpCharge = .10f;
        jumpCharge = 0f;
        
    }

    private void SetPlayerMaterial()    
    {
        if (isGrounded)
        {
            rigidBody2D.sharedMaterial = playerMaterial;
        }
        else
        {
            rigidBody2D.sharedMaterial = playerBounceMaterial;
        }
    }

    private void CheckGroundCollision()
    {
        // Ground dectection, draws an invisible box at base of player, checks for ground overlap, and sets isGrounded to true if overlap is found.
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.4f), 0f, groundMask);
    }
    

    
}


