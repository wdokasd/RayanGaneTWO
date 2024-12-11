using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public Transform Rayan; // ������ �� ������ ������
    private NavMeshAgent agent; // ��������� NavMeshAgent

    void Start()
    {
        // ���� ������ �� ����
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        GameObject rayanObject = GameObject.FindGameObjectWithTag("Rayan");
        if (rayanObject != null)
        {
            Rayan = rayanObject.transform;
        }

        else
        {
            Player = playerObject.transform;
        }

        agent = GetComponent<NavMeshAgent>();

    }


    void Update()
    {
        if (Rayan != null)
        {
            // ������������� ���� ��� �����������
            agent.SetDestination(Rayan.position);
        }

        else
        {
            agent.SetDestination(Player.position);
        }
        
    }
}
