using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AABB", menuName = "AABB")]
public class AABB : ScriptableObject {

    public Vector2 min;
    public Vector2 max;
}
