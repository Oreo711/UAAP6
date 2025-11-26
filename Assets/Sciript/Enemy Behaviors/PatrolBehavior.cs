using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : IBehavior
{
    [SerializeField] private WaypointRoute _route;

    private int _currentWaypointIndex = 0;
    private GameObject _bearer;

    public PatrolBehavior (GameObject bearer, WaypointRoute route)
    {
        _route  = route;
        _bearer = bearer;
    }

    public bool IsEngaged {get; set;}

    public void Update ()
    {
        if (IsEngaged)
        {
            Act();
        }
    }

    public void Act ()
    {
        Mover.MoveToTarget(_bearer, _route.Waypoints[_currentWaypointIndex], 5f);

        if ((_route.Waypoints[_currentWaypointIndex].position - _bearer.transform.position).magnitude < 0.1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _route.Waypoints.Count;
        }
    }

    public void Engage ()
    {
        IsEngaged = true;
    }

    public void Disengage ()
    {
        IsEngaged = false;
    }
}
