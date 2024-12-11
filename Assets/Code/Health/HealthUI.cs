using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider; // —сылка на слайдер
    public PlayerHealth playerHealth; // —сылка на PlayerHealth

    void Update()
    {
        // ќбновл€ем шкалу здоровь€
        healthSlider.value = (float)playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
