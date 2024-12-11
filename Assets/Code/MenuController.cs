using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // ����� ��� ������ "������"
    public void PlayGame()
    {
        // �������� ��������� �������� ������
        SceneManager.LoadScene(3); // ������� ��� ����� ������� �����
    }

    public void QuitGame()
    {
        
        Application.Quit(); // ��������� ����������
    }
}
