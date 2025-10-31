using UnityEngine;
using System.Collections.Generic;

namespace Code.CustomerScene
{
    public class RandomChoice : MonoBehaviour
    {
        // Random element selection class for reuse
        public static T From<T>(IList<T> list)
        {
            if (list == null || list.Count == 0) return default;
            return list[Random.Range(0, list.Count)];
        }

        // Pick a random int in [0, count).
        public static int Index(int count)
        {
            return count > 0 ? Random.Range(0, count) : -1; //return -1 if invalid
        }

    }
}