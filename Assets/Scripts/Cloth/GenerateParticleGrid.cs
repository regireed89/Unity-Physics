using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class GenerateParticleGrid : MonoBehaviour
    {
        public GameObject obj;
        public int mapSize;
        public float outLinePercent;

        void Awake()
        {
            gameObject.GetComponent<SpringDamperBehavior>().springDampers = new List<SpringDamper>();
            gameObject.GetComponent<SpringDamperBehavior>().triangles = new List<Triangle>();
            gameObject.GetComponent<SpringDamperBehavior>().bending = new List<SpringDamper>();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    GameObject p = Instantiate(obj, new Vector3(i, j, 7), Quaternion.identity);
                    p.transform.localScale = Vector3.one * (1 - outLinePercent);
                    p.AddComponent<ParticleBehavior>();
                    p.GetComponent<ParticleBehavior>().particle = new Particle(p.transform.position, Vector3.zero, 1);
                    gameObject.GetComponent<SpringDamperBehavior>().particles.Add(p.GetComponent<ParticleBehavior>());
                }
            }

        }
        private void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}