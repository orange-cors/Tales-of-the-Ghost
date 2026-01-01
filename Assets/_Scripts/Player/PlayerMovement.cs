using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Cài đặt")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform visualContainer; // Kéo object "Visual" vào đây

    [Header("Kiểm tra đất")]
    public Transform groundCheck;     // Kéo object GroundCheck ở chân vào đây
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;     // Chọn layer Ground

    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    private bool isGrounded;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Anim nằm ở object con (Visual) hoặc chính nó, tùy cách bạn sắp xếp
        anim = GetComponentInChildren<Animator>(); 
    }

    void Update()
    {
        // 1. Nhận Input
        moveInput = Input.GetAxisRaw("Horizontal");

        // 2. Nhảy
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 3. Xử lý Animation
        UpdateAnimation();

        // 4. Xử lý Lật hình (Flip)
        if (moveInput > 0 && !isFacingRight) Flip();
        else if (moveInput < 0 && isFacingRight) Flip();
    }

    void FixedUpdate()
    {
        // 5. Di chuyển vật lý
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void UpdateAnimation()
    {
        if (anim != null)
        {
            // Chuyển trạng thái chạy/đứng
            // Mathf.Abs(moveInput) > 0 nghĩa là có bấm nút di chuyển
            anim.SetBool("isRunning", Mathf.Abs(moveInput) > 0);
            
            // Chuyển trạng thái nhảy/rơi
            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("yVelocity", rb.linearVelocity.y);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        // Chỉ lật phần hình ảnh (Visual), không lật cả cục Player
        Vector3 scale = visualContainer.localScale;
        scale.x *= -1;
        visualContainer.localScale = scale;
    }

    // Vẽ vòng tròn check đất để dễ nhìn trong Editor
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}