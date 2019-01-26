using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ19 {

    public enum Emotion { SAD, HAPPY, ANGRY, NORMAL }

    [CreateAssetMenu]
    public class CharacterDialogue : ScriptableObject
    {
        [TextArea]
        public string text;
        public Emotion emotion;
    }

}
