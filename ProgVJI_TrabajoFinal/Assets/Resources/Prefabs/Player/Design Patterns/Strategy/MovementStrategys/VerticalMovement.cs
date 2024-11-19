using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : IMovementStrategy
{
    public void Move(Transform transform, float speed, float direction)
    {
        transform.Translate( 0f, direction * speed * Time.deltaTime, 0f);
    }
}
