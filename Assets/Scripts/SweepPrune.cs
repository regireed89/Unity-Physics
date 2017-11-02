using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pair
{
    public AABB objOne;
    public AABB objTwo;
    public Pair() { }
    public Pair(AABB obj1, AABB obj2)
    {
        objOne = obj1;
        objTwo = obj2;
    }
}
public class SweepPrune : MonoBehaviour {

    public List<AABB> AxisList;
    public List<AABB> ActiveList;
    public List<Pair> Reported;
	// Use this for initialization
	void Start () {
        AxisList = new List<AABB>();
        ActiveList = new List<AABB>();
        Reported = new List<Pair>();
        AxisList.Add(FindObjectOfType<AABB>());
        AxisList.Sort((a, b) => a.min.x.CompareTo(b.min.x));
        ActiveList.Add(AxisList[0]);
    }
	
	// Update is called once per frame
	void Update () {

        
        for (int i = 0; i < AxisList.Count - 1; i++)
        {
            var current = ActiveList[i];
            var newItem = AxisList[i+1];     
            if(newItem.min.x > current.min.x)
            {
                ActiveList.Remove(current);
            }
            else
            {
                ActiveList.Add(newItem);
                Reported.Add(new Pair(current, newItem));
            }
        }
        Debug.Log(Reported.Count);
	}



}
