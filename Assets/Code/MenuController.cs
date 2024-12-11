using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Метод для кнопки "Играть"
    public void PlayGame()
    {
        // Загрузка основного игрового уровня
        SceneManager.LoadScene(3); // Укажите имя вашей игровой сцены
    }

    public void QuitGame()
    {
        
        Application.Quit(); // Завершает приложение
    }
}
