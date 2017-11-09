using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{
    public class AgentFactory : MonoBehaviour {

        public int Count;
        public List<Agent> agents;
        public List<AgentBehavior> agentBehaviours;
        private List<GameObject> gameobjects;

        public static Vector3 RandomVector
        {
            get
            {
                var x = UnityEngine.Random.Range(-1, 1);
                var y = UnityEngine.Random.Range(-1, 1);
                var z = UnityEngine.Random.Range(-1, 1);

                var neww = new Vector3(x, y, z);
                if (neww.magnitude == 0)
                    neww = RandomVector;

                return neww;
            }
            
        }
        


        [ContextMenu("Create")]
        public void Create()
        {
            agents = new List<Agent>();
            agentBehaviours = new List<AgentBehavior>();
            for (int i = 0; i < Count; i++)
            {
                var go = new GameObject();
                var boid = ScriptableObject.CreateInstance<Boids>();

                //this would be a specific component type
                //ie: Boid Particle Spring etc
                var behaviour = go.AddComponent<BoidBehavior>();

                agents.Add(boid);
                agentBehaviours.Add(behaviour);
                behaviour.setBoid(boid);
            }
        }

        [ContextMenu("Destroy")]

        public void OnDestroy()
        {
            foreach (var behaviours in agentBehaviours)
                DestroyImmediate(behaviours.gameObject);

            agents.Clear();
            agentBehaviours.Clear();
        }
    }
}