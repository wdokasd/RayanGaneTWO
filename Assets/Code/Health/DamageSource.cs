using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public int damage = 10; // Урон, наносимый игроку

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулись ли с игроком
        if (collision.gameObject.CompareTag("Player"))
        {
            // Получаем компонент PlayerHealth
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Наносим урон
                playerHealth.TakeDamage(damage);
                Debug.Log("АХТУНГ!!");
            }
        }

        if (collision.gameObject.CompareTag("Rayan"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("СПАСАЙ РАЙАНА");
            }
        }
    }
}
