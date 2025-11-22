using System;
using UnityEngine;

public class SuicideBehavior : Behavior
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
        Destroy(gameObject);
    }
}
