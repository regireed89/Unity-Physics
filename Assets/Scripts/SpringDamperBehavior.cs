using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        SpringDamper sd;
        [SerializeField]
        ParticleBehavior p1, p2;
        // Use this for initialization
        void Start()
        {
            sd = new SpringDamper(p1.particle, p2.particle, 10f, .5f,3f );          
        }

        // Update is called once per frame
        void Update()
        {
            Spring();
        }
        public void Spring()
        {
            var e = sd._p2.position - sd._p1.position;
            var length = e.magnitude;
            var _e = e / length;

            var V1 = sd._p1.velocity;
            var V2 = sd._p2.velocity;
            var v1 = Vector3.Dot(_e, V1);
            var v2 = Vector3.Dot(_e, V2);

            var f = -sd.Ks*(sd.Lo - length) - sd.Kd*(v1 - v2);
            var f1 = f * _e;
            var f2 = -f1;
            sd._p1.AddForce(f1);
            Debug.DrawLine(sd._p1.position, sd._p2.position);
            sd._p2.AddForce(f2);
            
        }
    }
}