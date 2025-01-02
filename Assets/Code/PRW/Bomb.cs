using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public GameObject bombPrefab;   // ������ ����
    public Transform firePoint;       // �����, ������ ����� ���������� ����
    public float shootForce = 20f;    // ���� ��������
    public float lifeTime = 15f;       // ����� ����� �������
    public int Ammo = 5;              // ��������
    public bool fire = false;         // ���������� �� �������
    public Scrollbar AmmoScrollbar; // ������ �� Scrollbar
    public int MaxAmmo = 5;

    // Update is called once per frame

    private void Start()
    {   // ������� ��� ���������� Scrollbar
        if (AmmoScrollbar != null)
        {
            AmmoScrollbar.size = 1f; // ������ ��������
        }
    }

    void Update()
    {
        // �������� ������� ����� ������ ���� (0 � ����� ������)
        
    }


    public void FireBomb()
    {
        // ��������� ���� �� ��������
        if (Ammo > 0)
        {
            // ��������� �����
            fire = true;
            // �������� �������
            Shoot();
        }


        // ���� ��� �����������
        else
        {
            // ��������� �����
            fire = false;
        }
    }


    void Shoot()
    {
        // ��������� ���� �� ���������� �� �����
        if (fire == true)
        {

            // �������� �� ��������� ���� ������
            Ammo -= 1;

            //Scrollbar
            UpdateScrollBar();

            // �������� GameObject ����� � ������
            GameObject bomb = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);



            // �������� Rigidbody ����, ����� �������� ����
            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            // ��������� ����, ����� ���� �������� ������
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * shootForce, ForceMode.VelocityChange);
            }

            // ���������� ������ ����� ����� ����� ������� 
            Destroy(bomb, lifeTime);

        }








    }

    private void UpdateScrollBar()
    {
        if (AmmoScrollbar != null)
        {
            AmmoScrollbar.size = (float)Ammo / MaxAmmo;
        }
    }
}



