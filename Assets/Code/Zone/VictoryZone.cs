using UnityEngine;
using TMPro; // ���������� TextMeshPro
using UnityEngine.SceneManagement; // ���������� SceneManager

public class VictoryZone : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ������ �� TMP Text UI ��� ����������� �������
    public string victorySceneName = "Victory"; // �������� ������ ������
    public float timerDuration = 60f; // ����� ��������� ���� � ��������

    private float timer; // ������� ������
    private bool isPlayerInZone = false; // ����, ��������� �� ����� � ����

    void Start()
    {
        timer = timerDuration;
        UpdateTimerText();
    }

    void Update()
    {
        if (isPlayerInZone)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Victory();
            }
            UpdateTimerText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            timer = timerDuration; // ���������� ������
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // ������ "00:00"
        }
    }

    private void Victory()
    {
        Debug.Log("����� �������!");
        SceneManager.LoadScene(victorySceneName);
    }
}
