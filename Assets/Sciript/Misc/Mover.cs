using UnityEngine;

public static class Mover
{
    public static void MoveToTarget (GameObject body, Transform target, float speed)
    {
        body.transform.position = Vector3.MoveTowards(body.transform.position, target.position, speed * Time.deltaTime);
    }

    public static void MoveInDirection (GameObject body, Vector3 direction, float speed)
    {
        body.transform.Translate(direction * (speed * Time.deltaTime));
    }

    public static void LookInDirection (GameObject body, Vector3 direction, float speed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
        float      step         = speed * Time.deltaTime;

        body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, lookRotation, step);
    }
}
