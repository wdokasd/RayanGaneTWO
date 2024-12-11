using UnityEngine;
using UnityEngine.AI;

public class RayanAI : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    private NavMeshAgent agent; // Компонент NavMeshAgent

    void Start()
    {
        // Ищем игрока по тегу
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
            // Устанавливаем цель для перемещения
            agent.SetDestination(player.position);
        }
    }
}
