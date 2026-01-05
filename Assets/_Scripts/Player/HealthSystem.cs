using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    public abstract void TakeDamage(float damage);
    public abstract void Die();
    
}