using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowTeeGames
{
    public static class MathExtentions
    {
        /// <summary>
        /// Returns value mapped from one range into another (e.g. 0.5 normalized from the range 0 -> 1 to 0 -> 50 would return 25)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inRangeA"></param>
        /// <param name="inRangeB"></param>
        /// <param name="outRangeA"></param>
        /// <param name="outRangeB"></param>
        /// <param name="clamp">whether to clamp the value within the range</param>
        /// <returns></returns>
        public static float MapRange(float value, float inRangeA, float inRangeB, float outRangeA, float outRangeB, bool clamp = true)
        {
            if (clamp)
            {
                value = Mathf.Clamp(value, inRangeA, inRangeB);
            }

            float rangeOne = (value - inRangeA) / (inRangeB - inRangeA);
            float rangeTwo = (outRangeB - outRangeA) * rangeOne + outRangeA;

            return rangeTwo;
        }
    }
}
