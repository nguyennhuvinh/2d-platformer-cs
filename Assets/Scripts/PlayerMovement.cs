using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX = 0f;
    private BoxCollider2D coll;
    private bool isFacingRight = true;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpPower;

   
    public LayerMask groundLayer;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        GetInputs();
        Move();
        Flip();
        Jump();
        
    }

    void GetInputs()
    {
        dirX = Input.GetAxisRaw("Horizontal");
    
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);
    }


    private void Flip()
    {
        if ((isFacingRight && dirX < 0) || (!isFacingRight && dirX > 0))
        {
             isFacingRight = !isFacingRight;
             transform.Rotate(0.0f, 180.0f, 0.0f);
         }
        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            audioManager.PlayerSFX(audioManager.Jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
