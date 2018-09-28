using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities  {

    public static bool AlmostZero(this Vector2 vec)
    {
        Vector2 vector = vec.AbsouluteValues();
        if (vector.x >= 0.05f || vector.y >= 0.05f) {
            return false;
        }
        else return true;
    }

    public static Vector2 AbsouluteValues(this Vector2 vec)
    {
        return new Vector2(Mathf.Abs(vec.x), Mathf.Abs(vec.y));
    }
}
