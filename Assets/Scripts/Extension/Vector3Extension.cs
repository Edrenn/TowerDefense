using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extension
{
    public static class Vector3Extension
    {
        public static bool PreciseEquals(this Vector3 currentVector, Vector3 vectorToCompare)
        {
            if (Mathf.RoundToInt(currentVector.x) != Mathf.RoundToInt(vectorToCompare.x))
                return false;
            else if (Mathf.RoundToInt(currentVector.y) != Mathf.RoundToInt(vectorToCompare.y))
                return false;
            else if (Mathf.RoundToInt(currentVector.z) != Mathf.RoundToInt(vectorToCompare.z))
                return false;
            else
                return true;
        }

    }
}
