using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AustenKinney.Essentials
{
    public class EasingFunctions
    {
        public static float Elastic(float k)
        {
            if (k == 0) return 0;
            if (k == 1) return 1;
            return Mathf.Pow(2f, -10f * k) * Mathf.Sin((k - 0.1f) * (2f * Mathf.PI) / 0.4f) + 1f;
        }
    }
}
