using UnityEngine;
using TMPro; // Подключаем TextMeshPro
using UnityEngine.SceneManagement; // Подключаем SceneManager
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;         // Максимальное здоровье
    public int currentHealth;          // Текущее здоровье

    public Image healthBar;            // Ссылка на Image для шкалы здоровья

    void Start()
    {
        // Проверяем, привязан ли объект healthBar
        if (healthBar == null)
        {
            healthBar = GameObject.Find("HealthBar")?.GetComponent<Image>();
            if (healthBar == null)
            {
                Debug.LogError("HealthBar не найден в сцене! Убедитесь, что объект привязан.");
            }
        }

        // Устанавливаем текущее здоровье на максимум
        currentHealth = maxHealth;
        UpdateHealthBar(); // Обновляем шкалу здоровья
    }

    void Update()
    {
        // Убедимся, что здоровье не опускается ниже нуля
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        // Уменьшаем здоровье
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ограничиваем значение
        UpdateHealthBar(); // Обновляем шкалу здоровья
    }

    public void Heal(int healAmount)
    {
        // Увеличиваем здоровье
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ограничиваем значение
        UpdateHealthBar(); // Обновляем шкалу здоровья
    }

    void UpdateHealthBar()
    {
        // Проверяем, чтобы healthBar не был null
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
        Debug.Log("Игрок умер!");
        // Загрузка уровня "End"
        SceneManager.LoadScene("End");
    }
}
