using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper sd;
        [SerializeField]
        public ParticleBehavior[] particles;
        // Use this for initialization
        void Start()
        {            
            
            sd = new SpringDamper(particles[0].particle, particles[1].particle, 10f, .5f,3f );          
        }

        // Update is called once per frame
        void Update()
        {
            sd.ComputeForce();

        }
       
    }
}