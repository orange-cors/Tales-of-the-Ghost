using UnityEngine;

public class Snail : HealthSystem
{
    public float maxHealth = 50;
    public float currentHealth;
    
    public HealthBar healthBar;
    public Rigidbody2D rb;
    public Animator animator; // Sếp nhớ kéo Animator vào ô này trong Inspector

    void Start()
    {
        currentHealth = maxHealth;
        // Tự động tìm Animator nếu sếp quên không kéo vào
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public override void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return; // Nếu chết rồi thì thôi không nhận đam nữa

        currentHealth -= damage;

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

    public override void Die()
    {
        Destroy(gameObject);
    }
}