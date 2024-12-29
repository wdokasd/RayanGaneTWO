using UnityEngine;
using UnityEngine.AI;

public class EnemyAIAggressive : MonoBehaviour
{
    public Transform targetRayan; // ������ �� ������ � ����� "Rayan"

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // ���� ������ � ����� "Rayan"
        GameObject rayanObject = GameObject.FindGameObjectWithTag("RayanV2");
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
        if (targetRayan != null)
        {
            // ������� �� �������
            agent.SetDestination(targetRayan.position);
        }
    }
}
