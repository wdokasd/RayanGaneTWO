using UnityEngine;
using TMPro; // ���������� TextMeshPro
using UnityEngine.SceneManagement; // ���������� SceneManager

public class TimedVictoryZone : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ������ �� TMP Text UI ��� ����������� �������
    public float timerDuration = 600f; // ������������ ������� � �������� (10 �����)
    public int level;

    private float timer; // ������� ������
    private bool isTimerRunning = false; // ����, ���� �� ������

    void Start()
    {
        timer = timerDuration;
        UpdateTimerText();
    }

    void Update()
    {
        if (isTimerRunning)
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
            isTimerRunning = true; // ��������� ������
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
        SceneManager.LoadScene(level);
    }
}
