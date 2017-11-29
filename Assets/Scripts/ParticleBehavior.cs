using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    
    public class ParticleBehavior : MonoBehaviour
    {
        [SerializeField]
        public Particle particle;
        // Use this for initialization
        void Start()
        {
            particle = new Particle();
            particle.AddForce(Vector3.right);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.position = particle.Update(Time.fixedDeltaTime);
        }
    }
}
