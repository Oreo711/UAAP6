using System;
using UnityEngine;

public class ChaseBehavior : Behavior
{
	[SerializeField] private float _speed = 5f;
	[SerializeField] private float _chaseEndDistance = 2f;

	private Transform _target;

	public override bool IsEngaged {get; set;}

	private void OnTriggerStay (Collider other)
	{
		if (IsEngaged)
		{
			_target = other.transform;
			Act();
		}
	}

	public override void Act ()
	{
		Vector3 distance = _target.position - transform.position;

		if (distance.magnitude > _chaseEndDistance)
		{
			Mover.MoveToTarget(gameObject, _target, _speed);
		}
	}
}
