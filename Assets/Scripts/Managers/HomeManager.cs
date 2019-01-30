using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{

    public class HomeManager : MonoSingleton<HomeManager>
    {
        Home activeHome;
        public Home ACTIVE_HOME {
            get { return activeHome; }
            set { activeHome = value; }
        }


        public Dictionary<string, Dictionary<Position, CharacterItem>> homeCompositions = new Dictionary<string, Dictionary<Position, CharacterItem>>();


        public void SetItemInPosition(CharacterItem item, Position pos)
        {
            activeHome.SetItem(item, pos);
        
        }

        public CharacterItem GetItemInPosition(Position pos)
        {
            return activeHome.GetItem(pos);

        }

        public bool IsComplete()
        {
            return activeHome.IsComplete();

        }

        public int GetScore()
        {
            return activeHome.EvaluateComposition();
        }

        /*
        public void RebuildFinishedHouses()
        {
            StartCoroutine(RebuildFinishedHousesCO());
        }

        public IEnumerator RebuildFinishedHousesCO()
        {
            yield return null;

            var allHomes = FindObjectsOfType<Home>();

            foreach (KeyValuePair<string, Dictionary<Position, CharacterItem>> entry in homeCompositions)
            {
                // do something with entry.Value or entry.Key
                foreach (var item in allHomes)
                {
                    if (entry.Key == item.character.m_name)
                    {
                        item.BuildFromComposition(entry.Value);
                        item.MoveCharacterIn();
                    }
                }
            }
        }*/




    }

}
