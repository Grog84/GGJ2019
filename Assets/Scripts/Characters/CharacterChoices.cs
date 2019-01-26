using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace GGJ19
{
 
    [CreateAssetMenu]
    public class CharacterChoices : ScriptableObject
    {
        public string characterName;
        public CharacterItem[] lovedItems;
        public CharacterItem[] deathItems;
        public Style style;

    }
}
