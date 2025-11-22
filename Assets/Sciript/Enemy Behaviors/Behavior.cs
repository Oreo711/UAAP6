using UnityEngine;


public abstract class Behavior : MonoBehaviour
{
    public abstract bool IsEngaged {get; set;}

    public abstract void Act ();

}
