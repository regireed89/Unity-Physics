using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper sD;
        Triangle T;
       

        [HideInInspector]
        public List<ParticleBehavior> particles;
        public List<SpringDamper> springDampers;
        public List<SpringDamper> bending;
        public List<Triangle> triangles;
        GenerateParticleGrid map;

        public Slider KsSlider;
        public Slider KdSlider;
        public Toggle Wind;
        float KS, KD, LO;
        public Vector3 windForce;
        public void Start()
        {
            map = GetComponent<GenerateParticleGrid>();
            T = new Triangle();
            ConnectDampers();
            ConnectBendingSprings();
            CreateTriangles();
            LO = 2;
            KS = KsSlider.value;
            KD = KdSlider.value;


        }

        // Update is called once per frame
        void Update()
        {
            foreach (SpringDamper s in springDampers)
                s.ComputeForce(KS, KD, LO);
            foreach (SpringDamper b in bending)
                b.ComputeForce(KS, KD, 4);




            foreach (var t in triangles)
            {
                t.p = 8;
                t.Cd = 3;
                if(Wind.isOn)
                    t.AerodynamicForce(windForce);
            }


        }
        void ConnectDampers()
        {
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
        }
        void ApplyDampers(Particle part1, Particle part2)
        {
            sD = new SpringDamper(part1, part2, 10, .3f, 2);
            springDampers.Add(sD);
        }
        void ConnectBendingSprings()
        {
            Particle p1;
            Particle p2;
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

        }
        void ApplyBendingSpring(Particle part1, Particle part2)
        {
            sD = new SpringDamper(part1, part2, 10, .3f, 4);
            bending.Add(sD);
        }

        void CreateTriangles()
        {
            for (int i = 0; i < particles.Count - map.mapSize; i++)
            {
                if (i + map.mapSize > particles.Count - 1 || i + map.mapSize + 1 > particles.Count - 1)
                    continue;
                else
                {
                    T = new HookesLaw.Triangle(particles[i].particle, particles[i + 1].particle, particles[i + map.mapSize].particle);
                    triangles.Add(T);
                    T = new HookesLaw.Triangle(particles[i].particle, particles[i + map.mapSize].particle, particles[i + map.mapSize + 1].particle);
                    triangles.Add(T);
                }
            }
        }
    }
}