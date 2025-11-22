using System;
using UnityEngine;

public class FleeBehavior : Behavior
{
	[SerializeField] private float _speed = 5f;

	private Vector3 _currentDirection;

	public override bool IsEngaged {get; set;}

	private void OnTriggerStay (Collider other)
	{
		if (IsEngaged)
		{
			_currentDirection = (transform.position - other.transform.position).normalized;
			_currentDirection.y = 0;

			Act();
		}
	}

	public override void Act ()
	{
		Mover.MoveInDirection(gameObject, _currentDirection, _speed);
	}
}
