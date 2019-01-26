using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19 {

    public class UIItemEntry : MonoBehaviour
    {
        public bool isSpecial;

        SpriteRenderer m_renderer;

        public void SetVisible(bool value)
        {
            if (value)
            {
                m_renderer.color = Color.clear;
            }
            else
            {
                m_renderer.color = Color.white;
            }
        }

        public void SetSprite(Sprite sprite)
        {
            m_renderer.sprite = sprite;
            SetVisible(true);
        }
        
    }
}
