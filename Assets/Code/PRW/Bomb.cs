using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public GameObject bombPrefab;   // Префаб пули
    public Transform firePoint;       // Точка, откуда будет выстрелена пуля
    public float shootForce = 20f;    // Сила выстрела
    public float lifeTime = 15f;       // Время Жизни снаряда
    public int Ammo = 5;              // Боезапас
    public bool fire = false;         // Разрешение на Выстрел
    public Scrollbar AmmoScrollbar; // Ссылка на Scrollbar
    public int MaxAmmo = 5;

    // Update is called once per frame

    private void Start()
    {   // Функция для обновления Scrollbar
        if (AmmoScrollbar != null)
        {
            AmmoScrollbar.size = 1f; // Полное здоровье
        }
    }

    void Update()
    {
        // Проверка нажатия левой кнопки мыши (0 — левая кнопка)
        
    }


    public void FireBomb()
    {
        // Проверяем есть ли Боезапас
        if (Ammo > 0)
        {
            // Разрешаем Огонь
            fire = true;
            // Вызываем Выстрел
            Shoot();
        }


        // Если нет Боеприпасов
        else
        {
            // Запрешаем Огонь
            fire = false;
        }
    }


    void Shoot()
    {
        // Проверяем Есть ли Разрешение на огонь
        if (fire == true)
        {

            // Убовляем Из Боезапаса Один снаряд
            Ammo -= 1;

            //Scrollbar
            UpdateScrollBar();

            // Получаем GameObject Бомбы И других
            GameObject bomb = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);



            // Получаем Rigidbody пули, чтобы добавить силу
            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            // Добавляем силу, чтобы пуля полетела вперед
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * shootForce, ForceMode.VelocityChange);
            }

            // Уничтожаем Снаряд когда время жизни истекло 
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



