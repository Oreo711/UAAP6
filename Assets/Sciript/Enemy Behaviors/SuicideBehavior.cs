using System;
using UnityEngine;

public class SuicideBehavior : IBehavior
{
    private GameObject _bearer;

    public SuicideBehavior (GameObject bearer)
    {
        _bearer = bearer;
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
        Enemy enemy = _bearer.GetComponent<Enemy>();
        enemy.Destroy();
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
