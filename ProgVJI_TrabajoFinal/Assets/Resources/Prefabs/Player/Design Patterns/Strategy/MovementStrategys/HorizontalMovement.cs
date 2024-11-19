using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : IMovementStrategy
{
    public void Move(Transform transform, float speed, float direction)
    {
        transform.Translate(direction * speed * Time.deltaTime, 0f, 0f);
    }
}
