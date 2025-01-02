using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public Transform targetRayan; // Ссылка на объект с тегом "Rayan"
    public float visionRange = 10f; // Радиус "зрения" врага
    public float attackDistance = 2f; // Дистанция остановки возле цели
    public float chaseDuration = 30f; // Длительность преследования после выхода из зоны видимости
    public float alertRange = 30f; // Радиус, в котором враги будут предупреждены

    private NavMeshAgent agent;
    private Transform currentTarget; // Текущая цель врага
    private float chaseTimer = 0f; // Таймер преследования
    private bool isChasing = false; // Флаг преследования

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Находим объект с тегом "Rayan" в сцене
        GameObject rayanObject = GameObject.FindGameObjectWithTag("Rayan");
        if (rayanObject != null)
        {
            targetRayan = rayanObject.transform;
        }
        else
        {
            Debug.LogError("Объект с тегом 'Rayan' не найден!");
        }
    }

    void Update()
    {
        if (PlayerInVision())
        {
            // Если игрок в поле зрения, запускаем преследование "Rayan" и предупреждаем других врагов
            if (targetRayan != null)
            {
                currentTarget = targetRayan;
                isChasing = true;
                chaseTimer = chaseDuration; // Сбрасываем таймер преследования
                AlertNearbyEnemies(); // Предупреждаем ближайших врагов
            }
        }
        else if (isChasing)
        {
            // Уменьшаем таймер, если игрок вне зоны видимости
            chaseTimer -= Time.deltaTime;
            if (chaseTimer <= 0f)
            {
                isChasing = false;
                currentTarget = null; // Прекращаем преследование
            }
        }

        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.position);

            if (distance > attackDistance)
            {
                agent.SetDestination(currentTarget.position);
            }
            else
            {
                agent.ResetPath(); // Останавливаемся возле цели
            }
        }
    }

    private bool PlayerInVision()
    {
        // Проверяем, находится ли игрок в зоне зрения врага
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= visionRange;
    }

    private void AlertNearbyEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, alertRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Enemy") && collider.gameObject != gameObject)
            {
                EnemyAI enemyAI = collider.GetComponent<EnemyAI>();
                if (enemyAI != null)
                {
                    enemyAI.Alert(targetRayan);
                }
            }
        }
    }

    public void Alert(Transform target)
    {
        currentTarget = target;
        isChasing = true;
        chaseTimer = chaseDuration; // Сбрасываем таймер преследования
    }

    void OnDrawGizmosSelected()
    {
        // Отображение зоны "зрения" для отладки
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        // Отображение радиуса оповещения
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }
}
