using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject bulletPrefab;   // Префаб пули
    public Transform firePoint;       // Точка, откуда будет выстрелена пуля
    public float shootForce = 20f;    // Сила выстрела
    public float lifeTime = 5f;

    // Update is called once per frame
    void Update()
    {
        
    }


    public void fire()
    {
        Shoot();
    }



    void Shoot()
    {
        // Создаем пулю в точке стрельбы
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Получаем Rigidbody пули, чтобы добавить силу
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Добавляем силу, чтобы пуля полетела вперед
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * shootForce, ForceMode.VelocityChange);
        }

        Destroy(bullet, lifeTime);

    }

   

}
