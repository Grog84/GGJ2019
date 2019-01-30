using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using DG.Tweening;

namespace GGJ19 {

    public class Home : MonoBehaviour
    {
        SlotsManager slots;

        public Character character;

        Dictionary<Position, CharacterItem> composition = new Dictionary<Position, CharacterItem>();

        public GameObject mVirtualCamera;

        bool complete = false;
        int score = 0;

        public GameObject navigation;


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
            StartCoroutine(MoveCharacterInCO());
        }

        public IEnumerator MoveCharacterInCO()
        {
            character.transform.DOMove(navigation.transform.Find("Stairs").position, 2f);
            yield return new WaitForSeconds(2f);
            character.transform.DOMove(navigation.transform.Find("Door").position, 1f);
            yield return new WaitForSeconds(1f);
            character.transform.DOMove(transform.position, 1f);
            yield return new WaitForSeconds(1f);

            if (score < 0)
            {
                character.SetEmotion(Emotion.SAD);
            }
            else if (score > 0 && score <= 50)
            {
                character.SetEmotion(Emotion.NORMAL);
            }
            else
            {
                character.SetEmotion(Emotion.HAPPY);
            }
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
            score = 0;

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

        }

        public Home GetClone()
        {
            return (Home)this.MemberwiseClone();
        }

        public void SetCameraActive(bool status)
        {
            mVirtualCamera.SetActive(status);
        }


    }
}
