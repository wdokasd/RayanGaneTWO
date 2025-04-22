using UnityEngine;

[ExecuteInEditMode]
public class PixelationEffect : MonoBehaviour
{
    public int pixelWidth = 320; // Ширина в пикселях
    public int pixelHeight = 240; // Высота в пикселях

    private Material pixelationMaterial;

    void Start()
    {
        // Создаем материал для шейдера пикселизации
        Shader pixelationShader = Shader.Find("Hidden/PixelationShader");
        if (pixelationShader != null)
        {
            pixelationMaterial = new Material(pixelationShader);
        }
        else
        {
            Debug.LogError("Pixelation shader not found. Make sure the shader is included in the project.");
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (pixelationMaterial != null)
        {
            // Устанавливаем размеры пикселей
            pixelationMaterial.SetFloat("_PixelWidth", pixelWidth);
            pixelationMaterial.SetFloat("_PixelHeight", pixelHeight);

            // Применяем шейдер
            Graphics.Blit(source, destination, pixelationMaterial);
        }
        else
        {
            // Если материал отсутствует, просто копируем изображение
            Graphics.Blit(source, destination);
        }
    }
}