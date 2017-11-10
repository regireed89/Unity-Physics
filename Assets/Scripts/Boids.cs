using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    public class Boids : Agent
    {
        public override Vector3 Update_Agent(float deltaTime)
        {

            acceleration = force * (1 / mass);
            velocity += acceleration * deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, max_speed);
            Position += velocity * deltaTime;
            return Position;
        }
    }
}