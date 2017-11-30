using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper springDamper;
        [SerializeField]
        ParticleBehavior p1, p2;
        // Use this for initialization
        void Start()
        {
            springDamper = new SpringDamper(p1.particle, p2.particle, 1f, 10f);          
        }

        // Update is called once per frame
        void Update()
        {
            Spring();
        }
        public void Spring()
        {
            var direction = (p1.particle.position - p2.particle.position);
            var length = direction.magnitude;
            
           
            var f = -springDamper.Ks * springDamper.Lo;

           
        }
    }
}