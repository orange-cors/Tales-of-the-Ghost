using UnityEngine;

public class Skeleton : HealthSystem
{
    public Rigidbody2D rb;

    public override void Start()
    {
        base.Start();

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if (currentHealth <= 0 && healthBar != null)
        {
            healthBar.gameObject.SetActive(false);
        }
    }

    public override void Die()
    {
        // Gọi logic chết CHUNG
        base.Die();

        Debug.Log("Skeleton đã tan xương nát thịt!");
        // ❌ KHÔNG Destroy lại ở đây
    }
}
