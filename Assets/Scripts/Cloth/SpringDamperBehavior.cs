using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper sD;
        [SerializeField]
        public ParticleBehavior p1, p2;
        //public List<ParticleBehavior> particles;
        //public List<SpringDamper> springDampers;

        public void Start()
        {
            sD = new SpringDamper(p1.particle, p2.particle, 10, .3f, 5);
            //for (int i = 0; i <= particles.Count; i++)
                //ApplyDampers(particles[i].particle, particles[i++].particle);
        }

        // Update is called once per frame
        void Update()
        {
            //foreach(SpringDamper s in springDampers)
            
                sD.ComputeForce();
            
        }

        void ApplyDampers(Particle part1, Particle part2)
        {
                //sD = new SpringDamper(part1, part2, 10, .3f, 5);
                //springDampers.Add(sD);            
        }
    }
}