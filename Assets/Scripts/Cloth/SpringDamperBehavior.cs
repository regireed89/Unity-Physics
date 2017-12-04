using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper sD;
        [SerializeField]
        public List<ParticleBehavior> particles;
        public List<SpringDamper> springDampers;

        public void Start()
        {
            for (int i = 0; i <= particles.Count - 1; i++)
            {
                Particle p1 = particles[i].particle;
                Particle p2 = particles[i+1].particle;
                ApplyDampers(p1, p2);
            }
              
        }

        // Update is called once per frame
        void Update()
        {
            foreach (SpringDamper s in springDampers)
                s.ComputeForce();
        }

        void ApplyDampers(Particle part1, Particle part2)
        {
            sD = new SpringDamper(part1, part2, 10, .3f, 5);
            springDampers.Add(sD);
        }
    }
}