using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public int damage = 10;    // ����, ��������� ������ � ������


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("RayanV2"))
        {
            Debug.Log("Player hit!");
            ApplyDamage(collision.gameObject);
        }


        // ���������, �������� �� ������ �������
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            ApplyDamage(collision.gameObject);
        }
    }

    private void ApplyDamage(GameObject target)
    {
        // �������� �������� ��������� PlayerHealth
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // ������� ����
            playerHealth.TakeDamage(damage);
            Debug.Log($"{target.name} ������� ����: {damage}");
        }
        else
        {
            Debug.LogWarning($"� ������� {target.name} ��� ���������� PlayerHealth!");
        }
    }
}
