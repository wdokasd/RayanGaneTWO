using UnityEngine;


public class BombBomb : MonoBehaviour
{
    public int damage = 50; // Урон от пули

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, является ли объект врагом
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Получаем компонент здоровья врага
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Наносим урон врагу
                enemyHealth.TakeDamage(damage);
            }

            // Уничтожаем пулю после столкновения
            
        }
        
    }
}
