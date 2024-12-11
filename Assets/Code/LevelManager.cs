using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLevelManager : MonoBehaviour
{
    // �������� ������ �� �����
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // �������� ���������� ������
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // ������������ �������� ������
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ����� �� ����
    public void QuitGame()
    {
        Application.Quit();
    }
}
