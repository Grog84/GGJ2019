using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19 {

    public class ItemsManager : MonoSingleton<ItemsManager>
    {
        public CharacterItem[] allItems;

        Dictionary<Position, List<CharacterItem>> itemDict = new Dictionary<Position, List<CharacterItem>>();

        protected override void Initialise()
        {
            foreach (var item in allItems)
            {
                if (itemDict.ContainsKey(item.position))
                {
                    itemDict[item.position].Add(item);
                }
                else
                {
                    itemDict[item.position] = new List<CharacterItem>();
                    itemDict[item.position].Add(item);
                }

            }
        }

    }

}
