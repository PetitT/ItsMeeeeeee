using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace LowTeeGames
{
    public static class EnumExtentions
    {
        public static T GetRandomEnum<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            Random random = new Random();
            T randomValue = (T)values.GetValue(random.Next(values.Length));
            return randomValue;
        }
    }
}
