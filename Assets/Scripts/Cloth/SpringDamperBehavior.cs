using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class SpringDamperBehavior : MonoBehaviour
    {
        public SpringDamper sd;
        [SerializeField]
        public List<ParticleBehavior> particles;

        public void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
            sd.ComputeForce();
        }


    }
}