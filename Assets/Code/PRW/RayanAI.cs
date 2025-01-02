using UnityEngine;
using UnityEngine.AI;

public class RayanAI : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public float followDistance = 2f; // ��������� ��������� ����� ������
    public float speedMultiplier = 2f; // �� ������� ��� Rayan ������� ������
    public float enemyAvoidanceRange = 5f; // ������ ��������� ������
    public float maxAvoidanceDistance = 10f; // ������������ ���������� ��� ��������� ������
    public float maxDistanceFromPlayer = 10f; // ������������ ��������� �� ������

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed *= speedMultiplier; // ����������� �������� Rayan � ��� ����
    }

    void Update()
    {
        // �������� ��������� ������
        if (AvoidEnemies())
        {
            return; // ���� �������� ������, �� ���������� ��������� �� �������
        }

        // ������� �� �������
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > followDistance)
        {
            // ���� ���������� �� ������ ������ ���������, �������� � ����
            agent.SetDestination(player.position);
        }
        else
        {
            // ��������������� ����� � �������
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
                // ���� ����� ���� ����, ������� �� ����
                Vector3 directionAwayFromEnemy = transform.position - collider.transform.position;
                Vector3 potentialDestination = transform.position + directionAwayFromEnemy.normalized * enemyAvoidanceRange;

                // ���������, ����� Rayan �� ������� ������ maxDistanceFromPlayer �� ������
                Vector3 clampedDestination = ClampToPlayerRadius(potentialDestination);

                agent.SetDestination(clampedDestination);
                return true; // �������� �����
            }
        }

        return false; // ������ ����� ���
    }

    private Vector3 ClampToPlayerRadius(Vector3 destination)
    {
        Vector3 directionToDestination = destination - player.position;
        if (directionToDestination.magnitude > maxDistanceFromPlayer)
        {
            // ������������ ����� ���������� �������� ������ ������
            return player.position + directionToDestination.normalized * maxDistanceFromPlayer;
        }
        return destination;
    }

    void OnDrawGizmosSelected()
    {
        // ����������� ���� ��������� ������ ��� �������
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyAvoidanceRange);

        // ����������� ������������� ���������� �� ������
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, maxDistanceFromPlayer);
    }
}
