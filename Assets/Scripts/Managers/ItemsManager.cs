using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19 {

    public class ItemsManager : MonoSingleton<ItemsManager>
    {

        Dictionary<Position, List<CharacterItem>> itemDict = new Dictionary<Position, List<CharacterItem>>();
        List<CharacterItem> usedSpecialItems = new List<CharacterItem>();

        protected override void Initialise()
        {

            var regItem = ScriptableObjectsLoader.GetAllInstances<CharacterItem>("Regular");

            var specItem = ScriptableObjectsLoader.GetAllInstances<CharacterItem>("Special");

            foreach (var item in regItem)
            {
                foreach (var pos in item.position)
                {
                    if (itemDict.ContainsKey(pos))
                    {
                        itemDict[pos].Add(item);
                    }
                    else
                    {
                        itemDict[pos] = new List<CharacterItem>();
                        itemDict[pos].Add(item);
                    }
                }
            }

            foreach (var item in specItem)
            {
                foreach (var pos in item.position)
                {
                    if (itemDict.ContainsKey(pos))
                    {
                        itemDict[pos].Add(item);
                    }
                    else
                    {
                        itemDict[pos] = new List<CharacterItem>();
                        itemDict[pos].Add(item);
                    }
                }
            }

            
        }

        public List<CharacterItem> GetItemsOfPosition(Position pos)
        {
            return itemDict[pos];
        }

        public bool IsSpecialAvailable(CharacterItem item)
        {
            if (usedSpecialItems.Contains(item))
            {
                return false;
            }
            else
            {
                usedSpecialItems.Add(item);
                return true;
            }
        }



    }

}
