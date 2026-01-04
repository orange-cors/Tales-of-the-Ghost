using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint; // Kéo cái AttackPoint sếp vừa tạo vào đây
    public float attackRange = 0.5f; // Bán kính vòng tròn sát thương
    public LayerMask enemyLayers; // Chọn Layer của quái (để không chém nhầm đồng đội)

    public int attackDamage = 20;
    public float attackRate = 2f; // Tốc độ đánh (2 lần/giây)
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            // Bấm phím J để đánh (Sếp có thể đổi thành chuột trái "Fire1")
            if (Input.GetKeyDown(KeyCode.J)) 
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // 1. Chạy Animation đánh
        animator.SetTrigger("Basic Attack");

        // 2. Phát hiện kẻ thù trong phạm vi (Tạo vòng tròn đỏ)
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // 3. Trừ máu từng thằng bị chém trúng
        foreach(Collider2D enemy in hitEnemies)
        {
            // Thay vì tìm EnemyHealth, ta tìm HealthSystem
            HealthSystem health = enemy.GetComponent<HealthSystem>();
            if(health != null) {
                health.TakeDamage(attackDamage);
            }
        }
    }

    // Hàm này để vẽ vòng tròn đỏ trong Editor cho sếp dễ căn chỉnh (Không hiện trong game)
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}