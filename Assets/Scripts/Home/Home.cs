using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GGJ19 {

    public class Home : MonoBehaviour
    {
        SlotsManager slots;

        public Transform character;

        Dictionary<Position, CharacterItem> composition = new Dictionary<Position, CharacterItem>();

        private void Awake()
        {
            slots = GetComponentInChildren<SlotsManager>();


            foreach (Position pos in (Position[])Enum.GetValues(typeof(Position)))
            {
                composition[pos] = null;
            }


        }

        public void MoveCharacterIn()
        {
            character.transform.position = transform.position;
        }

        public void SetItem(CharacterItem item, Position position)
        {
            slots.SetObject(position, item);
            composition[position] = item;
        }

        public CharacterItem GetItem(Position position)
        {
            return composition[position];
        }


    }
}
