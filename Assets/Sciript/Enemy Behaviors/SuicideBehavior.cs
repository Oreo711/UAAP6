using System;
using UnityEngine;

public class SuicideBehavior : MonoBehaviour, IBehavior
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
        Destroy(gameObject);
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
