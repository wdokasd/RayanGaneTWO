using UnityEngine;
using TMPro; // Подключаем TextMeshPro
using UnityEngine.SceneManagement; // Подключаем SceneManager

public class VictoryZone : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на TMP Text UI для отображения таймера
    public string victorySceneName = "Victory"; // Название уровня победы
    public float timerDuration = 60f; // Время удержания зоны в секундах

    private float timer; // Текущий таймер
    private bool isPlayerInZone = false; // Флаг, находится ли игрок в зоне

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
            timer = timerDuration; // Сбрасываем таймер
            UpdateTimerText();
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
        SceneManager.LoadScene(victorySceneName);
    }
}
