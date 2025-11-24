using System;
using UnityEngine;

public class ChaseBehavior : MonoBehaviour, IBehavior
{
	[SerializeField] private float _speed               = 5f;
	[SerializeField] private float _chaseEndDistance    = 2f;
	[SerializeField] private float _chaseEngageDistance = 15f;

	private Transform _target;

	public bool IsEngaged {get; set;}

	public void SetTarget (Transform target)
	{
		_target = target;
	}

	private void OnTriggerStay (Collider other)
	{
		if (IsEngaged)
		{
			_target = other.transform;
			Act();
		}
	}

	public void Act ()
	{
		Vector3 distance = _target.position - transform.position;

		if (distance.magnitude > _chaseEndDistance && distance.magnitude < _chaseEngageDistance)
		{
			Mover.MoveToTarget(gameObject, _target, _speed);
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
