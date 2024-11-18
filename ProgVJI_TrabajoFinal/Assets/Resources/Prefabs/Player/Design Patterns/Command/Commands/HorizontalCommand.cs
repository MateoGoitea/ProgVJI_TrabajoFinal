using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCommand : ICommand
{
    private  PlayerMovement _playerMovement;
    private float _input;

    public HorizontalCommand(PlayerMovement playerMovement)
    {
        this._playerMovement = playerMovement;
    }

    public void Execute()
    {
        _input = Input.GetAxis("Horizontal");
        _playerMovement.MovePlayerX(_input);
        
    }

 
}
