using System;
using UnityEngine;

namespace GGJ19
{
    public static class MonoBehaviourExtensions
    {
        public static T DuplicateInstance<T>(this T prefab) where T : Component
        {
            var go = GameObject.Instantiate(prefab.gameObject, prefab.transform.parent, false);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            return go.GetComponent<T>();
        }

    }
}