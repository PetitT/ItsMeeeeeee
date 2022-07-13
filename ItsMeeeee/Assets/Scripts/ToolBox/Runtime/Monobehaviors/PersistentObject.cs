using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowTeeGames
{
    public class PersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
