using UnityEngine;


public class Bullet : MonoBehaviour
{
    

    // ���� ����� ����������, ����� ���� ������ � ������� (������������ � ������)
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, �������� �� ������ ������
        if (collision.gameObject.CompareTag("Enemy"))
        {

            // ���������� ���� ����� �����������
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }


    }
}
