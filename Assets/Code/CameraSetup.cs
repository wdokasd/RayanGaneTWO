using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    void Start()
    {
        // ���������� ���������� ����������� ������
        Camera.main.transform.rotation = Quaternion.Euler(0, 180, 0); // �������� ���� �������� ��� �������������
    }
}
