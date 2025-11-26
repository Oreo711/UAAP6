using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class WanderBehavior : IBehavior
{
	[SerializeField] private float   _speed = 2f;
	[SerializeField] private float   _changeDirectionCooldown = 1f;

	private float   _remainingCooldown;
	private Vector3 _currentDirection;

	private GameObject _bearer;

	public WanderBehavior (GameObject bearer)
	{
		_bearer            = bearer;
		_remainingCooldown = _changeDirectionCooldown;
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
		_remainingCooldown -= Time.deltaTime;

		if (_remainingCooldown <= 0f)
		{
			_currentDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
			_remainingCooldown = _changeDirectionCooldown;
		}

		Mover.MoveInDirection(_bearer, _currentDirection, _speed);
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
