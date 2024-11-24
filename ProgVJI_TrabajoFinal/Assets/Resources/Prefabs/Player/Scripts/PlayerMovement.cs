using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private IMovementStrategy _movement;
    private Player _player;


    private void Start()
    {
        _player = new Player();
        //Destroy(gameObject,3f); //se utilizo para probar spawn del player
    }

    private void SetMovementStrategy(IMovementStrategy _movement)
    {
        this._movement = _movement;
    }
    
    public void MovePlayerX(float input)
    {
        SetMovementStrategy(new HorizontalMovement());
        _movement.Move(transform, _player.Velocity, input);
    }
    public void MovePlayerY(float input)
    {
        SetMovementStrategy(new VerticalMovement());
        _movement.Move(transform, _player.Velocity, input);
    }
}
