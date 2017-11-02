using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

    // Use this for initialization
    void Start() {
        ScriptableObject aabb = ScriptableObject.CreateInstance("AABB");
        //var bob = new AABB();  
        //var mary = new AABB();

        //bob.max = new Vector2(8,10);
        //bob.min = new Vector2(5,3);

        //mary.max = new Vector2(6,9);
        //mary.min = new Vector2(3,2);


        //if (Utilities.TestOverlap(bob, mary))
        //    Debug.Log("Hello World");
    }

}
