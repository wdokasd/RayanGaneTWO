using UnityEngine;
using TMPro; // ���������� TextMeshPro
using UnityEngine.SceneManagement; // ���������� SceneManager

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ��������
    public int currentHealth;  // ������� ��������

    public TextMeshProUGUI healthTextUI; // ������ �� TMP Text UI ��� ����������� ��������

    void Start()
    {
        // ������������� ������� �������� �� �������� ��� ������
        currentHealth = maxHealth;

        // ��������� ����� ��������
        UpdateHealthText();
    }

    void Update()
    {
        // ��������, ��� �������� �� ���������� ���� ����
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        // ���� ������� ����, �������� ��
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        // ��������� ����� ��������
        UpdateHealthText();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        // ��������� ����� ��������
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        if (healthTextUI != null)
        {
            healthTextUI.text = $"{currentHealth}/{maxHealth}"; // ���������� �������� � ������� "Health: 80/100"
        }
    }

    private void Die()
    {
        Debug.Log("����� ����!");
        // �������� ������ "End"
        SceneManager.LoadScene("End");
    }
}
