using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour // script attached to the Player object
{
    PlayerControls controls;

    //assign in Unity
    public Rigidbody2D playerRB;
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;

    float direction = 0;
    public float speed = 200f;
    public bool isFacingRight = true;
    public float jumpForce = 12f;
    bool isGrounded;
    int numberOfJumps = 0;

    // Awake é usado para pegar Inputs
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        //para pegar o input Move
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        //para pegar o input Jump
        controls.Land.Jump.performed += ctx => Jump();

    }

    // FixedUpdate é usando para mover objetos e com ele deve ser usado fixed.DeltaTime e não time.DeltaTime
    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(direction));

        if(isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            Flip();
        }

        // para verificar se o Player está tocando a groundLayer, usa o OverlapCircle, que vai pegar a posição do groundCheck e seu raio
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Water")
        {
            isGrounded = true;
            playerRB.gravityScale = 1;
            speed = 250f;
            jumpForce = 8f;
        }
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight; // o bool se torna falso
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("FirstJump");
        }
        else
        {
            if(numberOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
                AudioManager.instance.Play("SecondJump");
            }
        }
        
    }
}
