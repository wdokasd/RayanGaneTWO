using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Подключаем SceneManager

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье
    public int currentHealth;  // Текущее здоровье

    public Scrollbar healthScrollbar; // Ссылка на Scrollbar

    void Start()
    {
        // Устанавливаем текущее здоровье на максимум при старте
        currentHealth = maxHealth;

        // Настраиваем Scrollbar
        if (healthScrollbar != null)
        {
            healthScrollbar.size = 1f; // Полное здоровье
        }
    }

    void Update()
    {
        if (healthScrollbar != null)
        {
            // Обновляем текущее здоровье на основе значения Scrollbar
            currentHealth = Mathf.RoundToInt(maxHealth * healthScrollbar.size);

            // Убедимся, что здоровье не опускается ниже нуля
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // Если Получен Урон вычетаем ХП
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        // Обновляем Scrollbar
        UpdateScrollbar();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateScrollbar();
    }

    private void UpdateScrollbar()
    {
        if (healthScrollbar != null)
        {
            healthScrollbar.size = (float)currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("Игрок умер!");
        // Загрузка уровня "End"
        SceneManager.LoadScene("End");
    }
}
