using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

    // Use this for initialization
    void Start() {
        var bob = new AABB();  
        var mary = new AABB();

        bob.max = new Vector2();
        bob.min = new Vector2();

        mary.max = new Vector2();
        mary.min = new Vector2();

        bob.max.x = 8;
        bob.max.y = 10;
        bob.min.x = 5;
        bob.min.y = 3;

        mary.max.x = 6;
        mary.max.y = 9;
        mary.min.x = 3;
        mary.min.y = 2;

        if (Utilities.TestOverlap(bob, mary))
            Debug.Log("Hello World");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TestCollision()
    {

    }
}
