using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowTeeGames
{
    public static class VectorExtentions
    {
        /// <summary>
        /// Returns a random value between X and Y
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static float RandomRange(this Vector2 vector2)
        {
            return Random.Range(vector2.x, vector2.y);
        }

        public static Vector2 ModifyX(this Vector2 vector2, float newX)
        {
            return new Vector2(newX, vector2.y);
        }

        public static Vector2 ModifyY(this Vector2 vector2, float newY)
        {
            return new Vector2(vector2.x, newY);
        }

        /// <summary>
        /// Replaces the Y value with 0
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public static Vector3 Grounded(this Vector3 vector3)
        {
            return new Vector3(vector3.x, 0, vector3.z);
        }

        public static Vector3 ModifyX(this Vector3 vector3, float newX)
        {
            return new Vector3(newX, vector3.y, vector3.z);
        }

        public static Vector3 ModifyY(this Vector3 vector3, float newY)
        {
            return new Vector3(vector3.x, newY, vector3.z);
        }

        public static Vector3 ModifyZ(this Vector3 vector3, float newZ)
        {
            return new Vector3(vector3.x, vector3.y, newZ);
        }
    }
}
