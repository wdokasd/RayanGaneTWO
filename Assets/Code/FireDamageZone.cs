using UnityEngine;

public class FireDamageZone : MonoBehaviour
{
    public int damagePerSecond = 10; // ���� � �������
    public string playerTag = "Player"; // ��� ������
    private float damageTimer = 0f; // ������ ��� ���������� �����

    private void OnTriggerStay(Collider other)
    {
        // ���������, ����� �� ��������� � ����
        if (other.CompareTag(playerTag))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // ���������� �������
                damageTimer += Time.deltaTime;

                // ���� ������ �������, ������� ����
                if (damageTimer >= 1f)
                {
                    playerHealth.TakeDamage(damagePerSecond);
                    damageTimer = 0f; // ���������� ������
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���������� ������, ���� ����� ������� �� ����
        if (other.CompareTag(playerTag))
        {
            damageTimer = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // ������ ������� ���� ��� �������
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
