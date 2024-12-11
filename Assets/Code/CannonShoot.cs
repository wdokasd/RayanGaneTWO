using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject bulletPrefab;   // ������ ����
    public Transform firePoint;       // �����, ������ ����� ���������� ����
    public float shootForce = 20f;    // ���� ��������
    public float lifeTime = 5f;

    // Update is called once per frame
    void Update()
    {
        // �������� ������� ����� ������ ���� (0 � ����� ������)
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }

    void Shoot()
    {
        // ������� ���� � ����� ��������
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // �������� Rigidbody ����, ����� �������� ����
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // ��������� ����, ����� ���� �������� ������
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * shootForce, ForceMode.VelocityChange);
        }

        Destroy(bullet, lifeTime);

    }

   

}
