using UnityEngine;

public class DamageToRayan : MonoBehaviour
{
    public int damage = 10;     // ����, ��������� ������
    public GameObject Rayan;    // ������ �� ������ ������

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ��������� �� ������ � �������
        if (collision.gameObject == Rayan)
        {
            Debug.Log("Rayan hit!");
            ApplyDamage(collision.gameObject);
        }
    }

    private void ApplyDamage(GameObject target)
    {
        // �������� �������� ��������� RayanHealth
        RayanHealth rayanHealth = target.GetComponent<RayanHealth>();
        if (rayanHealth != null)
        {
            rayanHealth.TakeDamage(damage); // ������� ����
            Debug.Log($"Rayan ������� ����: {damage}");
        }
        else
        {
            Debug.LogWarning($"� ������� {target.name} ��� ���������� RayanHealth!");
        }
    }
}
