using UnityEngine;

public class SmoothMovement : IMovementStrategy
{
    public void Move(Transform transform, float speed, float direction)
    {
        float moveInX = direction * speed * Time.deltaTime;
        transform.Translate(moveInX, 0, 0);
    }
}