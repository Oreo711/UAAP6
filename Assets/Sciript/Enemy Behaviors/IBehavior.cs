using UnityEngine;


public interface IBehavior
{
    bool IsEngaged {get; set;}

    void Update ();

    void Act ();

    void Engage ();

    void Disengage ();

}
