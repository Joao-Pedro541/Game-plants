using UnityEngine;
using UnityEngine.AI;
public class enemyControl : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;

    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
    }


}
