using UnityEngine;

public class AceleratedMoveCommand : ICommand
{
    private PlayerMovement playerMovement;

    public AceleratedMoveCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    public void Execute(float value)
    {
        playerMovement.SetMovementStrategy(new AcelerateMovement());
        playerMovement.MovePlayer(value);
    }
}