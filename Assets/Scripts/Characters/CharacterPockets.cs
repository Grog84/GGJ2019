using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GGJ19
{
    public class CharacterPockets : MonoBehaviour
    {
        public Image oneItem;
        public Image twoItems;

        float showPos = 300f;

        bool open = false;

        private void Start()
        {
            Hide();
        }

        private void Update()
        {
            if (open)
            {
                if (GameManager.I.INTERACTING != true)
                {
                    Hide();
                }
            }
        }

        public void Show(Sprite[] sprites)
        {
            open = true;
            if (sprites.Length == 1)
            {
                oneItem.GetComponentsInChildren<Image>()[1].sprite = sprites[0];
                twoItems.gameObject.SetActive(false);

                oneItem.rectTransform.DOAnchorPosX(showPos, 2);
               
            }
            else if (sprites.Length == 2)
            {
                twoItems.gameObject.SetActive(true);
                oneItem.GetComponentsInChildren<Image>()[1].sprite = sprites[0];
                twoItems.GetComponentsInChildren<Image>()[1].sprite = sprites[1];

                oneItem.rectTransform.DOAnchorPosX(showPos, 2);
                twoItems.rectTransform.DOAnchorPosX(showPos, 2);
            }
        }

        public void Hide()
        {
            open = false;
            oneItem.rectTransform.DOAnchorPosX(0, 2);
            twoItems.rectTransform.DOAnchorPosX(0, 2);
        }
    }
}
