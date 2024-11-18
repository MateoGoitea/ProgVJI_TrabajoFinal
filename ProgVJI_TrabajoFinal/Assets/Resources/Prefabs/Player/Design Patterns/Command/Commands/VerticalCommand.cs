using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCommand : ICommand
{
    private PlayerMovement _playerMovement;
    private float _input;

    public VerticalCommand(PlayerMovement playerMovement)
    {
        this._playerMovement = playerMovement;
    }

    public void Execute()
    {
        _input = Input.GetAxis("Vertical");
        _playerMovement.MovePlayerY(_input);
    }
}
