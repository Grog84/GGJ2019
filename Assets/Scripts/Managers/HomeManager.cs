using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{

    public class HomeManager : MonoSingleton<HomeManager>
    {
        public Home activeHome;
        public static Home buildingHome;
        public static string buildingHomeName;

        public Dictionary<string, Dictionary<Position, CharacterItem>> homeCompositions = new Dictionary<string, Dictionary<Position, CharacterItem>>();

        public void SetActiveHome(Home home)
        {
            activeHome = home;
        }

        public void SetBuildingHome(Home home)
        {     
            buildingHome = home.GetClone();
            buildingHomeName = buildingHome.character.name;
        }

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

        public void AddComposition(Dictionary<Position, CharacterItem> composition)
        {
            homeCompositions[buildingHomeName] = composition;

        }

        public void AddComposition()
        {
            homeCompositions[buildingHomeName] = activeHome.GetComposition();

        }

        public int GetScore()
        {
            activeHome.character = buildingHome.character;
            return activeHome.EvaluateComposition();
        }

        public void RebuildFinishedHouses()
        {
            var allHomes = FindObjectsOfType<Home>();

            foreach (KeyValuePair<string, Dictionary<Position, CharacterItem>> entry in homeCompositions)
            {
                // do something with entry.Value or entry.Key
                foreach (var item in allHomes)
                {
                    if (entry.Key == item.character.name)
                    {
                        item.BuildFromComposition(entry.Value);
                        item.MoveCharacterIn();
                    }


                }

            }


        }




    }

}
