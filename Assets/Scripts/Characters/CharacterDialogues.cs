using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace GGJ19 {

    public enum Emotion { NORMAL, HAPPY, SAD }

    [Serializable]
    public struct Dialogue
    {
        [TextArea]
        public string text;
        public Emotion emotion;
    }

    [CreateAssetMenu]
    public class CharacterDialogues : ScriptableObject
    {
        public Dialogue[] dialogues;
    }

}
