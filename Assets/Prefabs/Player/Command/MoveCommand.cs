using UnityEngine;

public class MoveCommand : ICommand
{
    private PlayerMovement playerMovement;

    public MoveCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    public void Execute(float value)
    {
        playerMovement.SetMovementStrategy(new SmoothMovement());
        playerMovement.MovePlayer(value);
    }
}