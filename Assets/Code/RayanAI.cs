using UnityEngine;
using UnityEngine.AI;

public class RayanAI : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������
    private NavMeshAgent agent; // ��������� NavMeshAgent

    void Start()
    {
        // ���� ������ �� ����
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (player != null)
        {
            // ������������� ���� ��� �����������
            agent.SetDestination(player.position);
        }
    }
}
