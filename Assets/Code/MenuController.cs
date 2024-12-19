using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Метод для кнопки "Играть"
    public void PlayGame()
    {
        // Загрузка основного игрового уровня
        SceneManager.LoadScene(4); // Укажите имя вашей игровой сцены
    }

    public void Level1()
    {
        SceneManager.LoadScene(4);
    }

    public void Level2()
    {
        SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        
        Application.Quit(); // Завершает приложение
    }
}
