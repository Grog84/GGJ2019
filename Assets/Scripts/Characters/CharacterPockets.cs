using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class CharacterPockets : MonoBehaviour
    {
        public GameObject oneItem;
        public GameObject twoItems;

        private void Start()
        {
            Hide();
        }

        public void Show(Sprite[] sprites)
        {
            if (sprites.Length == 1)
            {
                oneItem.SetActive(true);
                var sprite = oneItem.GetComponentInChildren<SpriteRenderer>();
                sprite.sprite = sprites[0];
            }
            else if (sprites.Length == 2)
            {
                twoItems.SetActive(true);
                int i = 0;
                foreach (Transform tr in twoItems.transform)
                {
                    var sprite = tr.GetComponent<SpriteRenderer>();
                    sprite.sprite = sprites[i];
                    i++;
                }
            }
        }

        public void Hide()
        {
            oneItem.SetActive(false);
            twoItems.SetActive(false);
        }
    }
}
