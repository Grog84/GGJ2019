using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ19 {

    public class UIItemEntry : MonoBehaviour
    {
        public bool isSpecial;

        Image image;
        Image childImage;

        private void Awake()
        {
            image = GetComponent<Image>();
            childImage = GetComponentInChildren<Image>();
        }

        public void SetVisible(bool value)
        {
            if (value)
            {
                image.color = Color.clear;
                childImage.color = Color.clear;
            }
            else
            {
                image.color = Color.white;
                childImage.color = Color.white;
            }
        }

        public void SetSprite(Sprite sprite)
        {
            childImage.sprite = sprite;
            SetVisible(true);
        }
        
    }
}
