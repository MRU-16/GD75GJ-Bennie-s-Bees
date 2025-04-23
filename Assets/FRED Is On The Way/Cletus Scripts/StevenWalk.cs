using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StevenWalk : MonoBehaviour
{
    [SerializeField] private Targets _target;
    [field: SerializeField] public FredEyes Vision { get; private set; }
    [SerializeField] private float _waypointReachedDistance = 20f;
    [SerializeField] private float _patrolSpeedMultiplier = 5f;
    private Rigidbody _rigidbody;
    [SerializeField] private GameObject player;
    [SerializeField] private BoxCollider _collider;
    private NavMeshAgent enemy;

    [SerializeField] private string _currentStateName;

    public bool IsTargetValid => _target != null && _target.IsTargetable;
    public bool IsTargetVisible => Vision.TestVisibility(_target.transform.position);
    public float TargetDistance => Vector3.Distance(_target.transform.position, transform.position);
    public Vector3 TargetPosition => _target.transform.position;

    private IEnumerator _currentState;
    [SerializeField] private PatrolPoints[] _waypoints;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
        _waypoints = FindObjectsByType<PatrolPoints>(FindObjectsSortMode.None);
        ChangeState(WanderState());
    }

    private void ChangeState(IEnumerator newState)
    {
        // stop current state
        if (_currentState != null) StopCoroutine(_currentState);

        _currentState = newState;
        _currentStateName = _currentState.ToString();
        StartCoroutine(_currentState);
    }

    private void TryFindTarget()
    {
        if (IsTargetValid) return;
        _target = Vision.GetFirstVisibleTarget(1);
    }

    private PatrolPoints FindRandomPatrolPoints()
    {
        if (_waypoints == null || _waypoints.Length == 0) return null;

        int randomIndex = Random.Range(0, _waypoints.Length);
        return _waypoints[randomIndex];
    }

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
}
