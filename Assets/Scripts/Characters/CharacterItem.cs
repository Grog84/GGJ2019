using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GGJ19
{
    public enum Style { MODERN, COUNTRY, CLASSIC, POP }
    public enum Position { COUCH, WINDOW, FURNITURE, FLOOR, HOBBY_INDOOR, HOBBY_OUTDOOR }

    [CreateAssetMenu]
    public class CharacterItem: ScriptableObject
    {
        public Sprite sprite;
        public bool isSpecial;
        public Style style;
        public Position position;

    }
}