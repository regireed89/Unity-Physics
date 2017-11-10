using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regi
{ 
    public interface IFlockable
    {
        Vector3 Dispersion(Boids b);
        Vector3 Cohesion(Boids b);
        Vector3 Alignment(Boids b);
    }

    public class FlockBehaviour : MonoBehaviour, IFlockable
    {
        public Vector3 Alignment(Boids bj)
        {

            var flock = Neighbors(bj);
            if (flock.Count <= 1)
                return Vector3.zero;
            Vector3 pv = new Vector3();
            foreach (var b in flock)
                if (b != bj)
                    pv = pv + b.velocity;
            pv = pv / (flock.Count - 1);
            return (pv - bj.velocity) / 8;
        }

        public Vector3 Dispersion(Boids bj)
        {
            var flock = Neighbors(bj);
            Vector3 c = Vector3.zero;
            foreach(var b in flock)
            {
                if (b != bj)
                    if ((b.position - bj.position).magnitude < 100)
                        c = c - (b.position - bj.position);
            }
            return c;
        }

        public Vector3 Cohesion(Boids bj)
        {
            var flock = Neighbors(bj);
            var seperation = Vector3.zero;
            foreach (var b in flock)
            {
                if (b != bj)
                    seperation = seperation + b.position;
            }
            seperation = seperation / (flock.Count - 1);

            return (seperation - bj.position) / 100;
        }

        public static List<Boids> Neighbors(Boids boid)
        {
            var neighbors = new List<Boids>();
            var agents = AgentFactory.agents.FindAll(x => Vector3.Distance(x.position, boid.position) < 5);
            agents.ForEach(a => neighbors.Add(a as Boids));
            return neighbors;
        }
    }
}