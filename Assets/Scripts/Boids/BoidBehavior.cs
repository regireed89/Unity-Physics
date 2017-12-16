using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    public class BoidBehavior : AgentBehavior
    {
        private FlockBehaviour fb;
        public void Start()
        {
            fb = FindObjectOfType<FlockBehaviour>();
        }

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
            if (dist > 5f)
            {
                boundary = dist * (Vector3.zero - transform.position);
            }

            agent.Add_Force(boundary.magnitude, boundary.normalized);

            var v1 = fb.Dispersion(boid);
            var v2 = fb.Cohesion(boid);
            var v3 = fb.Alignment(boid);


            agent.Add_Force(fb.Dfac.value, v1.normalized);
            Debug.DrawLine(agent.position, agent.position + agent.velocity);
            agent.Add_Force(fb.Cfac.value, v2.normalized);
            agent.Add_Force(fb.Afac.value, v3.normalized);
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