using UnityEngine;
using UnityEngine.Rendering;

public class Skeleton : HealthSystem
{
    public float maxHealth = 80;
    public float currentHealth;
    public HealthBar healthBar; 
    public Rigidbody2D rb;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.HealthBarUpdate(currentHealth, maxHealth);
        // Tự động tìm Animator nếu sếp quên không kéo vào
        if (animator == null) animator = GetComponent<Animator>();
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return; // Nếu chết rồi thì thôi không nhận đam nữa

        currentHealth -= damage;

        if (healthBar != null) 
            healthBar.HealthBarUpdate(currentHealth, maxHealth);

        // Kích hoạt animation bị đau
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); 
        }

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            healthBar.gameObject.SetActive(false);
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
