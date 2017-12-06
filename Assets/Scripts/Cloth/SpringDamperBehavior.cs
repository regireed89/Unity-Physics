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
        GenerateParticleGrid map;

        public void Start()
        {
            map = GetComponent<GenerateParticleGrid>();
            Particle p1;
            Particle p2;
            for (int i = 0; i <= particles.Count - 1; i++)
            {
                p1 = particles[i].particle;
                p2 = particles[i + 1].particle;
                if (!(i != 0 && (i + 1) % map.mapSize.x == 0))
                {
                    ApplyDampers(p1, p2);
                }
            }
            for (int i = 0; i <= particles.Count - 1; i++)
            {
                p1 = particles[i].particle;
                p2 = particles[i + map.mapSize.y].particle;
                if (!(i != 0 && (i + 1) % map.mapSize.y == 0))
                {
                    ApplyDampers(p1, p2);
                }
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
            sD = new SpringDamper(part1, part2, 10, .3f, 2);
            springDampers.Add(sD);
        }
    }
}