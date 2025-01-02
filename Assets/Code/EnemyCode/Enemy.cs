using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f; // Здоровье врага

    // Метод для получения урона
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health);

        if (health <= 0)
        {
            Die(); // Если здоровье врага <= 0, уничтожаем его
        }
    }

    // Метод для уничтожения врага
    void Die()
    {
        Debug.Log("Enemy Died");
        Destroy(gameObject); // Уничтожаем объект врага
    }
}
