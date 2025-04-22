using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FloatingJoystick movementJoystick; // Джойстик для движения
    public float moveSpeed = 5f;              // Скорость движения
    public float cameraSensitivity = 2f;     // Чувствительность камеры

    private Rigidbody rb;                    // Rigidbody игрока
    private Vector2 lookInput;               // Ввод камеры
    private Transform cameraTransform;       // Камера игрока
    private bool isTouchingScreen = false;   // Флаг для проверки нажатия на экран
    private float xRotation = 0f;            // Для ограничения вертикального поворота камеры

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        xRotation = cameraTransform.localEulerAngles.x; // Начальный угол камеры
    }

    void Update()
    {
        MovePlayer();        // Движение игрока
        HandleCameraInput(); // Обработка ввода для камеры
        RotateCamera();      // Вращение камеры
    }

    void MovePlayer()
    {
        // Получаем входные данные джойстика
        float horizontal = movementJoystick.Horizontal;
        float vertical = movementJoystick.Vertical;

        // Вычисляем направление движения
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        Vector3 velocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

        // Применяем движение к Rigidbody
        rb.linearVelocity = velocity;
    }

    void HandleCameraInput()
    {
        // Проверяем, нажата ли правая часть экрана
        if (Input.GetMouseButtonDown(0)) // Для ПК (левая кнопка мыши)
        {
            Vector3 mousePosition = Input.mousePosition;
            if (mousePosition.x > Screen.width / 2) // Проверяем, что нажата правая половина экрана
            {
                isTouchingScreen = true;
            }
        }

        if (Input.GetMouseButtonUp(0)) // Отпускаем нажатие
        {
            isTouchingScreen = false;
        }

        // Для мобильных устройств
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2)
            {
                isTouchingScreen = true;
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouchingScreen = false;
            }
        }
    }

    void RotateCamera()
    {
        if (isTouchingScreen) // Поворачиваем камеру только при нажатии
        {
            // Ввод камеры через экран
            lookInput.x = Input.GetAxis("Mouse X") * cameraSensitivity;
            lookInput.y = Input.GetAxis("Mouse Y") * cameraSensitivity;

            // Поворот по горизонтали (Y)
            transform.Rotate(Vector3.up * lookInput.x);

            // Поворот по вертикали (X)
            xRotation -= lookInput.y;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Ограничение вертикального угла

            // Применяем ограниченный угол к камере
            cameraTransform.localEulerAngles = new Vector3(xRotation, 0f, 0f);
        }
    }
}
