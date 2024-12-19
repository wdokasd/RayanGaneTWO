using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Скорость движения игрока
    public float jumpForce = 5f;         // Сила прыжка
    public float lookSensitivity = 100f; // Чувствительность для вращения камеры
    public Transform cameraTransform;    // Ссылка на камеру игрока
    public LayerMask groundLayer;        // Слой для проверки земли

    public Joystick movementJoystick;    // Джойстик для движения

    private Rigidbody rb;                // Rigidbody игрока
    private float xRotation = 0f;        // Поворот камеры по оси X
    private bool isGrounded = false;     // Находится ли игрок на земле
    private Vector2 lastMousePosition;   // Последняя позиция мыши
    private bool isDragging = false;     // Перетаскивание мышью
    private bool isJoystickDragging = false; // Флаг для предотвращения поворота камеры при движении джойстиком

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Скрываем курсор мыши
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        MovePlayer();       // Движение игрока
        RotateCamera();     // Вращение камеры через мышь

        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIElement())
            {
                isDragging = true;
                lastMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        isJoystickDragging = Mathf.Abs(movementJoystick.Horizontal) > 0.1f || Mathf.Abs(movementJoystick.Vertical) > 0.1f;
    }

    void MovePlayer()
    {
        // Получаем значения осей от джойстика движения
        float horizontal = movementJoystick.Horizontal;
        float vertical = movementJoystick.Vertical;

        // Направление движения (исправлено инвертирование осей)
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Применяем движение
        Vector3 velocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
        rb.linearVelocity = velocity;
    }

    void RotateCamera()
    {
        if (isDragging && !isJoystickDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 delta = currentMousePosition - lastMousePosition;
            lastMousePosition = currentMousePosition;

            // Поворот камеры вверх/вниз
            xRotation -= delta.y * lookSensitivity * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // Поворот игрока влево/вправо
            transform.Rotate(Vector3.up * delta.x * lookSensitivity * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Проверяем, находится ли игрок на земле
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer);
    }

    private bool IsPointerOverUIElement()
    {
        // Проверка, находится ли курсор над UI элементом (джойстиком)
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }
}
