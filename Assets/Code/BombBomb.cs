using UnityEngine;


public class BombBomb : MonoBehaviour
{


    // ���� ����� ����������, ����� ���� ������ � ������� (������������ � ������)
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, �������� �� ������ ������
        if (collision.gameObject.CompareTag("Enemy"))
        {

            // ���������� ���� ����� �����������
            Destroy(collision.gameObject);


        }


    }
}
