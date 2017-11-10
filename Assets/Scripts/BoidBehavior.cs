using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    public class BoidBehavior : AgentBehavior
    {
        public float SFac;
        public Boids boid
        {
            get { return (Boids)agent; }
        }
        public void setBoid(Boids b)
        {
            agent = b;
            agent.OnStart(transform);
        }

        public void Update()
        {
            var boundary = Vector3.zero;
            var dist = Vector3.Distance(transform.position, Vector3.zero);
            if (dist > 15f)
            {
                GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                boundary = dist * (Vector3.zero - transform.position);
            }

            foreach(var b in AgentFactory.agents)
            {
                agent.Add_Force(boundary.magnitude, boundary.normalized);
                agent.Add_Force(IFlockable.Dispersion(b).magnitude, IFlockable.Dispersion(b));
            }   
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (agent == null)
                return;
            transform.position = agent.Update_Agent(Time.deltaTime);
        }
    }
}