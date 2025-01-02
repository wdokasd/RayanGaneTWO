// Код для спавна врагов
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform[] spawnPoints; // Точки спавна врагов
    public float spawnInterval = 60f; // Интервал в секундах между волнами
    public int enemiesPerWave = 10; // Количество врагов за волну

    void Start()
    {
        // Запускаем корутину спавна врагов
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                // Выбираем случайную точку спавна
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Создаем врага
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }

            // Ждем перед следующей волной
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}