using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLevelManager : MonoBehaviour
{
    // Загрузка уровня по имени
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Загрузка следующего уровня
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Перезагрузка текущего уровня
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Выход из игры
    public void QuitGame()
    {
        Application.Quit();
    }
}
