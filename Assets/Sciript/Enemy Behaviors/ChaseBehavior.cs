using System;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseBehavior : IBehavior
{
	private float _speed            = 5f;
	private float _chaseEndDistance = 2f;
	private float _chaseEngageDistance = 15f;

	private Transform  _target;
	private GameObject _bearer;

	public ChaseBehavior (GameObject bearer, Transform target)
	{
		_target = target;
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
		Vector3 distance = _target.position - _bearer.transform.position;

		if (distance.magnitude > _chaseEndDistance && distance.magnitude < _chaseEngageDistance)
		{
			Mover.MoveToTarget(_bearer, _target, _speed);
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
