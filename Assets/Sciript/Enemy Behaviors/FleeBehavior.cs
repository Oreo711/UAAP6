using System;
using UnityEngine;

public class FleeBehavior : MonoBehaviour, IBehavior
{
	[SerializeField] private float _speed = 5f;

	private Transform _target;
	private Vector3   _currentDirection;
	private Vector3   _currentDistance;
	private float    _fleeDistance = 15f;

	public bool IsEngaged {get; set;}

	public void SetTarget (Transform target)
	{
		_target = target;
	}

	private void Update ()
	{
		if (IsEngaged)
		{
			_currentDirection = (transform.position - _target.transform.position).normalized;
			_currentDirection.y = 0;

			Act();
		}
	}

	public void Act ()
	{
		if (Vector3.Distance(transform.position, _target.transform.position) <= _fleeDistance)
		{
			Mover.MoveInDirection(gameObject, _currentDirection, _speed);
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
