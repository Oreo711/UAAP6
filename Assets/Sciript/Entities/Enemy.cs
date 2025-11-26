using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehavior _passiveBehavior;
    private IBehavior _activeBehavior;

    public void SetBehaviors (IBehavior passive, IBehavior active)
    {
        _passiveBehavior = passive;
        _activeBehavior = active;
    }

    private void Start ()
    {
        Disengage();
    }

    private void Update ()
    {
        _passiveBehavior.Update();
        _activeBehavior.Update();
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
        _passiveBehavior.Disengage();
        _activeBehavior.Engage();
    }

    private void Disengage ()
    {
        _passiveBehavior.Engage();
        _activeBehavior.Disengage();
    }

    public void Destroy ()
    {
        Destroy(gameObject);
    }
}
