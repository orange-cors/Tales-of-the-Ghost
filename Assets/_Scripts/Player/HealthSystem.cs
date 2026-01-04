using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    
    public HealthBar healthBar; 
    public Animator animator; // Sếp nhớ kéo Animator vào ô này trong Inspector

    void Start()
    {
        currentHealth = maxHealth;
        // Tự động tìm Animator nếu sếp quên không kéo vào
        if (animator == null) animator = GetComponent<Animator>();

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return; // Nếu chết rồi thì thôi không nhận đam nữa

        currentHealth -= damage;
        
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        // Kích hoạt animation bị đau
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); 
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Kích hoạt animation chết
        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }

        // Tắt va chạm để xác quái không cản đường Player
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        Debug.Log(gameObject.name + " đã tử trận!");
    }
}