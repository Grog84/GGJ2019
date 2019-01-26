using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class SlotsManager : MonoBehaviour
    {
        public Slot couch;
        public Slot table;
        public Slot furniture_in;
        public Slot furniture_out;
        public Slot hobby_table;

        private void Start()
        {
            couch.SetHighlight(false);
            table.SetHighlight(false);
            furniture_in.SetHighlight(false);
            furniture_out.SetHighlight(false);
            hobby_table.SetHighlight(false);
        }

        public void SetObject(Position position, CharacterItem item)
        {

            switch (position)
            {
                case Position.COUCH:
                    couch.SetSprite(item.sprite);
                    break;
                case Position.TABLE:
                    table.SetSprite(item.sprite);
                    break;
                case Position.FURNITURE_INDOOR:
                    furniture_in.SetSprite(item.sprite);
                    break;
                case Position.HOBBY_TABLE:
                    hobby_table.SetSprite(item.sprite);
                    break;
                case Position.FURNITURE_OUTDOOR:
                    furniture_out.SetSprite(item.sprite);
                    break;
                default:
                    break;
            }
        }

        public void Highlight(Position position, bool status)
        {

            switch (position)
            {          
                case Position.COUCH:
                    couch.SetHighlight(status);
                    break;
                case Position.TABLE:
                    table.SetHighlight(status);
                    break;
                case Position.FURNITURE_INDOOR:
                    furniture_in.SetHighlight(status);
                    break;
                case Position.HOBBY_TABLE:
                    hobby_table.SetHighlight(status);
                    break;
                case Position.FURNITURE_OUTDOOR:
                    furniture_out.SetHighlight(status);
                    break;
                default:
                    break;
            }

        }
    }
}
