using System;
using UnityEngine;

namespace GGJ19
{
    public static class EventExtensions
    {
        public static void Trigger(this Action action)
        {
            if (action != null) action();
        }

        public static void Trigger<T>(this Action<T> action, T v)
        {
            if (action != null) action(v);
        }

        public static void Trigger<T1, T2>(this Action<T1, T2> action, T1 v1, T2 v2)
        {
            if (action != null) action(v1, v2);
        }

        public static void Trigger<T1, T2, T3>(this Action<T1, T2, T3> action, T1 v1, T2 v2, T3 v3)
        {
            if (action != null) action(v1, v2, v3);
        }

        public static void Trigger<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 v1, T2 v2, T3 v3, T4 v4)
        {
            if (action != null) action(v1, v2, v3, v4);
        }

        public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
        public static void Trigger<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 v1, T2 v2, T3 v3, T4 v4, T5 v5)
        {
            if (action != null) action(v1, v2, v3, v4, v5);
        }
    }
}