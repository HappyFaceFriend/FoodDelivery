using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Vectors
    {
        /// <summary>
        /// Returns a Vector3 (x,y,0)
        /// </summary>
        /// <param name="vector"></param>
        public static Vector3 Vec2ToVec3(Vector2 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }
        /// <summary>
        /// Returns a Vector2 (x,y)
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 Vec3ToVec2(Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
        /// <summary>
        /// Returns sqaured distance between two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float GetSquareDistance(Vector3 a, Vector3 b)
        {
            return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z);
        }

        public static bool IsPositionCrossed(Vector3 targetPos, Vector3 currentPos, Vector3 lastPos)
        {
            Vector3 a = currentPos - targetPos;
            Vector3 b = lastPos - targetPos;

            return a.x * b.x < 0 || a.y * b.y < 0;
        }

    }
}
