using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AustenKinney.Essentials
{
    public class IndexConverter
    {
        public static int ConvertToPhysicalIndex(int v)
        {
            int p = Mathf.Abs(v * 2) - (v > 0 ? 1 : 0);
            return p;
        }

        public static int ConvertToVirtualIndex(int p)
        {
            int v = (p % 2 == 1 ? +1 : -1) * ((2 * p + 3) / 4);
            return v;
        }
    }
}
