using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GGJ19
{

    [CreateAssetMenu]
    public class CharacterItem: ScriptableObject
    {
        public string itemName;
        public Sprite sprite;
        public bool isSpecial;
        public Style style;
        public Position[] position;

    }
}