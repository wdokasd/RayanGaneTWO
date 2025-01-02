using UnityEngine;
using UnityEngine.AI;

public class EnemyAIAggressive : MonoBehaviour
{
    public Transform targetRayan; // Ссылка на объект с тегом "Rayan"

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Ищем объект с тегом "Rayan"
        GameObject rayanObject = GameObject.FindGameObjectWithTag("RayanV2");
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
        if (targetRayan != null)
        {
            // Следуем за Райаном
            agent.SetDestination(targetRayan.position);
        }
    }
}
