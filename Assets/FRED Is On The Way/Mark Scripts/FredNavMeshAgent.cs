using UnityEngine;
using UnityEngine.AI;

public class FredNavMeshAgent : MonoBehaviour
{
    [SerializeField] public NavMeshAgent enemy;
    [SerializeField] public Transform player;
    [SerializeField] public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer() 
    {
        enemy.SetDestination(player.position);
    }
}
