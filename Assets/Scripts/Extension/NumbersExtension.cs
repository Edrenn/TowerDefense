using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extension
{
    public static class NumbersExtension
    {
        public static int AddPercentageCoef(this int currentValue, float percentage)
        {
            if (percentage == 0)
            {
                return currentValue;
            }
            return Mathf.RoundToInt(currentValue * (1 + (percentage / 100)));
        }

        public static float AddPercentageCoef(this float currentValue, float percentage)
        {
            if (percentage == 0)
            {
                return currentValue;
            }
            return currentValue * (1 + (percentage / 100));
        }

        public static float ReduceDecimals(this float currentValue, int remainingDecimals)
        {
            if (remainingDecimals == 1)
            {
                return (float)(Math.Truncate((double)currentValue * 10.0) / 10.0);
            }

            return 0;
        }

    }
}
