using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInputs();
        Move();
        Flip();
    }

    void GetInputs()
    {
        dirX = Input.GetAxisRaw("Horizontal");
    
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);
    }

    void Flip()
    {
        if (dirX < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
           

        }
        else if (dirX > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
          
        }
    }
}
