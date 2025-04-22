using UnityEngine;
using TMPro; // Подключаем TextMeshPro
using UnityEngine.SceneManagement; // Подключаем SceneManager

public class TimedVictoryZone : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на TMP Text UI для отображения таймера
    public float timerDuration = 600f; // Длительность таймера в секундах (10 минут)
    public int level;

    private float timer; // Текущий таймер
    private bool isTimerRunning = false; // Флаг, идет ли таймер

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
            isTimerRunning = true; // Запускаем таймер
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Формат "00:00"
        }
    }

    private void Victory()
    {
        Debug.Log("Игрок победил!");
        SceneManager.LoadScene(level);
    }
}
