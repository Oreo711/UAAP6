using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class WanderBehavior : MonoBehaviour, IBehavior
{
	[SerializeField] private float   _speed = 2f;
	[SerializeField] private float   _changeDirectionCooldown = 1f;

	private float   _remainingCooldown;
	private Vector3 _currentDirection;

	public bool IsEngaged {get; set;}

	private void Awake ()
	{
		_remainingCooldown = _changeDirectionCooldown;
	}

	private void Update ()
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

		Mover.MoveInDirection(gameObject, _currentDirection, _speed);
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
