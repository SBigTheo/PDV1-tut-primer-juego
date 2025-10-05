using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Vector3 offSet;
    private PlayerMovement playerMovement;

    [SerializeField] private float smoothSpeed = 5f;

    void Start()
    {
        offSet = new Vector3(0f, 0f, -2f);
        playerMovement = Object.FindFirstObjectByType<PlayerMovement>();
    }

    private void LateUpdate()
    {
        if (playerMovement == null) return;
        Vector3 targetPosition = playerMovement.transform.position + offSet;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}