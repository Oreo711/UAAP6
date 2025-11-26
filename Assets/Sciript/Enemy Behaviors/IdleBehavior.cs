using System;
using UnityEngine;

public class IdleBehavior : IBehavior
{
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
