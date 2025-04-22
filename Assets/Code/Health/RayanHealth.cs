using UnityEngine;
using UnityEngine.UI;

public class RayanHealth : MonoBehaviour
{
    public int maxHealth = 100;         // Максимальное здоровье
    public int currentHealth;          // Текущее здоровье
    public Image healthBar;            // Ссылка на Image для отображения здоровья
    public int collisionDamage = 10;   // Урон, наносимый при столкновении с врагом

    void Start()
    {
        currentHealth = maxHealth;     // Устанавливаем здоровье на максимум
        UpdateHealthBar();             // Обновляем шкалу здоровья
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, является ли столкновение с врагом
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collisionDamage); // Наносим урон
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;       // Уменьшаем здоровье
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ограничиваем значение
        UpdateHealthBar();             // Обновляем шкалу здоровья
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;   // Увеличиваем здоровье
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ограничиваем значение
        UpdateHealthBar();             // Обновляем шкалу здоровья
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
        else
        {
            Debug.LogWarning("HealthBar не привязан. Обновление пропущено.");
        }
    }

    private void Die()
    {
        Debug.Log("Райан умер!");
        // Здесь можно добавить логику завершения игры или поражения
    }
}
