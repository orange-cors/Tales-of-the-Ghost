using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Bao cát bị chém! Máu còn: " + currentHealth);

        // Hiệu ứng bị giật lùi (Knockback) nhẹ cho sướng tay
        // transform.position += Vector3.right * 0.1f; 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Bao cát đã nát!");
        // Tạm thời chỉ ẩn đi để test
        gameObject.SetActive(false); 
    }
}