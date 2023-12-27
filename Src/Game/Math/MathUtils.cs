using System;
using UnityEngine;

namespace LD.Codebase.Src.Game.Math
{
    public static class MathUtils
    {
        public static float GetDistance(GameObject p1, GameObject p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException();
            return Vector3.Distance(p1.transform.position, p2.transform.position);
        }
        
    }
}