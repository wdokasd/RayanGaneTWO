using UnityEngine;


public class Bullet : MonoBehaviour
{
    

    // Этот метод вызывается, когда пуля входит в триггер (столкновение с врагом)
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, является ли объект врагом
        if (collision.gameObject.CompareTag("Enemy"))
        {

            // Уничтожаем пулю после столкноения
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }


    }
}
