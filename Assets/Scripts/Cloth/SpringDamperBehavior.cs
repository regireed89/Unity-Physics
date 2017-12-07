using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper sD;
        [Range(0, 10)]
        public float KS, KD, LO;
        [SerializeField]
        public List<ParticleBehavior> particles;
        public List<SpringDamper> springDampers;
        GenerateParticleGrid map;

        public void Start()
        {
            map = GetComponent<GenerateParticleGrid>();
            Particle p1;
            Particle p2;
            //Vertical
            for (int i = 0; i < particles.Count - 1; i++)
            {
                p1 = particles[i].particle;
                p2 = particles[i + 1].particle;
                if (!(i != 0 && (i + 1) % map.mapSize == 0))
                    ApplyDampers(p1, p2);
            }

            for (int i = 0; i < particles.Count - map.mapSize; i++)
            {
                //Horizontal
                p1 = particles[i].particle;
                p2 = particles[i + (int)map.mapSize].particle;
                ApplyDampers(p1, p2);
                //Diagonal Left
                p2 = particles[i + (map.mapSize - 1)].particle;
                ApplyDampers(p1, p2);
                //Bending Spring 
                p2 = particles[i + 2].particle;
                if ((i + 2) % map.mapSize == 0)
                    continue;
                if (!(i != 0 && (i + 1) % map.mapSize == 0))
                    ApplyDampers(p1, p2);
            }
            //Diagonal Right
            for (int i = 0; i < particles.Count - 1; i++)
            {
                p1 = particles[i].particle;
                p2 = particles[i + (map.mapSize + 1)].particle;
                if (!(i != 0 && (i + 1) % map.mapSize == 0))
                    ApplyDampers(p1, p2);
            }




        }

        // Update is called once per frame
        void Update()
        {
            foreach (SpringDamper s in springDampers)
                s.ComputeForce(KS, KD, LO);
        }

        void ApplyDampers(Particle part1, Particle part2)
        {
            sD = new SpringDamper(part1, part2, 10, .3f, 2);
            springDampers.Add(sD);
        }
    }
}