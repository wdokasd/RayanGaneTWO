using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ���������� SceneManager

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ��������
    public int currentHealth;  // ������� ��������

    public Scrollbar healthScrollbar; // ������ �� Scrollbar

    void Start()
    {
        // ������������� ������� �������� �� �������� ��� ������
        currentHealth = maxHealth;

        // ����������� Scrollbar
        if (healthScrollbar != null)
        {
            healthScrollbar.size = 1f; // ������ ��������
        }
    }

    void Update()
    {
        if (healthScrollbar != null)
        {
            // ��������� ������� �������� �� ������ �������� Scrollbar
            currentHealth = Mathf.RoundToInt(maxHealth * healthScrollbar.size);

            // ��������, ��� �������� �� ���������� ���� ����
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // ���� ������� ���� �������� ��
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        // ��������� Scrollbar
        UpdateScrollbar();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateScrollbar();
    }

    private void UpdateScrollbar()
    {
        if (healthScrollbar != null)
        {
            healthScrollbar.size = (float)currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("����� ����!");
        // �������� ������ "End"
        SceneManager.LoadScene("End");
    }
}
