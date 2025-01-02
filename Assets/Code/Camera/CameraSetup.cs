using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    void Start()
    {
        // Установите правильное направление камеры
        Camera.main.transform.rotation = Quaternion.Euler(0, 180, 0); // Измените угол поворота при необходимости
    }
}
