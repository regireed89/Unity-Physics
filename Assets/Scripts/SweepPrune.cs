using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pair
{
    public Pair() { }
    public Pair(AABB obj1, AABB obj2)
    {

    }
}
public class SweepPrune : MonoBehaviour {

    List<AABB> AxisList;
	// Use this for initialization
	void Start () {
        AxisList.Sort();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
