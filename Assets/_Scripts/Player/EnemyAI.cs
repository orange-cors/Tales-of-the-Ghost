using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Chỉ số chiến đấu")]
    public float moveSpeed = 2f;        // Tốc độ đi tuần
    public float chaseSpeed = 4f;       // Tốc độ đuổi theo
    public float damage = 10f;          // Sát thương
    public float detectionRange = 5f;   // Tầm phát hiện (Vòng vàng)
    public float attackRange = 1.2f;    // Tầm vung đòn (Vòng đỏ)
    public float attackCooldown = 2f;   // Hồi chiêu

    [Header("Điểm đi tuần (Patrol)")]
    public Transform pointA;
    public Transform pointB;
    
    private Transform targetPoint;
    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    private float lastAttackTime;
    private bool isChasing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        // Tìm Player qua Tag
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
        isChasing = (distanceToPlayer <= detectionRange);

        // 2. Thực hiện hành động
        if (isChasing) ChaseAndAttack(distanceToPlayer);
        else Patrol();
    }

    void Patrol()
    {
        if (pointA == null || pointB == null) return;

        MoveTowards(targetPoint.position, moveSpeed);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            targetPoint = (targetPoint == pointB) ? pointA : pointB;
        }
    }

    void ChaseAndAttack(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {
            // Dừng lại để đánh
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); 
            if (animator != null) animator.SetBool("isMoving", false);

            if (Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            MoveTowards(player.position, chaseSpeed);
        }
    }

    void MoveTowards(Vector2 target, float speed)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        if (animator != null) animator.SetBool("isMoving", true);
        Flip(direction.x);
    }

    void Attack()
    {
        if (animator != null) animator.SetTrigger("Attack");

        // Thêm chữ All vào sau OverlapCircle
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Player"));

        foreach (Collider2D p in hitPlayers)
        {
            HealthSystem health = p.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Dạ Phong trúng đòn diện rộng!");
            }
        }
    }

    void Flip(float directionX)
    {
        if (directionX > 0.1f) transform.localScale = new Vector3(1, 1, 1);
        else if (directionX < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}