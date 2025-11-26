using System;
using UnityEngine;

public class FleeBehavior : IBehavior
{
	[SerializeField] private float _speed = 5f;

	private Transform  _target;
	private GameObject _bearer;

	private Vector3    _currentDirection;
	private Vector3    _currentDistance;
	private float      _fleeDistance = 15f;

	public FleeBehavior (GameObject bearer, Transform target)
	{
		_target = target;
		_bearer = bearer;
	}

	public bool IsEngaged {get; set;}

	public void Update ()
	{
		if (IsEngaged)
		{
			_currentDirection = (_bearer.transform.position - _target.transform.position).normalized;
			_currentDirection.y = 0;

			Act();
		}
	}

	public void Act ()
	{
		if (Vector3.Distance(_bearer.transform.position, _target.transform.position) <= _fleeDistance)
		{
			Mover.MoveInDirection(_bearer, _currentDirection, _speed);
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
