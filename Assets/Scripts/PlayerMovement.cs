using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //a
    private float InputDirection;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float jumpPower;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void CheckInput()
    {
       InputDirection = Input.GetAxisRaw("Horizontal");

       if(InputDirection > 0)
       {
           spriteRenderer.flipX = false;
       }
       else if(InputDirection < 0)
       {
            spriteRenderer.flipX = true;
       }

       if(Input.GetButtonDown("Jump") && GroundCheck.isGrounded)
       {
            rb.velocity = new Vector2(rb.velocity.x,jumpPower);
       }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(playerMoveSpeed*InputDirection,rb.velocity.y);
    }
    
}
