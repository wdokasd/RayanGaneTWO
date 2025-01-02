using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    public Camera mainCamera;      // �������� ������
    public Camera mirrorCamera;    // ������ ��� ���������
    public RenderTexture renderTexture; // ������ �������� ��� �������
    public Material mirrorMaterial;    // �������� �������, ������� ����� ������������ ������ ��������

    void Start()
    {
        // ������������� ������ �������� �� �������� �������
        mirrorMaterial.SetTexture("_ReflectionTex", renderTexture);
    }

    void Update()
    {
        // �������� ������ ��� ���������
        Vector3 mirrorPosition = transform.position;
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 reflectedPosition = ReflectPosition(cameraPosition, mirrorPosition, transform.forward);

        mirrorCamera.transform.position = reflectedPosition;
        mirrorCamera.transform.LookAt(mirrorPosition);

        // ���������� ��������� ����� �� �������
        mirrorCamera.targetTexture = renderTexture;
        mirrorCamera.Render();
    }

    // ������� ��� ��������� ������� ������ ������������ �������
    Vector3 ReflectPosition(Vector3 position, Vector3 mirrorPosition, Vector3 mirrorNormal)
    {
        float dotProduct = Vector3.Dot(position - mirrorPosition, mirrorNormal);
        return position - 2 * dotProduct * mirrorNormal;
    }
}
