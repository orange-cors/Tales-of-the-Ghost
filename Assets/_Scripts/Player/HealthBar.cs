using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    /*public Slider slider;*/
    public Vector3 offset = new Vector3(0, 1.5f, 0); // Khoảng cách trên đầu

    void Start()
    {
        
    }

    void Update()
    {
        // Kiểm tra xem Slider có tồn tại không trước khi chạy để tránh lỗi đỏ
        /*if (slider == null) return; */

        // Giữ thanh máu luôn ở trên đầu và không bị xoay theo nhân vật
        if (transform.parent != null)
        {
            transform.position = transform.parent.position + offset;
            transform.rotation = Quaternion.identity; 
        }
    }

    /*public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }*/

    public void HealthBarUpdate(float currentHealth, float maxHealth)
    {
        // Tính tỷ lệ từ 0 đến 1
        fillImage.fillAmount = currentHealth / maxHealth; //Fill là tỉ lệ thanh máu
    }
}