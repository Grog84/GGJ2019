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

        private void Start()
        {
            couch.gameObject.transform.Find("Highlight").gameObject.SetActive(false);
            table.gameObject.transform.Find("Highlight").gameObject.SetActive(false);
            furniture_in.gameObject.transform.Find("Highlight").gameObject.SetActive(false);
            furniture_out.gameObject.transform.Find("Highlight").gameObject.SetActive(false);
            hobby_table.gameObject.transform.Find("Highlight").gameObject.SetActive(false);
        }

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

        public void Highlight(Position position, bool status)
        {
            GameObject parent = null;

            switch (position)
            {          
                case Position.COUCH:
                    parent = couch.gameObject;
                    break;
                case Position.TABLE:
                    parent = table.gameObject;
                    break;
                case Position.FURNITURE_INDOOR:
                    parent = furniture_in.gameObject;
                    break;
                case Position.HOBBY_TABLE:
                    parent = hobby_table.gameObject;
                    break;
                case Position.FURNITURE_OUTDOOR:
                    parent = furniture_out.gameObject;
                    break;
                default:
                    break;
            }

            var tr = couch.transform.Find("Highlight");
            tr.gameObject.SetActive(status);
        }
    }
}
