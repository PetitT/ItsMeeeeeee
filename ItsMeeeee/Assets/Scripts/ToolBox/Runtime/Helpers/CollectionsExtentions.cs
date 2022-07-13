using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowTeeGames
{
    public static class CollectionsExtentions
    {
        public static T GetRandom<T>(this List<T> list)
        {
            if (list.Count == 0) return default;

            int random = Random.Range(0, list.Count);
            T item = list[random];
            return item;
        }

        public static T GetRandom<T>(this T[] arr)
        {
            if (arr.Length == 0) return default;

            int random = Random.Range(0, arr.Length);
            T item = arr[random];
            return item;
        }

        public static T GetRandom<T, U>(this Dictionary<T, U> dictionnary)
        {
            if (dictionnary.Count == 0) return default;

            List<T> tempList = new List<T>();

            foreach (var key in dictionnary.Keys)
            {
                tempList.Add(key);
            }

            int random = Random.Range(0, tempList.Count);
            T item = tempList[random];
            return item;
        }

        public static T GetRandom<T>(this IList<T> list)
        {
            if (list.Count == 0) return default;

            int random = Random.Range(0, list.Count);
            T item = list[random];
            return item;
        }
    }
}
