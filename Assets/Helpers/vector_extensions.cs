using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class vector_extensions {
    //public static Vector3 plane { get(this Vector2 vector) { return new Vector3(vector.x, 0.0f, vector.y); } }
    
    public static Vector2 xy(this Vector3 vector) => new Vector2(vector.x, vector.y);
    public static Vector2 yx(this Vector3 vector) => new Vector2(vector.y, vector.x);

    public static Vector2 xz(this Vector3 vector) => new Vector2(vector.x, vector.z);
    public static Vector2 zx(this Vector3 vector) => new Vector2(vector.z, vector.x);

    public static Vector2 yz(this Vector3 vector) => new Vector2(vector.y, vector.z);
    public static Vector2 zy(this Vector3 vector) => new Vector2(vector.z, vector.y);

    public static Vector3 plane(this Vector2 vector) => new Vector3(vector.x, 0.0f, vector.y);
}
