using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HookesLaw
{
    [System.Serializable]
    public class Particle
    {
        public Particle()
        {
            force = Vector3.zero;
            mass = 1;
            acceleration = Vector3.zero;
            velocity = Vector3.zero;
            position = Vector3.zero;
        }
        public Particle(Vector3 p, Vector3 v, float m)
        {
            position = p;
            velocity = v;
            mass = m;
        }

        [SerializeField]
        public Vector3 position;
        [SerializeField]
        public Vector3 velocity;
        [SerializeField]
        public Vector3 acceleration;
        [SerializeField]
        public float mass;
        [SerializeField]
        public Vector3 force;
        [SerializeField]
        public bool IsGravity;
        [SerializeField]
        public bool IsAnchor;

        public void AddForce(Vector3 f)
        {
            force += f;
        }

        public Vector3 Update(float deltatime)
        {
            if (IsGravity)
                AddForce(new Vector3(0, -9.81f, 0));
            if (IsAnchor)
                return position;


            acceleration = force / mass;
            velocity += acceleration * deltatime;
            position += velocity * deltatime;
            force = Vector3.zero;
            return position;
        }
    }
    [System.Serializable]
    public class SpringDamper
    {
        [SerializeField]
        public Particle _p1, _p2;
        [SerializeField]
        public float Ks;//spring constant
        [SerializeField]
        public float Kd;
        [SerializeField]
        public float Lo;//rest length


        public SpringDamper() { }
        public SpringDamper(Particle p1, Particle p2, float springConstant, float dampingFactor, float restLength)
        {
            _p1 = p1;
            _p2 = p2;
            Ks = springConstant;
            Kd = dampingFactor;
            Lo = restLength;
        }
        public void ComputeForce(float ks, float kd, float lo)
        {
            Ks = ks;
            Kd = kd;
            Lo = lo;
            var e = this._p2.position - this._p1.position;
            var length = e.magnitude;
            var _e = e / length;

            var V1 = this._p1.velocity;
            var V2 = this._p2.velocity;
            var v1 = Vector3.Dot(_e, V1);
            var v2 = Vector3.Dot(_e, V2);

            var f = -Ks * (Lo - length) - Kd * (v1 - v2);
            var f1 = f * _e;
            var f2 = -f1;
            this._p1.AddForce(f1);
            this._p2.AddForce(f2);
            Debug.DrawLine(_p1.position, _p2.position);

        }
    }
}

