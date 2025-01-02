using UnityEngine;

public class FireDamageZone : MonoBehaviour
{
    public int damagePerSecond = 10; // Урон в секунду
    public string playerTag = "Player"; // Тег игрока
    private float damageInterval = 1f; // Интервал между нанесением урона
    private float damageTimer = 0f; // Таймер для отслеживания времени

    private void OnTriggerStay(Collider other)
    {
        // Проверяем, игрок ли находится в зоне
        if (other.CompareTag(playerTag))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Увеличиваем таймер
                damageTimer += Time.deltaTime;

                // Если прошло достаточно времени, наносим урон
                if (damageTimer >= damageInterval)
                {
                    playerHealth.TakeDamage(damagePerSecond);
                    damageTimer = 0f; // Сбрасываем таймер
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Сбрасываем таймер, если игрок выходит из зоны
        if (other.CompareTag(playerTag))
        {
            damageTimer = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Рисуем границы зоны для отладки
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}