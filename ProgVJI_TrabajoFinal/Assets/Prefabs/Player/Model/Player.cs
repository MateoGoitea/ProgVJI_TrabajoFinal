using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    private float _velocity = 5f;
    private float _acceleration = 10f;

    public float Velocity { get => _velocity; set => _velocity = value; }
    public float Acceleration { get => _acceleration; set => _acceleration = value; }
}

