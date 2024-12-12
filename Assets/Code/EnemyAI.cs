using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public Transform targetRayan; // ������ �� ������ � ����� "Rayan"
    public float visionRange = 10f; // ������ "������" �����
    public float attackDistance = 2f; // ��������� ��������� ����� ����
    public float chaseDuration = 30f; // ������������ ������������� ����� ������ �� ���� ���������
    public float alertRange = 30f; // ������, � ������� ����� ����� �������������

    private NavMeshAgent agent;
    private Transform currentTarget; // ������� ���� �����
    private float chaseTimer = 0f; // ������ �������������
    private bool isChasing = false; // ���� �������������

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // ������� ������ � ����� "Rayan" � �����
        GameObject rayanObject = GameObject.FindGameObjectWithTag("Rayan");
        if (rayanObject != null)
        {
            targetRayan = rayanObject.transform;
        }
        else
        {
            Debug.LogError("������ � ����� 'Rayan' �� ������!");
        }
    }

    void Update()
    {
        if (PlayerInVision())
        {
            // ���� ����� � ���� ������, ��������� ������������� "Rayan" � ������������� ������ ������
            if (targetRayan != null)
            {
                currentTarget = targetRayan;
                isChasing = true;
                chaseTimer = chaseDuration; // ���������� ������ �������������
                AlertNearbyEnemies(); // ������������� ��������� ������
            }
        }
        else if (isChasing)
        {
            // ��������� ������, ���� ����� ��� ���� ���������
            chaseTimer -= Time.deltaTime;
            if (chaseTimer <= 0f)
            {
                isChasing = false;
                currentTarget = null; // ���������� �������������
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
                agent.ResetPath(); // ��������������� ����� ����
            }
        }
    }

    private bool PlayerInVision()
    {
        // ���������, ��������� �� ����� � ���� ������ �����
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
        chaseTimer = chaseDuration; // ���������� ������ �������������
    }

    void OnDrawGizmosSelected()
    {
        // ����������� ���� "������" ��� �������
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        // ����������� ������� ����������
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }
}
