using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    [CreateAssetMenu]
    public class DeathEntry: ScriptableObject
    {
        public string character;
        public string item;
        [TextArea]
        public string text;
    }

    public class DeathManager : MonoSingleton<DeathManager>
    {
        public DeathEntry[] entries;

        public string deathItem = "";


    }

}
