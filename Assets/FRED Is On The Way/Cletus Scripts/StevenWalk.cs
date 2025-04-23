using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StevenWalk : MonoBehaviour
{
    [SerializeField] private Targets _target;
    [field: SerializeField] public FredEyes Vision { get; private set; }
    [SerializeField] private float _waypointReachedDistance = 20f;
    [SerializeField] private float _patrolSpeedMultiplier = 5f;
    

    private NavMeshAgent enemy;

    [SerializeField] private string _currentStateName;

    private IEnumerator _currentState;
    [SerializeField] private PatrolPoints[] _waypoints;


    private IEnumerator WanderState()
    {
        PatrolPoints patrolpoint = null;
        enemy.speed = _patrolSpeedMultiplier;

        // wander until valid target is spotted, then attack
        while (true)
        {

            // find waypoint to move to
            if (patrolpoint == null || Vector3.Distance(patrolpoint.Position, transform.position) < _waypointReachedDistance) patrolpoint = FindRandomPatrolPoints();
            else enemy.SetDestination(patrolpoint.Position);

            yield return null;
        }
    }
    private PatrolPoints FindRandomPatrolPoints()
    {
        if (_waypoints == null || _waypoints.Length == 0) return null;

        int randomIndex = Random.Range(0, _waypoints.Length);
        return _waypoints[randomIndex];
    }
}
