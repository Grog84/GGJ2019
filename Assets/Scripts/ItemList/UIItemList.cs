using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19 {

    public class UIItemList : MonoSingleton<UIItemList>
    {
        public UIItemEntry[] regularItems;
        public UIItemEntry[] specialItems;

        List<CharacterItem> displayedRegularItems;
        List<CharacterItem> displayedSpecialItems;

        int firstRegularSlotIdx = 0;
        int firstSpecialSlotIdx = 0;

        public void HideItems()
        {
            foreach (var item in regularItems)
            {
                item.SetVisible(false);
            }

            foreach (var item in specialItems)
            {
                item.SetVisible(false);
            }

            firstRegularSlotIdx = 0;
            firstSpecialSlotIdx = 0;
        }

        public void ShowItemsOfPosition(Position pos)
        {
            var displayedItems = ItemsManager.I.GetItemsOfPosition(pos);

            foreach (var item in displayedItems)
            {
                if (item.isSpecial)
                {
                    AddSpecialItem(item);
                }
                else
                {
                    AddRegularItem(item);
                }
            }

        }

        void AddRegularItem(CharacterItem item)
        {
            regularItems[firstRegularSlotIdx].SetSprite(item.sprite);
            displayedRegularItems.Add(item);
            firstRegularSlotIdx++;
        }

        void AddSpecialItem(CharacterItem item)
        {
            if (ItemsManager.I.IsSpecialAvailable(item))
            {
                specialItems[firstSpecialSlotIdx].SetSprite(item.sprite);
                displayedSpecialItems.Add(item);
                firstSpecialSlotIdx++;
            }

        }

    }



}
