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

        public WorkSign startSign;
        public WorkSign stopSign;

        bool complete = false;

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
                startSign.gameObject.SetActive(false);
                stopSign.gameObject.SetActive(true);
            }
            else if (!complete)
            {
                startSign.gameObject.SetActive(true);
                stopSign.gameObject.SetActive(false);
            }
            else
            {
                startSign.gameObject.SetActive(false);
                stopSign.gameObject.SetActive(false);
            }
        }

        public void MoveCharacterIn()
        {
            character.transform.position = transform.position;
        }

        public void SetItem(CharacterItem item, Position position)
        {
            if (slots == null)
            {
                slots = GetComponentInChildren<SlotsManager>();
            }
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
                    else if (choices.deathItems.Contains(composition[pos]))
                    {
                        DeathManager.I.deathItem = composition[pos];
                        score -= 500;
                    }
                }
            }

            return score;

        }

        public Dictionary<Position, CharacterItem> GetComposition()
        {
            return composition;
        }

        public bool IsComplete()
        {
            foreach (Position pos in (Position[])Enum.GetValues(typeof(Position)))
            {
                if (composition[pos] == null)
                {
                    return false;
                }
            }

            return true;
        }

        public void BuildFromComposition(Dictionary<Position, CharacterItem> composition)
        {
            this.composition = composition;
            foreach (Position pos in (Position[])Enum.GetValues(typeof(Position)))
            {
                SetItem(this.composition[pos], pos);
            }
            complete = true;
            startSign.gameObject.SetActive(false);
        }

        public Home GetClone()
        {
            return (Home)this.MemberwiseClone();
        }


    }
}
