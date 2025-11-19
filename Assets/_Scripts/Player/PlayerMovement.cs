using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Tốc độ chạy
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Nếu chưa có Anim thì bỏ dòng này tạm
    }

    void Update()
    {
        // Nhận diện phím A/D hoặc Mũi tên
        float horizontalInput = Input.GetAxis("Horizontal");

        // Di chuyển
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        // --- Xử lý xoay mặt (Flip) ---
        if (horizontalInput > 0.01f) // Đang chạy phải (D)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < -0.01f) // Đang chạy trái (A)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Lật ngược lại
        }
        
        // --- Gửi tín hiệu cho Animation (Nếu có) ---
        if (anim != null)
        {
             anim.SetBool("isRunning", horizontalInput != 0);
        }
    }
}