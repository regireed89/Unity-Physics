using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
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
public class SweepPrune : MonoBehaviour
{

    public List<AABB> AxisList;
    public List<AABB> ActiveList;
    public List<Pair> Reported;

    // Use this for initialization
    void Start()
    {
        AxisList = new List<AABB>();
        ActiveList = new List<AABB>();
        Reported = new List<Pair>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ActiveList.Clear();
        Reported.Clear();
        AxisList = new List<AABB>(FindObjectsOfType<AABB>());
        AxisList.Sort((a, b) => a.min.x.CompareTo(b.min.x));
        ActiveList.Add(AxisList[0]);


        for (int i = 0; i < AxisList.Count - 1; i++)
        {

            var tempList = new List<AABB>();
            if (ActiveList.Count == 0)
                ActiveList.Add(AxisList[i]);
            tempList.AddRange(ActiveList);
            var newItem = AxisList[i + 1];
            //var current = ActiveList[i];
            foreach (var item in ActiveList)
            {
                if (newItem.min.x > item.max.x)
                {
                    tempList.Remove(item);
                }
                else
                {
                    tempList.Add(newItem);
                    Reported.Add(new Pair(item, newItem));
                }
            }
            ActiveList.Clear();
            ActiveList.AddRange(tempList);
        }

        for (int i = 0; i < AxisList.Count - 1; i++)
        {

            var tempList = new List<AABB>();
            if (ActiveList.Count == 0)
                ActiveList.Add(AxisList[i]);
            tempList.AddRange(ActiveList);
            var newItem = AxisList[i + 1];
            //var current = ActiveList[i];
            foreach (var item in ActiveList)
            {
                if (newItem.min.y > item.max.y)
                {
                    tempList.Remove(item);
                }
                else
                {
                    tempList.Add(newItem);
                    Reported.Add(new Pair(item, newItem));
                }
            }
            ActiveList.Clear();
            ActiveList.AddRange(tempList);
        }
    }
}
