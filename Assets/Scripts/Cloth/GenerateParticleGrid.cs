using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class GenerateParticleGrid : MonoBehaviour
    {
        public GameObject obj;
        public Vector2 mapSize;
        public float outLinePercent;

        void Awake()
        {
            string holderName = "Generated Map";
            if (transform.Find(holderName))
            {
                DestroyImmediate(transform.Find(holderName).gameObject, false);
            }
            Transform mapHolder = new GameObject(holderName).transform;
            mapHolder.parent = transform;
            for (int i = 0; i < mapSize.x; i++)
            {
                for (int j = 0; j < mapSize.y; j++)
                {
                    GameObject p = Instantiate(obj, new Vector3(i, j, 7), Quaternion.identity);
                    p.transform.localScale = Vector3.one * (1 - outLinePercent);
                    p.AddComponent<ParticleBehavior>();
                    gameObject.GetComponent<SpringDamperBehavior>().particles.Add(p.GetComponent<ParticleBehavior>());
                }
            }
            ApplyDampers();
        }
        // Update is called once per frame
        void Update()
        {

        }

        void ApplyDampers()
        {
            var pb = GetComponent<SpringDamperBehavior>();
            for (int i = 0; i <= mapSize.x; i++)
            {               
                pb.sd = new SpringDamper(pb.particles[i].particle, pb.particles[i++].particle, 10, .3f, 5);   
            }
        }
      
    }
}