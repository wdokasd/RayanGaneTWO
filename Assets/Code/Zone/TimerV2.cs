using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Подключаем библиотеку для TextMeshPro

public class TimerV2 : MonoBehaviour
{
    public float levelDuration = 60f; // Длительность уровня в секундах
    private float timer;

    public TextMeshProUGUI timerText; // Ссылка на TextMeshProUGUI для отображения таймера

    void Start()
    {
        // Запускаем таймер при начале уровня
        timer = levelDuration;
    }

    void Update()
    {
        // Уменьшаем таймер
        timer -= Time.deltaTime;

        // Обновляем отображение таймера
        UpdateTimerText();

        // Если время истекло, загружаем следующий уровень
        if (timer <= 0f)
        {
            LoadNextLevel();
        }
    }

    // Метод для обновления текста на экране
    void UpdateTimerText()
    {
        // Отображаем оставшееся время на экране в формате минут:секунд
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.Floor(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Метод для загрузки следующего уровня
    void LoadNextLevel()
    {
        // Получаем текущую сцену и загружаем следующую
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(2);
    }
}
