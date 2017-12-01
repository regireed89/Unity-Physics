using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    [CreateAssetMenu(menuName = "Agent")]
    public abstract class Agent : ScriptableObject {

        [SerializeField]
        protected float mass;
        [SerializeField]
        public Vector3 velocity;
        [SerializeField]
        protected Vector3 acceleration;
        [SerializeField]
        public Vector3 position;
        [SerializeField]
        protected float max_speed;
        [SerializeField]
        protected Vector3 force;

        public abstract Vector3 Update_Agent(float deltaTime);
        public Transform Owner;
        public bool Add_Force(float mag, Vector3 direction)
        {
            if (mag == 0)
                return false;
            var vector = mag * direction;
            force += vector;
            return true;
        }
        
        protected Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }


        public void OnStart(Transform owner)
        {
            Owner = owner;
            mass = 1;
            velocity = Utility.RandomVector3;
            acceleration = Utility.RandomVector3;
            position = owner.position;
            max_speed = 5;
        }

    }
}
