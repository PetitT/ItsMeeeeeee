using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowTeeGames
{
    public class HelperFunctions : MonoBehaviour
    {
        public static bool GetRandomBool()
        {
            int random = Random.Range(0, 2);
            if (random <= 0.5f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
