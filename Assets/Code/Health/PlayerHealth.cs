using UnityEngine;
using TMPro; // ���������� TextMeshPro
using UnityEngine.SceneManagement; // ���������� SceneManager
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;         // ������������ ��������
    public int currentHealth;          // ������� ��������

    public Image healthBar;            // ������ �� Image ��� ����� ��������

    void Start()
    {
        // ���������, �������� �� ������ healthBar
        if (healthBar == null)
        {
            healthBar = GameObject.Find("HealthBar")?.GetComponent<Image>();
            if (healthBar == null)
            {
                Debug.LogError("HealthBar �� ������ � �����! ���������, ��� ������ ��������.");
            }
        }

        // ������������� ������� �������� �� ��������
        currentHealth = maxHealth;
        UpdateHealthBar(); // ��������� ����� ��������
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
        // ��������� ��������
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ������������ ��������
        UpdateHealthBar(); // ��������� ����� ��������
    }

    public void Heal(int healAmount)
    {
        // ����������� ��������
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ������������ ��������
        UpdateHealthBar(); // ��������� ����� ��������
    }

    void UpdateHealthBar()
    {
        // ���������, ����� healthBar �� ��� null
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
        // �������� ������ "End"
        SceneManager.LoadScene("End");
    }
}
