using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AABB")]
public class AABB : ScriptableObject {

    public Vector2 min;
    public Vector2 max;
    public Transform Owner;
    public float Width, Height;
    public string Name;

    public void Initialize(float width, float height, Transform owner)
    {
        min = new Vector2(0, 0);
        max = new Vector2(0, 0);
        Width = width;
        Height = height;
        Owner = owner;
        Name = owner.name;
        UpdateAabb();
    }

    public void UpdateAabb()
    {
        min.x = Owner.position.x;
        max.x = min.x + Width;

        min.y = Owner.position.y;
        max.y = min.y + Height;
        Draw();
    }

    public void UpdateAabb(float width, float height)
    {
        Width = width;
        Height = height;
        UpdateAabb();
    }

    public void Draw()
    {
        var bl = new Vector3(min.x, min.y);
        var br = new Vector3(max.x, min.y);
        var tr = new Vector3(max.x, max.y);
        var tl = new Vector3(min.x, max.y);
        
        Debug.DrawLine(bl, br, Color.cyan);
        Debug.DrawLine(bl, tl, Color.cyan);
        Debug.DrawLine(br, tr, Color.cyan);
        Debug.DrawLine(tl, tr, Color.cyan);
    }

}
