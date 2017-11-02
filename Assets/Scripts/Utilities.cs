using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2
{
    public float x;
    public float y;
    public Vector2() { }
    public Vector2(float xAxis, float yAxis)
    {
        x = xAxis;
        y = yAxis;
    }
}

public static class Utilities
{
    public static bool TestOverlap(AABB a, AABB b)
    {
        if (a.max.x < b.max.x && a.max.x > b.min.x || a.min.x > b.min.x && a.min.x < b.max.x)
        { return true; }
        if (a.max.y < b.max.y && a.max.y > b.min.y || a.min.y > b.min.y && a.min.y < b.max.y)
        { return true; }
        return false;
    }
}

