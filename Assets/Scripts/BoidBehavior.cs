using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    public class BoidBehavior : AgentBehavior
    {
        private FlockBehaviour fb;
        public float DFac;
        public float CFac;
        public float AFac;
        public void Start()
        {
            fb = new FlockBehaviour();
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
            if (dist > 15f)
            {
                boundary = dist * (Vector3.zero - transform.position);
            }
            
            agent.Add_Force(boundary.magnitude, boundary.normalized);

            var v1 = fb.Dispersion(boid);
            var v2 = fb.Cohesion(boid);
            var v3 = fb.Alignment(boid);

            
            agent.Add_Force(DFac, v1.normalized);
            Debug.DrawLine(agent.position, agent.position + agent.velocity);
            agent.Add_Force(CFac, v2.normalized);
            agent.Add_Force(AFac, v3.normalized);
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