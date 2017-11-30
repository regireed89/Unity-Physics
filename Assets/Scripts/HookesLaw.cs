﻿using System.Collections;
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
            if(IsGravity == true)            
                AddForce(new Vector3(0,-9.81f,0));
      
                
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
        public SpringDamper(Particle p1, Particle p2, float springConstant,float dampingFactor, float restLength)
        {
            _p1 = p1;
            _p2 = p2;
            Ks = springConstant;
            Kd = dampingFactor;
            Lo = restLength;
        }
    }
}

