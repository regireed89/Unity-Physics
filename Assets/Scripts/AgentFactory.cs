using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{


    public class Utility
    {
        public static Vector3 RandomVector3
        {
            get
            {
                var x = UnityEngine.Random.Range(-1, 1);
                var y = UnityEngine.Random.Range(-1, 1);
                var z = UnityEngine.Random.Range(-1, 1);

                var neww = new Vector3(x, y, z);
                if (neww.magnitude == 0)
                    neww = RandomVector3;

                return neww;
            }
        }
    }

    public class AgentFactory : MonoBehaviour
    {

        public int Count;
        public static List<Agent> agents;
        public static List<AgentBehavior> agentBehaviours;
        private List<GameObject> gameobjects;

        [ContextMenu("Create")]
        public void Create()
        {
            
            agents = new List<Agent>();
            agentBehaviours = new List<AgentBehavior>();
            for (int i = 0; i < Count; i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                go.transform.SetParent(transform);
                go.transform.position = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), Random.Range(-15, 15));
                go.name = string.Format("{0} {1}", "Agent: ", i);

                //this would be a specific component type
                //ie: Boid Particle Spring etc
                var behaviour = go.AddComponent<BoidBehavior>();
                var boid = ScriptableObject.CreateInstance<Boids>();
                boid.name = go.name;

                agents.Add(boid);
                agentBehaviours.Add(behaviour);
                behaviour.setBoid(boid);
            }
        }

        [ContextMenu("Destroy")]
        public void Destroy()
        {
            foreach (var behaviours in agentBehaviours)
                DestroyImmediate(behaviours.gameObject);

            agents.Clear();
            agentBehaviours.Clear();
        }
    }
}