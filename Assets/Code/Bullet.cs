using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // ���� �� ����

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, �������� �� ������ ������
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �������� ��������� �������� �����
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // ������� ���� �����
                enemyHealth.TakeDamage(damage);
            }

            // ���������� ���� ����� ������������
            Destroy(gameObject);
        }
        else
        {
            // ���������� ���� ��� ������������ � ������ ������� ���������
            Destroy(gameObject);
        }
    }
}
