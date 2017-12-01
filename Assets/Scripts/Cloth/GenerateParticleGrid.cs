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

        void Start()
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
            ConnectDampers();
        }
        // Update is called once per frame
        void Update()
        {

        }

        void ConnectDampers()
        {
            var part = GetComponent<SpringDamperBehavior>();
            for (int i = 0; i == part.particles.Count - 2; i++)
            {
                part.sd._p1 = part.particles[i].particle;
                part.sd._p2 = part.particles[i++].particle;

            }
        }

    }
}