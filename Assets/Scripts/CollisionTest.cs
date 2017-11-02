using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {
    public AABB aabb;
    public UnityEngine.Vector2 size;
    // Use this for initialization
    void Start() {
        aabb = ScriptableObject.CreateInstance<AABB>();
        aabb.Initialize(size.x, size.y, transform);
    }

    private void Update()
    {
        aabb.UpdateAabb(size.x, size.y);
        
    }

}
