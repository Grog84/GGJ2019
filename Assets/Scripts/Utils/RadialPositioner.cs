using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public static class RadialPositioner
    {
        // d - radial distance; a - angle
        public static Vector3 GetPosition(float angle, float radius, bool isDeg=true)
        {
            if (isDeg)
                angle *= Mathf.Deg2Rad;

            return new Vector3(radius * Mathf.Sin(angle), 0f, radius * Mathf.Cos(angle));
        }

        public static float GetAngle(Vector3 pos, bool retRad=false)
        {
            float angle = Vector3.Angle(Vector3.forward, pos);

            if (retRad)
                angle *= Mathf.Deg2Rad;

            return angle;
        }
    }
}
