using UnityEngine;

public class DamageToRayan : MonoBehaviour
{
    public int damage = 10;     // Урон, наносимый Райану
    public GameObject Rayan;    // Ссылка на объект Райана

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, совпадает ли объект с Райаном
        if (collision.gameObject == Rayan)
        {
            Debug.Log("Rayan hit!");
            ApplyDamage(collision.gameObject);
        }
    }

    private void ApplyDamage(GameObject target)
    {
        // Пытаемся получить компонент RayanHealth
        RayanHealth rayanHealth = target.GetComponent<RayanHealth>();
        if (rayanHealth != null)
        {
            rayanHealth.TakeDamage(damage); // Наносим урон
            Debug.Log($"Rayan получил урон: {damage}");
        }
        else
        {
            Debug.LogWarning($"У объекта {target.name} нет компонента RayanHealth!");
        }
    }
}
