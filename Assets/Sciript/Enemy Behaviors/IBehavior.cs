using UnityEngine;


public interface IBehavior
{
    bool IsEngaged {get; set;}

    void Act ();

    void Engage ();

    void Disengage ();

}
