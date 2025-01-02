using UnityEngine;
using UnityEngine.AI;

public class RayanAI : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public float followDistance = 2f; // Дистанция остановки возле игрока
    public float speedMultiplier = 2f; // Во сколько раз Rayan быстрее врагов
    public float enemyAvoidanceRange = 5f; // Радиус избегания врагов
    public float maxAvoidanceDistance = 10f; // Максимальное расстояние для избегания врагов
    public float maxDistanceFromPlayer = 10f; // Максимальная дистанция от игрока

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed *= speedMultiplier; // Увеличиваем скорость Rayan в два раза
    }

    void Update()
    {
        // Избегаем ближайших врагов
        if (AvoidEnemies())
        {
            return; // Если избегаем врагов, не продолжаем следовать за игроком
        }

        // Следуем за игроком
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > followDistance)
        {
            // Если расстояние до игрока больше заданного, движемся к нему
            agent.SetDestination(player.position);
        }
        else
        {
            // Останавливаемся рядом с игроком
            agent.ResetPath();
        }
    }

    private bool AvoidEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemyAvoidanceRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Если рядом есть враг, убегаем от него
                Vector3 directionAwayFromEnemy = transform.position - collider.transform.position;
                Vector3 potentialDestination = transform.position + directionAwayFromEnemy.normalized * enemyAvoidanceRange;

                // Проверяем, чтобы Rayan не отходил дальше maxDistanceFromPlayer от игрока
                Vector3 clampedDestination = ClampToPlayerRadius(potentialDestination);

                agent.SetDestination(clampedDestination);
                return true; // Избегаем врага
            }
        }

        return false; // Врагов рядом нет
    }

    private Vector3 ClampToPlayerRadius(Vector3 destination)
    {
        Vector3 directionToDestination = destination - player.position;
        if (directionToDestination.magnitude > maxDistanceFromPlayer)
        {
            // Ограничиваем точку назначения радиусом вокруг игрока
            return player.position + directionToDestination.normalized * maxDistanceFromPlayer;
        }
        return destination;
    }

    void OnDrawGizmosSelected()
    {
        // Отображение зоны избегания врагов для отладки
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyAvoidanceRange);

        // Отображение максимального расстояния от игрока
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, maxDistanceFromPlayer);
    }
}
