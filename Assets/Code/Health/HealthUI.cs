using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider; // ������ �� �������
    public PlayerHealth playerHealth; // ������ �� PlayerHealth

    void Update()
    {
        // ��������� ����� ��������
        healthSlider.value = (float)playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
