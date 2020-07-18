using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework.Util
{
    public static class ExtensionVector3
    {
        public static void SetXY(ref this Vector3 vec3, Vector2 xy)
        {
            vec3.x = xy.x;
            vec3.y = xy.y;
        }
        public static Vector2 GetXY(this Vector3 vec3)
        {
            return new Vector2(vec3.x, vec3.y);
        }
        public static void SetYX(ref this Vector3 vec3, Vector2 yx)
        {
            vec3.x = yx.y;
            vec3.y = yx.x;
        }
        public static Vector2 GetYX(this Vector3 vec3)
        {
            return new Vector2(vec3.y, vec3.x);
        }
        public static void SetXZ(ref this Vector3 vec3, Vector2 xz)
        {
            vec3.x = xz.x;
            vec3.z = xz.y;
        }
        public static Vector2 GetXZ(this Vector3 vec3)
        {
            return new Vector2(vec3.x, vec3.z);
        }
        public static void SetZX(ref this Vector3 vec3, Vector2 zx)
        {
            vec3.x = zx.y;
            vec3.z = zx.x;
        }
        public static Vector2 GetZX(this Vector3 vec3)
        {
            return new Vector2(vec3.z, vec3.x);
        }
        public static void SetYZ(ref this Vector3 vec3, Vector2 yz)
        {
            vec3.y = yz.x;
            vec3.z = yz.y;
        }
        public static Vector2 GetYZ(this Vector3 vec3)
        {
            return new Vector2(vec3.y, vec3.z);
        }
        public static void SetZY(ref this Vector3 vec3, Vector2 zy)
        {
            vec3.y = zy.y;
            vec3.z = zy.x;
        }
        public static Vector2 GetZY(this Vector3 vec3)
        {
            return new Vector2(vec3.z, vec3.x);
        }
    }
}
