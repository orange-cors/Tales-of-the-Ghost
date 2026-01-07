using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Chỉ số sinh tồn")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Kết nối linh kiện")]
    public HealthBar healthBar; 
    public Animator animator;

    public virtual void Start()
    {
        currentHealth = maxHealth;

        if (animator == null)
            animator = GetComponent<Animator>();

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth);
        else
            Debug.LogWarning(gameObject.name + " CHƯA GẮN HealthBar");
    }

    public virtual void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " bị chém! Máu còn: " + currentHealth);

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth);

        if (animator != null)
            animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die()
    {
        if (animator != null)
            animator.SetBool("isDead", true);

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        Debug.Log(gameObject.name + " đã chết!");

        if (CompareTag("Enemy"))
            Destroy(gameObject, 2f);
    }
}
