using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FredEyes : MonoBehaviour
{
    [SerializeField] private float _FOV = 120f;
    [SerializeField] private float _range = 5f;
    [SerializeField] private Transform _head;
    [SerializeField] private LayerMask _occlusionMask;
    [SerializeField] private LayerMask _visibilityMask;

    // useful properties
    public Vector3 HeadPosition => _head.position;
    public Vector3 HeadDirection => _head.forward;

    public bool TestVisibility(Vector3 point)
    {
        // distance
        float distance = Vector3.Distance(HeadPosition, point);
        if (distance > _range) return false;

        // angle
        Vector3 dirToPoint = (point - HeadPosition).normalized;
        float angle = Vector3.Angle(HeadDirection, dirToPoint);
        if (angle > _FOV * 0.5f) return false;

        if (Physics.Linecast(HeadPosition, point, _occlusionMask)) return false;

        return true;
    }

    public List<Targets> GetVisibleTargets(int team)
    {
        List<Targets> targets = new List<Targets>();

        Collider[] hits = Physics.OverlapSphere(HeadPosition, _range, _visibilityMask);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject == gameObject) continue;                              // skip ourselves
            if (!hit.TryGetComponent(out Targets target)) continue;               // skip objects without Targetable
            if (target.Team == team) continue;                                       // skip allies
            if (!target.IsTargetable) continue;                                      // skip not targetable
            if (!TestVisibility(target.transform.position + Vector3.up)) continue;   // skip not visible, checking 1m up to ensure check doesn't hit ground

            // all tests passed, add target to list
            targets.Add(target);
        }
        return targets;
    }

    public Targets GetFirstVisibleTarget(int team)
    {
        List<Targets> targets = GetVisibleTargets(team);
        if (targets.Count == 0) return null;
        return targets[0];
    }

    private void OnDrawGizmosSelected()
    {
        if (_head == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(HeadPosition, _range);
        Gizmos.DrawRay(HeadPosition, HeadDirection * _range);
    }
}