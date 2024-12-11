using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // �������� �������� ������
    public float jumpForce = 5f;         // ���� ������
    public float mouseSensitivity = 100f; // ���������������� ���� ��� �������� ������
    public Transform cameraTransform;    // ������ �� ������ (���������� ����� ���������)
    public LayerMask groundLayer;        // ���� ����� ��� ��������

    private Rigidbody rb;                // Rigidbody ������
    private float xRotation = 0f;        // ������� ���� �������� ������ �� ��� X
    private bool isGrounded = false;     // ���� ��� ��������, ��������� �� ����� �� �����

    void Start()
    {
        // �������������� Rigidbody
        rb = GetComponent<Rigidbody>();

        // ��������� ������ ����
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();       // ���������� �������������
        RotateCamera();     // ���������� �������

        // ������ ��� ������� �������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void MovePlayer()
    {
        // �������� ���� � ���������� (WASD/�������)
        float horizontal = Input.GetAxis("Horizontal"); // �����/������ (A/D)
        float vertical = Input.GetAxis("Vertical");     // ������/����� (W/S)

        // ������������ ����������� ��������
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // ������� ������ (������ �� ���� X � Z, ��������� ���������� ������� ����� Rigidbody)
        Vector3 velocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
        rb.linearVelocity = velocity;
    }

    void RotateCamera()
    {
        // �������� �������� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ������������ ������ �����/���� (������������ ���� ������)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ������������ ���� �������

        // ��������� �������� � ������
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // ������������ ������ �����/������
        transform.Rotate(Vector3.up * mouseX);
    }

    void Jump()
    {
        // ��������� ������ �� ��� Y
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        // ���������, ��������� �� ����� �� �����
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer);
    }
}
