using UnityEngine;


public class BombBomb : MonoBehaviour
{
    public int damage = 50; // ���� �� ����

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
            
        }
        
    }
}
