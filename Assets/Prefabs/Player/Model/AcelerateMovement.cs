using UnityEngine;

public class AcelerateMovement : IMovementStrategy
{
    private float currentSpeed = 0f;
    private float acceleration = 8f;

    public void Move(Transform transform, float maxSpeed)
    {
        currentSpeed += Input.GetAxis("Horizontal") * acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
        transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
    }
}