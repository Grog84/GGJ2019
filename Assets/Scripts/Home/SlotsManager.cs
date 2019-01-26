using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class SlotsManager : MonoBehaviour
    {
        public SpriteRenderer couch;
        public SpriteRenderer table;
        public SpriteRenderer furniture_in;
        public SpriteRenderer furniture_out;
        public SpriteRenderer hobby_table;

        public void SetObject(Position position, CharacterItem item)
        {

            if (position != item.position)
            {
                Debug.LogError("ERROR: position and item position not matching");
            }

            switch (position)
            {
                case Position.COUCH:
                    couch.sprite = item.sprite;
                    break;
                case Position.TABLE:
                    table.sprite = item.sprite;
                    break;
                case Position.FURNITURE_INDOOR:
                    furniture_in.sprite = item.sprite;
                    break;
                case Position.HOBBY_TABLE:
                    hobby_table.sprite = item.sprite;
                    break;
                case Position.FURNITURE_OUTDOOR:
                    furniture_out.sprite = item.sprite;
                    break;
                default:
                    break;
            }
        }
    }
}
