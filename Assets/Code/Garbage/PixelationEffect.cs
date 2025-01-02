using UnityEngine;

[ExecuteInEditMode]
public class PixelationEffect : MonoBehaviour
{
    public int pixelWidth = 320; // ������ � ��������
    public int pixelHeight = 240; // ������ � ��������

    private Material pixelationMaterial;

    void Start()
    {
        // ������� �������� ��� ������� ������������
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
            // ������������� ������� ��������
            pixelationMaterial.SetFloat("_PixelWidth", pixelWidth);
            pixelationMaterial.SetFloat("_PixelHeight", pixelHeight);

            // ��������� ������
            Graphics.Blit(source, destination, pixelationMaterial);
        }
        else
        {
            // ���� �������� �����������, ������ �������� �����������
            Graphics.Blit(source, destination);
        }
    }
}