using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    public class BoidBehavior : AgentBehavior
    {
        public void setBoid(Boids b)
        {
            agent = b;
        }

        // Use this for initialization
        void Start()
        {
            
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