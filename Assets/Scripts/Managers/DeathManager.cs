using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    [SerializeField]
    public struct DeathEntry
    {
        string character;
        string item;
        [TextArea]
        string text;
    }

    public class DeathManager : MonoBehaviour
    {
        public DeathEntry[] entries;




    }

}
