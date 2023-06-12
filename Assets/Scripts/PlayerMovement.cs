using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;

    private enum MovementState { idle, running, jumping, falling, flying }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        switch (GameManager.Instance.currentItemState)
        {
            case ItemState.Sober:
                SoberMovement();
                break;
            case ItemState.Jibit:
                JibitMovement();
                break;
            case ItemState.Vodka:

                break;
            case ItemState.LSD:

                break;
        }



    }

    //Sober
    void SoberMovement()
    {
        moveSpeed = 7f;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log("Jump");
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        SoberUpdateAnimation();
    }

    private void SoberUpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
        }
        else
        {
            state = MovementState.idle;
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
        }

        if (rb.velocity.y > .01f)
        {
            state = MovementState.jumping;
            anim.SetBool("isJumping", true);
        }
        else if (rb.velocity.y < -.01f)
        {
            state = MovementState.falling;
            anim.SetBool("isJumping", false);
        }

        //  anim.SetInteger("state", (int)state);
    }

    //Jibit
    void JibitMovement()
    {
        moveSpeed = 5f;
        rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);

        JibitUpdateAnimation();
    }

    private void JibitUpdateAnimation()
    {
        MovementState state;

        
        if (IsGrounded())
        {
            if (dirX > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
                anim.SetBool("isRunning", true);
                anim.SetBool("isJumping", false);
                anim.SetBool("isFlying", false);
            }
            else if (dirX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
                anim.SetBool("isRunning", true);
                anim.SetBool("isJumping", false);
                anim.SetBool("isFlying", false);
            }
            else
            {
                state = MovementState.idle;
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", false);
                anim.SetBool("isFlying", false);
            }

        }
        else
        {
            state = MovementState.flying;

            if (dirX > 0f)
            {
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                sprite.flipX = true;
            }
            Debug.LogWarning("FYLING")
                ;
            
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFlying", true);
        }


        //  anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
