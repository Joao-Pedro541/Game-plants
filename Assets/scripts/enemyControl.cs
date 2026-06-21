using UnityEngine;
using UnityEngine.AI;
public class enemyControl : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;
    [SerializeField]

    private float lifeEnemy = 50f;
    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
        if (lifeEnemy <= 0) Destroy(gameObject);
    }

    public void takeDamage(float damage)
    {
        print("Enemy took " + damage + " damage.");
        lifeEnemy -= damage;
    }


}
