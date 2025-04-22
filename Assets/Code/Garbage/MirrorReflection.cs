using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    public Camera mainCamera;      // Основная камера
    public Camera mirrorCamera;    // Камера для отражения
    public RenderTexture renderTexture; // Рендер текстуры для зеркала
    public Material mirrorMaterial;    // Материал зеркала, который будет использовать рендер текстуру

    void Start()
    {
        // Устанавливаем рендер текстуру на материал зеркала
        mirrorMaterial.SetTexture("_ReflectionTex", renderTexture);
    }

    void Update()
    {
        // Настроим камеру для отражения
        Vector3 mirrorPosition = transform.position;
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 reflectedPosition = ReflectPosition(cameraPosition, mirrorPosition, transform.forward);

        mirrorCamera.transform.position = reflectedPosition;
        mirrorCamera.transform.LookAt(mirrorPosition);

        // Отображаем отражённую сцену на зеркале
        mirrorCamera.targetTexture = renderTexture;
        mirrorCamera.Render();
    }

    // Функция для отражения позиции камеры относительно зеркала
    Vector3 ReflectPosition(Vector3 position, Vector3 mirrorPosition, Vector3 mirrorNormal)
    {
        float dotProduct = Vector3.Dot(position - mirrorPosition, mirrorNormal);
        return position - 2 * dotProduct * mirrorNormal;
    }
}
