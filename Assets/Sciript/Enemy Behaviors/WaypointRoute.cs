using System.Collections.Generic;
using UnityEngine;

public class WaypointRoute : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;

    public List<Transform> Waypoints => _waypoints;
}
