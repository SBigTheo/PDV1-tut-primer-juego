using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private ICommand moveCommand;
    private ICommand aceleratedMoveCommand;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement == null)
        moveCommand = new MoveCommand(playerMovement);
        aceleratedMoveCommand = new AceleratedMoveCommand(playerMovement);
    }

    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horiz) > 0.001f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                aceleratedMoveCommand.Execute(horiz);
            }
            else
            {
                moveCommand.Execute(horiz);
            }
        }
    }
}