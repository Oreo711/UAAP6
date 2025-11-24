using UnityEngine;


public class Player : MonoBehaviour
{
	  [SerializeField] private float _speed = 5;

	  public bool IsMoving {get; private set;} = false;
	  public Vector3 MoveDirection {get; private set;}


	  private float _deadZone = 0.1f;

	  private void Update()
	  {
		  Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		  if (input.magnitude <= _deadZone)
		  {
			  IsMoving = false;
			  return;
		  }

		  Vector3 normalizedInput = input.normalized;
		  MoveDirection = normalizedInput;

		  IsMoving = true;

		  Mover.MoveInDirection(gameObject, normalizedInput, _speed);
	  }
}
