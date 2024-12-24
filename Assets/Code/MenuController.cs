using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // ����� ��� ������ "������"
    public void PlayGame()
    {
        // �������� ��������� �������� ������
        SceneManager.LoadScene(1); // ������� ��� ����� ������� �����
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
        
        Application.Quit(); // ��������� ����������
    }
}
