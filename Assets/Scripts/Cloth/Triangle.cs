using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    public class Triangle 
    {

        public float p;
        public float Cd;
        Particle R1;
        Particle R2;
        Particle R3;

        public Triangle() { }
        public Triangle(Particle p1, Particle p2, Particle p3)
        {
            R1 = p1;
            R2 = p2;
            R3 = p3;
        }

        public void AerodynamicForce(Vector3 Force)
        {
            var V1 = R1.velocity;
            var V2 = R2.velocity;
            var V3 = R3.velocity;

            var V = (V1 + V2 + V3) / 3 - Force;
            var Ao = Vector3.Cross((R2.position - R1.position).normalized, (R3.position - R1.position).normalized).magnitude;
            var n = Vector3.Cross((R2.position - R1.position), (R3.position - R1.position)).normalized;
            var a = Ao * (Vector3.Dot(V, n) / V.magnitude);
            Force = -.5f * p * (V.magnitude * V.magnitude) * Cd * a * n;

            R1.AddForce(Force / 3);
            R1.AddForce(Force / 3);
            R1.AddForce(Force / 3);

        }
    }
}


