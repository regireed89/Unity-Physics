using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper sD;
        public Triangle T;
        [Range(0, 10)]
        public float KS, KD, LO;
        public Vector3 windForce;
        [SerializeField]
        public List<ParticleBehavior> particles;
        public List<SpringDamper> springDampers;
        public List<Triangle> triangles;
        GenerateParticleGrid map;

        public void Start()
        {
            map = GetComponent<GenerateParticleGrid>();
            Particle p1;
            Particle p2;
            triangles = new List<Triangle>();
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
                if (!(i % map.mapSize == 0))
                    ApplyDampers(p1, p2);
            }

            //Diagonal Right
            for (int i = 0; i < particles.Count - 1; i++)
            {
                p1 = particles[i].particle;
                if (i + (map.mapSize + 1) > particles.Count - 1)
                    continue;
                else
                {
                    p2 = particles[i + (map.mapSize + 1)].particle;
                }
                if (!(i != 0 && (i + 1) % map.mapSize == 0))
                    ApplyDampers(p1, p2);
            }

            //Bending Spring 
            for (int i = 0; i < particles.Count - 1; i++)
            {
                p1 = particles[i].particle;

                if (i + 2 > particles.Count - 1)
                    continue;
                else
                {
                    p2 = particles[i + 2].particle;
                }
                if ((i + 2) % map.mapSize == 0)
                    continue;
                if (!(i != 0 && (i + 1) % map.mapSize == 0))
                    ApplyBendingSpring(p1, p2);
            }

            for (int i = 0; i < particles.Count - 1; i++)
            {
                p1 = particles[i].particle;
                if (i + (map.mapSize * 2) > particles.Count - 1)
                    continue;
                else
                {
                    p2 = particles[i + (map.mapSize * 2)].particle;
                }
                ApplyBendingSpring(p1, p2);
            }

            for (int i = 0; i < particles.Count - map.mapSize; i++)
            {
                if (!(i != 0 && (i - 1) % map.mapSize == 0))
                    continue;
                else
                {
                    triangles.Add(new HookesLaw.Triangle(particles[i].particle, particles[i + 1].particle, particles[i + map.mapSize].particle));

                    triangles.Add(new HookesLaw.Triangle(particles[i].particle, particles[i + map.mapSize].particle, particles[i + map.mapSize + 1].particle));
                }
                    
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (SpringDamper s in springDampers)
                s.ComputeForce(KS, KD, LO);

            foreach (Triangle t in triangles)
                t.AerodynamicForce(windForce);
        }

        void ApplyDampers(Particle part1, Particle part2)
        {
            sD = new SpringDamper(part1, part2, 10, .3f, 2);
            springDampers.Add(sD);
        }
        void ApplyBendingSpring(Particle part1, Particle part2)
        {
            sD = new SpringDamper(part1, part2, 10, .3f, 4);
            springDampers.Add(sD);
        }
    }
}