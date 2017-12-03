using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{

    public class ParticleBehavior : MonoBehaviour
    {
        [SerializeField]
        public Particle particle;
        // Use this for initialization
        void Start()
        {
            particle = new Particle(transform.position, Vector3.zero, 1);

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.position = particle.Update(Time.fixedDeltaTime);
        }
        

        void OnMouseDrag()
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, particle.position.z);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            particle.position = objPosition;
        }
    }
}
