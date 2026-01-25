using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Cài đặt chung")]
    public float moveSpeed = 2f;        // Tốc độ đi tuần
    public float chaseSpeed = 4f;       // Tốc độ đuổi theo
    public float detectionRange = 5f;   // Tầm phát hiện Player
    public float attackRange = 1f;      // Tầm đánh
    public float attackCooldown = 2f;   // Hồi chiêu đánh

    [Header("Điểm đi tuần (Patrol)")]
    public Transform pointA;            // Điểm đầu
    public Transform pointB;            // Điểm cuối
    
    private Transform targetPoint;      // Điểm đang đi tới
    private Transform player;           // Vị trí Player
    private Animator animator;
    private Rigidbody2D rb;
    private float lastAttackTime;
    private bool isChasing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        // Tự tìm Player bằng Tag (Sếp nhớ gán Tag "Player" cho nhân vật nhé)
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;

        // Mặc định đi tới điểm B trước
        targetPoint = pointB;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 1. Kiểm tra trạng thái: Đuổi hay Đi tuần?
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // 2. Thực hiện hành động
        if (isChasing)
        {
            ChaseAndAttack(distanceToPlayer);
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        // Đi về phía mục tiêu (Point A hoặc Point B)
        MoveTowards(targetPoint.position, moveSpeed);

        // Nếu đến gần điểm mục tiêu thì đổi sang điểm kia
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            if (targetPoint == pointB) targetPoint = pointA;
            else targetPoint = pointB;
        }
    }

    void ChaseAndAttack(float distanceToPlayer)
    {
        // Nếu trong tầm đánh thì TẤN CÔNG
        if (distanceToPlayer <= attackRange)
        {
            // Dừng lại để đánh
            rb.linearVelocity = Vector2.zero; 
            if (animator != null) animator.SetBool("isMoving", false);

            if (Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // Nếu chưa tới tầm đánh thì ĐUỔI THEO
            MoveTowards(player.position, chaseSpeed);
        }
    }

    void MoveTowards(Vector2 target, float speed)
    {
        // Di chuyển
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        // Cập nhật Animation chạy
        if (animator != null) animator.SetBool("isMoving", true);

        // Lật mặt quái theo hướng đi
        Flip(direction.x);
    }

    void Attack()
    {
        if (animator != null) animator.SetTrigger("Attack");
        // Logic trừ máu Player sếp sẽ xử lý ở Animation Event hoặc dùng OverlapCircle như bài trước
    }

    void Flip(float directionX)
    {
        // Lật sang phải
        if (directionX > 0.1f) transform.localScale = new Vector3(1, 1, 1);
        // Lật sang trái
        else if (directionX < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
    }

    // Vẽ vòng tròn trong Scene để sếp dễ căn chỉnh
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange); // Vòng vàng: Tầm phát hiện

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);    // Vòng đỏ: Tầm đánh
        
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointA.position, pointB.position); // Đường xanh: Quãng đường đi tuần
        }
    }
}