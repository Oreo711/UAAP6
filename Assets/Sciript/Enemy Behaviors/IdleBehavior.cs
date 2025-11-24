using System;
using UnityEngine;

public class IdleBehavior : MonoBehaviour, IBehavior
{
	public bool IsEngaged {get; set;}

	private void Update ()
	{
		if (IsEngaged)
		{
			Act();
		}
	}

	public void Act ()
	{
		return;
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
