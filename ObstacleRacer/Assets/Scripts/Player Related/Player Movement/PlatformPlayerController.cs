using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
   
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    
    public float coyoteTime = 0.1f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float fallingSpeed = 2f;

    //wall jump
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    private bool isJumping;
    private float jumpTimeCounter;

    //Walljump related vars
    public Vector2 wallJumpPower = new Vector2(8f, 16f);
    private bool isWallJumping;
    private float wallJumpingDirection;
    [SerializeField] private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.2f;
    [SerializeField] ForceMode2D forceMode;
    
    private Animator animator;
    [SerializeField] private AudioClip jumpSoundClip;
   
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    public playerSlide pS;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Coyote Time: Allow jumping shortly after leaving the ground
        if (isGrounded)
        {
            jumpTimeCounter = coyoteTime;
        }
        else
        {
            jumpTimeCounter -= Time.deltaTime;
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpTimeCounter > 0 /*&& !OnWall()*/)&& !PauseMenu.isPaused)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpTimeCounter = 0;
            //SoundFXManager.instance.PlaySoundFXCLip(jumpSoundClip, transform, 1f);
        }
        WallJump();

        // Variable Jump Height: Allow higher jumps by holding the jump button
        if (Input.GetButtonUp("Jump") && isJumping && !isWallJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
            isJumping = false;
        }
        if (rb.velocity.y < 0 && !isGrounded)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallingSpeed - 1) * Time.deltaTime;
        }

        WallSlide();
    }

    void FixedUpdate()
    {
        if(isWallJumping)
        {
            return;
        }
        if(!isGrounded && horizontalInput==0)
        {
            return;
        }
        if(!pS.isSliding)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
        // Flip the player sprite based on movement direction
        if (horizontalInput > 0 && !PauseMenu.isPaused)
        {
            transform.localScale = new Vector3(2f, 2f, 1f); // Facing right
        }
        else if (horizontalInput < 0 && !PauseMenu.isPaused)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f); // Facing Left
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the ground check radius in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(wallCheck.position, 0.2f);
    }

    public bool OnWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (OnWall() && !isGrounded &&horizontalInput!=0f )
        {
            isWallSliding = true;
            rb.velocity  = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y,-wallSlidingSpeed,float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") && wallJumpingCounter>0f)
        {
            isWallJumping = true;
            if (wallJumpingDirection > 0)
            {
                rb.AddForce(wallJumpPower, forceMode);
            }
            else
            {
                rb.AddForce(new Vector2(-wallJumpPower.x, wallJumpPower.y), forceMode);
            }
            if(rb.velocity.y >16f)
            {
                rb.velocity = new Vector2(rb.velocity.x,16f);
            }
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;

            }

            if (rb.velocity.y < 0 && !isGrounded)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallingSpeed - 1) * Time.deltaTime;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
        rb.velocity = new Vector2(rb.velocity.x, 5f);
    }
    public float getHorizontalInput() { return horizontalInput;}
}
