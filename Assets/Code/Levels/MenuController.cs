using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int customLevel;

    // Метод для кнопки "Играть"
    public void PlayGame()
    {
        // Загрузка основного игрового уровня
        SceneManager.LoadScene(1); // Укажите имя вашей игровой сцены
    }

    public void OtherLevel()
    {
        SceneManager.LoadScene(customLevel);
    }
    

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        
        Application.Quit(); // Завершает приложение
    }
}
