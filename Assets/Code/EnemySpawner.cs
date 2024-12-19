// ��� ��� ������ ������
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Transform[] spawnPoints; // ����� ������ ������
    public float spawnInterval = 60f; // �������� � �������� ����� �������
    public int enemiesPerWave = 10; // ���������� ������ �� �����

    void Start()
    {
        // ��������� �������� ������ ������
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                // �������� ��������� ����� ������
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // ������� �����
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }

            // ���� ����� ��������� ������
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}