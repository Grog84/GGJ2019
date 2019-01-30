using UnityEngine;
using System;

namespace GGJ19
{
    [Serializable]
    public struct Dialogue
    {
        [TextArea]
        public string text;
        public Emotion emotion;
    }

}
