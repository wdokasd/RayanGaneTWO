using UnityEngine;

public class CameraToPlane : MonoBehaviour
{
    public Camera renderCamera;       // ������, ������� ����� ��������� �����������
    public RenderTexture renderTexture; // RenderTexture, ���� ������ ����� ���������� �����������
    public Material planeMaterial;    // �������� ������� Plane

    void Start()
    {
        // �������� ������ ��� ���������� � RenderTexture
        renderCamera.targetTexture = renderTexture;

        // ������������� RenderTexture �� �������� Plane
        planeMaterial.mainTexture = renderTexture;
    }
}
