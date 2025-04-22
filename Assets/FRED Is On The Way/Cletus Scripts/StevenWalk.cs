using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StevenWalk : FredMovement
{
    [SerializeField] private Targets _target;
    [field: SerializeField] public FredEyes Vision { get; private set; }
    [SerializeField] private float _waypointReachedDistance = 20f;
    [SerializeField] private float _patrolSpeedMultiplier = 5f;
    private Rigidbody _rigidbody;
    [SerializeField] private float killDistance = 10f;
    [SerializeField] private GameObject player;
    [SerializeField] private BoxCollider _collider;

    private NavMeshAgent enemy;

    [SerializeField] private string _currentStateName;

    // useful properties
    public bool IsTargetValid => _target != null && _target.IsTargetable;
    public bool IsTargetVisible => Vision.TestVisibility(_target.transform.position);
    public float TargetDistance => Vector3.Distance(_target.transform.position, transform.position);
    public Vector3 TargetPosition => _target.transform.position;

    private IEnumerator _currentState;
    [SerializeField] private PatrolPoints[] _waypoints;
    [SerializeField] private float attackDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator WanderState()
    {
        PatrolPoints patrolpoint = null;
        enemy.speed = _patrolSpeedMultiplier;

        // wander until valid target is spotted, then attack
        while (!IsTargetValid)
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
