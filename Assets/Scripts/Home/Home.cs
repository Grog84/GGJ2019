using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace GGJ19 {

    public class Home : MonoBehaviour
    {
        SlotsManager slots;

        public Character character;

        Dictionary<Position, CharacterItem> composition = new Dictionary<Position, CharacterItem>();

        public WorkSign sign;

        private void Awake()
        {
            slots = GetComponentInChildren<SlotsManager>();


            foreach (Position pos in (Position[])Enum.GetValues(typeof(Position)))
            {
                composition[pos] = null;
            }

        }

        private void Start()
        {
            if (GameManager.I.PHASE == GamePhase.BUILD)
            {
                sign.gameObject.SetActive(false);
            }
            else
            {
                sign.gameObject.SetActive(true);
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

        public int EvaluateComposition()
        {
            var choices = character.choices;
            int score = 0;

            foreach (Position pos in (Position[])Enum.GetValues(typeof(Position)))
            {
                if (composition[pos].style == choices.style && !composition[pos].isSpecial)
                {
                    score += 10;
                } else if (composition[pos].isSpecial)
                {
                    if (choices.lovedItems.Contains(composition[pos]))
                    {
                        score += 25;
                    }
                    else if (choices.lovedItems.Contains(composition[pos]))
                    {
                        score -= 500;
                    }
                }
            }

            return score;

        }


    }
}
