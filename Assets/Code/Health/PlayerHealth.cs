using UnityEngine;
using TMPro; // Подключаем TextMeshPro
using UnityEngine.SceneManagement; // Подключаем SceneManager

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье
    public int currentHealth;  // Текущее здоровье

    public TextMeshProUGUI healthTextUI; // Ссылка на TMP Text UI для отображения здоровья

    void Start()
    {
        // Устанавливаем текущее здоровье на максимум при старте
        currentHealth = maxHealth;

        // Обновляем текст здоровья
        UpdateHealthText();
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
        // Если Получен Урон, вычитаем ХП
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        // Обновляем текст здоровья
        UpdateHealthText();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        // Обновляем текст здоровья
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        if (healthTextUI != null)
        {
            healthTextUI.text = $"{currentHealth}/{maxHealth}"; // Отображаем здоровье в формате "Health: 80/100"
        }
    }

    private void Die()
    {
        Debug.Log("Игрок умер!");
        // Загрузка уровня "End"
        SceneManager.LoadScene("End");
    }
}
