using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public Transform Rayan; // Ссылка на объект игрока
    private NavMeshAgent agent; // Компонент NavMeshAgent

    void Start()
    {
        // Ищем игрока по тегу
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
            // Устанавливаем цель для перемещения
            agent.SetDestination(Rayan.position);
        }

        else
        {
            agent.SetDestination(Player.position);
        }
        
    }
}
