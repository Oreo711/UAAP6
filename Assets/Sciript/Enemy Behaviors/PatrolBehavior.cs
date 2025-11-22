using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : Behavior
{
    [SerializeField] private WaypointRoute _route;

    public override bool IsEngaged {get; set;}
    private int _currentWaypointIndex = 0;

    public void SetRoute (WaypointRoute route)
    {
        _route = route;
    }

    private void Update ()
    {
        if (IsEngaged)
        {
            Act();
        }
    }

    public override void Act ()
    {
        Mover.MoveToTarget(gameObject, _route.Waypoints[_currentWaypointIndex], 5f);

        if ((_route.Waypoints[_currentWaypointIndex].position - transform.position).magnitude < 0.1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _route.Waypoints.Count;
        }
    }
}
