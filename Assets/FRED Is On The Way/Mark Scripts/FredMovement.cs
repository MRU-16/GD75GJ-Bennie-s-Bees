using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FredMovement : MonoBehaviour
{
    [SerializeField] private Targets _target;
    [field: SerializeField] public FredEyes Vision { get; private set; }
    [SerializeField] private float _waypointReachedDistance = 20f;
    private Rigidbody _rigidbody;

    private NavMeshAgent enemy;

    [SerializeField] private string _currentStateName;

    // useful properties
    public bool IsTargetValid => _target != null && _target.IsTargetable;
    public bool IsTargetVisible => Vision.TestVisibility(_target.transform.position);
    public float TargetDistance => Vector3.Distance(_target.transform.position, transform.position);
    public Vector3 TargetPosition => _target.transform.position;

    private IEnumerator _currentState;
    [SerializeField]private PatrolPoints[] _waypoints;
    [SerializeField] private float attackDistance;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>(); 
        _rigidbody = GetComponent<Rigidbody>(); 
        _waypoints = FindObjectsByType<PatrolPoints>(FindObjectsSortMode.None);
        ChangeState(PatrolState());
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

    private IEnumerator PatrolState()
    {
        PatrolPoints patrolpoint = null;
        while (!IsTargetValid)
        {
            TryFindTarget();
            if (patrolpoint == null || Vector3.Distance(patrolpoint.Position, transform.position) < _waypointReachedDistance)
            {
                patrolpoint = FindRandomPatrolPoints();
            }
            else 
            {

                if (enemy.isActiveAndEnabled && enemy.isOnNavMesh)
                {
                    enemy.SetDestination(patrolpoint.Position);
                }
            }
            Debug.Log(Vector3.Distance(patrolpoint.Position, transform.position) < _waypointReachedDistance);
            yield return null;
        }
        Debug.Log("Stuck");
        ChangeState(FollowState());
    }


    private IEnumerator FollowState()
    {
        enemy.isStopped = false;

        while (_target != null)
        {
            float distance = Vector3.Distance(transform.position, TargetPosition);
            if (distance > attackDistance)
            {
                enemy.isStopped = false;
                if (enemy.isActiveAndEnabled && enemy.isOnNavMesh)
                {
                    enemy.SetDestination(TargetPosition);
                }
                Debug.DrawLine(transform.position, TargetPosition, Color.yellow);
            }
            else
            {
                enemy.isStopped = true;
                transform.LookAt(TargetPosition);
                Debug.DrawLine(transform.position, TargetPosition, Color.red);
            }
            yield return null;
        }
        ChangeState(PatrolState());
    }

}