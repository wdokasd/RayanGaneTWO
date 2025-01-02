using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f; // �������� �����

    // ����� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy Health: " + health);

        if (health <= 0)
        {
            Die(); // ���� �������� ����� <= 0, ���������� ���
        }
    }

    // ����� ��� ����������� �����
    void Die()
    {
        Debug.Log("Enemy Died");
        Destroy(gameObject); // ���������� ������ �����
    }
}
