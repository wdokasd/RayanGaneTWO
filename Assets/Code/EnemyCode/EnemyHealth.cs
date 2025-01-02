using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100; // ������������ �������� �����
    private int currentHealth; // ������� �������� �����

    void Start()
    {
        // ������������� ��������� �������� ������ �������������
        currentHealth = maxHealth;
    }

    // ����� ��� ��������� �����
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // ���������, �� ���� �� ����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ����� ��� ������� �����
    public void Heal(int amount)
    {
        currentHealth += amount;

        // ������������ �������� ������������ ���������
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // �����, ���������� ��� ������ �����
    private void Die()
    {
        Debug.Log($"{gameObject.name} ����!");
        // �������� ����� ������ ������ (��������, �������� ������� � �.�.)
        Destroy(gameObject);
    }

    // ���������� ����� ��� ����������� �������� ��������
    private void OnGUI()
    {
        // ��� ������ ��� ������. ������� � ��������� ������.
        GUI.Label(new Rect(10, 10 + 20 * transform.GetSiblingIndex(), 200, 20),
                  $"{gameObject.name}: {currentHealth}/{maxHealth}");
    }
}
