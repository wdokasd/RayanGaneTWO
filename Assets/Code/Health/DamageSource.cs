using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public int damage = 10;    // Урон, наносимый игроку и Райану


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("RayanV2"))
        {
            Debug.Log("Player hit!");
            ApplyDamage(collision.gameObject);
        }


        // Проверяем, является ли объект игроком
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            ApplyDamage(collision.gameObject);
        }
    }

    private void ApplyDamage(GameObject target)
    {
        // Пытаемся получить компонент PlayerHealth
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Наносим урон
            playerHealth.TakeDamage(damage);
            Debug.Log($"{target.name} получил урон: {damage}");
        }
        else
        {
            Debug.LogWarning($"У объекта {target.name} нет компонента PlayerHealth!");
        }
    }
}
