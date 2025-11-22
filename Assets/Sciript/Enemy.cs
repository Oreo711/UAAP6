using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Behavior _passiveBehavior;
    private Behavior _activeBehavior;

    public void SetBehaviors (Behavior passive, Behavior active)
    {
        _passiveBehavior = passive;
        _activeBehavior = active;
    }

    private void Start ()
    {
        Disengage();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Engage();
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Disengage();
        }
    }

    private void Engage ()
    {
        _passiveBehavior.IsEngaged = false;
        _activeBehavior.IsEngaged  = true;
    }

    private void Disengage ()
    {
        _passiveBehavior.IsEngaged = true;
        _activeBehavior.IsEngaged  = false;
    }
}
