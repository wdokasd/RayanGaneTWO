using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100; // Максимальное здоровье врага
    private int currentHealth; // Текущее здоровье врага

    void Start()
    {
        // Устанавливаем начальное здоровье равным максимальному
        currentHealth = maxHealth;
    }

    // Метод для нанесения урона
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Проверяем, не умер ли враг
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Метод для лечения врага
    public void Heal(int amount)
    {
        currentHealth += amount;

        // Ограничиваем здоровье максимальным значением
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Метод, вызываемый при смерти врага
    private void Die()
    {
        Debug.Log($"{gameObject.name} умер!");
        // Добавьте здесь логику смерти (анимация, удаление объекта и т.д.)
        Destroy(gameObject);
    }

    // Отладочный метод для отображения текущего здоровья
    private void OnGUI()
    {
        // Это только для тестов. Уберите в финальной версии.
        GUI.Label(new Rect(10, 10 + 20 * transform.GetSiblingIndex(), 200, 20),
                  $"{gameObject.name}: {currentHealth}/{maxHealth}");
    }
}
