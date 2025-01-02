using UnityEngine;

public class CameraToPlane : MonoBehaviour
{
    public Camera renderCamera;       // Камера, которая будет рендерить изображение
    public RenderTexture renderTexture; // RenderTexture, куда камера будет записывать изображение
    public Material planeMaterial;    // Материал объекта Plane

    void Start()
    {
        // Настроим камеру для рендеринга в RenderTexture
        renderCamera.targetTexture = renderTexture;

        // Устанавливаем RenderTexture на материал Plane
        planeMaterial.mainTexture = renderTexture;
    }
}
