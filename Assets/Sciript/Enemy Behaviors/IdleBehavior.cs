using System;
using UnityEngine;

public class IdleBehavior : Behavior
{
	public override bool IsEngaged {get; set;}

	private void Update ()
	{
		if (IsEngaged)
		{
			Act();
		}
	}

	public override void Act ()
	{
		return;
	}
}
