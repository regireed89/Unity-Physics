using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    public class Boids : Agent
    {
        public Transform _owner;
        void Initialize(Transform owner)
        {

        }
        public override Vector3 Update_Agent(float deltaTime)
        {
            UnityEngine.Assertions.Assert.IsFalse(mass == 0);
            acceleration = force * 1 / mass;
            velocity += acceleration * deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, max_speed);
            position += velocity * deltaTime;
            return position;
        }

        public override bool Add_Force(float mag, Vector3 direction)
        {
            if (mag == 0)
                return false;

            var f = mag * direction;
            force += f;
            return true;
        }
    }
}