using UnityEngine;
using UnityEngine.UI;

public class RayanHealth : MonoBehaviour
{
    public int maxHealth = 100;         // ������������ ��������
    public int currentHealth;          // ������� ��������
    public Image healthBar;            // ������ �� Image ��� ����������� ��������
    public int collisionDamage = 10;   // ����, ��������� ��� ������������ � ������

    void Start()
    {
        currentHealth = maxHealth;     // ������������� �������� �� ��������
        UpdateHealthBar();             // ��������� ����� ��������
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, �������� �� ������������ � ������
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collisionDamage); // ������� ����
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;       // ��������� ��������
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ������������ ��������
        UpdateHealthBar();             // ��������� ����� ��������
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;   // ����������� ��������
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ������������ ��������
        UpdateHealthBar();             // ��������� ����� ��������
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
        else
        {
            Debug.LogWarning("HealthBar �� ��������. ���������� ���������.");
        }
    }

    private void Die()
    {
        Debug.Log("����� ����!");
        // ����� ����� �������� ������ ���������� ���� ��� ���������
    }
}
