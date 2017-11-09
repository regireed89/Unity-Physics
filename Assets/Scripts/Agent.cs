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
        protected Vector3 velocity;
        [SerializeField]
        protected Vector3 acceleration;
        [SerializeField]
        protected Vector3 position;
        [SerializeField]
        protected float max_speed;
        [SerializeField]
        protected Vector3 force;

        public abstract Vector3 Update_Agent(float deltaTime);
        public abstract bool Add_Force(float mag, Vector3 direction);
        
    }
}
