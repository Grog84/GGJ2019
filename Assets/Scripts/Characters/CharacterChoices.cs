using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace GGJ19
{
    [Serializable]
    public struct CharacterChoice
    {
        public Position position;
        public CharacterItem item;
    }

    [CreateAssetMenu]
    public class CharacterChoices : ScriptableObject
    {
        public string characterName;
        public CharacterChoice[] items;

        private void Awake()
        {
            items = new CharacterChoice[6];

            int i = 0;
            foreach (Position pos in (Position[])Enum.GetValues(typeof(Position)))
            {
                items[i].position = pos;
                i++;
            }


        }
    }
}
