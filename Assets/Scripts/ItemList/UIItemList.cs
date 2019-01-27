using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GGJ19 {

    public class UIItemList : MonoSingleton<UIItemList>
    {
        public UIItemEntry[] regularItems;
        public UIItemEntry[] specialItems;

        List<CharacterItem> displayedRegularItems = new List<CharacterItem>();
        List<CharacterItem> displayedSpecialItems = new List<CharacterItem>();

        int firstRegularSlotIdx = 0;
        int firstSpecialSlotIdx = 0;

        public TextMeshProUGUI text;

        public Cursor cursor;

        bool itemsVisible;
        Position currentPos;

        private void Start()
        {
            HideItems();
            text.text = "";
        }

        private void Update()
        {
            if (itemsVisible && Input.GetButtonDown("Jump") && !cursor.IsActive)
            {
                cursor.Show();
                cursor.SetActive();

                GameManager.I.INTERACTING = true;
            }
        }

        public void HideItems()
        {
            itemsVisible = false;

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

            displayedRegularItems = new List<CharacterItem>();
            displayedSpecialItems = new List<CharacterItem>();

            text.text = "";

            cursor.Hide();
        }

        public void ShowItemsOfPosition(Position pos)
        {
            itemsVisible = true;
            currentPos = pos;

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

        public RectTransform GetItemPosition(int i)
        {
            if (i >= 0 && i < (displayedRegularItems.Count + displayedSpecialItems.Count))
            {
                if (i < displayedRegularItems.Count)
                {
                    text.text = displayedRegularItems[i].itemName;
                    return regularItems[i].gameObject.GetComponent<RectTransform>();
                }
                else {
                    text.text = displayedSpecialItems[(i - displayedRegularItems.Count)].itemName;
                    return specialItems[(i - displayedRegularItems.Count)].gameObject.GetComponent<RectTransform>();
                }
            }

            return null;
        }

        public void Select(int i)
        {
            GameManager.I.INTERACTING = false;

            CharacterItem selectedItem = null;

            if (i >= 0 && i < (displayedRegularItems.Count + displayedSpecialItems.Count))
            {
                if (i < displayedRegularItems.Count)
                {
                    selectedItem = displayedRegularItems[i];
                }
                else
                {
                    selectedItem = displayedSpecialItems[(i - displayedRegularItems.Count)];
                }
            }


            if (selectedItem.isSpecial)
            {
                var itemInPos = HomeManager.I.GetItemInPosition(currentPos);
                if (itemInPos == null || !itemInPos.isSpecial)
                {
                    ItemsManager.I.AddUsedSpecialItem(selectedItem);
                }
                else
                {
                    ItemsManager.I.RemoveUsedSpecialItem(itemInPos);
                    ItemsManager.I.AddUsedSpecialItem(selectedItem);
                }
            }
            else {
                var itemInPos = HomeManager.I.GetItemInPosition(currentPos);
                if (itemInPos == null || itemInPos.isSpecial)
                {
                    ItemsManager.I.RemoveUsedSpecialItem(itemInPos);
                }
            }

            HomeManager.I.SetItemInPosition(selectedItem, currentPos);

            HideItems();

        }

    }



}
