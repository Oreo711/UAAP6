using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
	[SerializeField] private Player   _player;

	[SerializeField] private float _rotationSpeed;



	private void Update ()
	{
		if (_player.IsMoving)
		{
			Mover.LookInDirection(gameObject, _player.MoveDirection, _rotationSpeed);
		}
	}
}
