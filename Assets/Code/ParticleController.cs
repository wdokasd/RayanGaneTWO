using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public float range = 50f; // ��������� ��������� ������
    private ParticleSystem[] particleSystems; // ������ �� ��� ������� ������
    private LineRenderer lineRenderer; // LineRenderer ��� ����������� �������

    void Start()
    {
        // �������� ��� ParticleSystems �� �������
        particleSystems = GetComponentsInChildren<ParticleSystem>();

        // ������� LineRenderer ��� ����������� �������
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // ������� �����
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color.red; // ���� �����
        lineRenderer.endColor = Color.red;
        lineRenderer.positionCount = 2; // ����� �������� ������ �����
        lineRenderer.enabled = false; // ������� ��������� ���
    }

    void Update()
    {
        foreach (var ps in particleSystems)
        {
            if (ps != null && ps.gameObject.activeSelf)
            {
                // ��������� ��������� ������ �� ������
                Ray ray = new Ray(Camera.main.transform.position, ps.transform.position - Camera.main.transform.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, range))
                {
                    if (hit.collider != null && hit.collider.gameObject != ps.gameObject)
                    {
                        ps.gameObject.SetActive(false); // ��������� �������, ���� ��� �� ������ ��� �� ������
                    }
                }
                else
                {
                    ps.gameObject.SetActive(true); // ��������, ���� ��� ������
                }

                // ������������� ������ ��������� ������
                VisualizeRadius();
            }
        }
    }

    // ����� ��� ������������ ������� ��������
    void VisualizeRadius()
    {
        lineRenderer.enabled = true; // �������� LineRenderer

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + transform.forward * range; // ����������� ������� ���������

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);

        // ��������� LineRenderer ����� ���������� ��������� �������
        Invoke("DisableLineRenderer", 0.1f); // ��������� ����� 0.1 �������
    }

    // ����� ��� ���������� LineRenderer
    void DisableLineRenderer()
    {
        lineRenderer.enabled = false;
    }
}
