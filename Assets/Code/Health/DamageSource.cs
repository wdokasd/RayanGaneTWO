using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public int damage = 10; // ����, ��������� ������

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ����������� �� � �������
        if (collision.gameObject.CompareTag("Player"))
        {
            // �������� ��������� PlayerHealth
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // ������� ����
                playerHealth.TakeDamage(damage);
                Debug.Log("������!!");
            }
        }

        if (collision.gameObject.CompareTag("Rayan"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("������ ������");
            }
        }
    }
}
