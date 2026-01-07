using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthFill;

    private void Awake()
    {
        if (healthFill == null)
            healthFill = GetComponentInChildren<Image>();

        if (healthFill == null)
            Debug.LogError("EnemyHealthBar: KHÔNG TÌM THẤY Image HealthFill");
    }

    public void UpdateHealth(float current, float max)
    {
        if (healthFill == null) return;

        healthFill.fillAmount = current / max;
    }
}
