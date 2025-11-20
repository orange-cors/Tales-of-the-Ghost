using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius = 0.08f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer[] allSprites;
    private bool isGrounded;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        allSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // Check ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Move
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
        }

        // Flip
        if (horizontalInput > 0.01f && !facingRight)
        {
            FlipAllSprites(false);
            facingRight = true;
        }
        else if (horizontalInput < -0.01f && facingRight)
        {
            FlipAllSprites(true);
            facingRight = false;
        }

        // Animation
        anim.SetBool("isRunning", horizontalInput != 0);
        anim.SetBool("isJumping", !isGrounded);
    }

    void FlipAllSprites(bool flipX)
    {
        foreach (var s in allSprites)
            s.flipX = flipX;
    }
}
