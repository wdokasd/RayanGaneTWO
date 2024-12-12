using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public float range = 50f; // Дальность видимости частиц
    private ParticleSystem[] particleSystems; // Ссылка на все системы частиц
    private LineRenderer lineRenderer; // LineRenderer для отображения радиуса

    void Start()
    {
        // Получаем все ParticleSystems на объекте
        particleSystems = GetComponentsInChildren<ParticleSystem>();

        // Создаем LineRenderer для отображения радиуса
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f; // Толщина линии
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color.red; // Цвет линии
        lineRenderer.endColor = Color.red;
        lineRenderer.positionCount = 2; // Будем рисовать прямую линию
        lineRenderer.enabled = false; // Сначала выключаем его
    }

    void Update()
    {
        foreach (var ps in particleSystems)
        {
            if (ps != null && ps.gameObject.activeSelf)
            {
                // Проверяем видимость частиц от камеры
                Ray ray = new Ray(Camera.main.transform.position, ps.transform.position - Camera.main.transform.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, range))
                {
                    if (hit.collider != null && hit.collider.gameObject != ps.gameObject)
                    {
                        ps.gameObject.SetActive(false); // Отключаем частицы, если они за стеной или не видимы
                    }
                }
                else
                {
                    ps.gameObject.SetActive(true); // Включаем, если они видимы
                }

                // Визуализируем радиус видимости частиц
                VisualizeRadius();
            }
        }
    }

    // Метод для визуализации радиуса действия
    void VisualizeRadius()
    {
        lineRenderer.enabled = true; // Включаем LineRenderer

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + transform.forward * range; // Направление радиуса видимости

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);

        // Выключаем LineRenderer после небольшого интервала времени
        Invoke("DisableLineRenderer", 0.1f); // Выключаем через 0.1 секунду
    }

    // Метод для отключения LineRenderer
    void DisableLineRenderer()
    {
        lineRenderer.enabled = false;
    }
}
