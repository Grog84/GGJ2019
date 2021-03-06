﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19 {

    public class Slot : MonoBehaviour
    {
        public Position position;

        GameObject highlight;
        SpriteRenderer m_renderer;

        private void Awake()
        {
            m_renderer = GetComponent<SpriteRenderer>();
            highlight = transform.Find("Highlight").gameObject;
        }

        public void SetHighlight(bool val)
        {
            highlight.SetActive(val);
        }

        public void SetSprite(Sprite sprite)
        {
            if (m_renderer == null)
            {
                m_renderer = GetComponent<SpriteRenderer>();
            }
            m_renderer.sprite = sprite;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.collider.gameObject.tag == "Player" && GameManager.I.PHASE == GamePhase.BUILD)
            {
                SetHighlight(true);
                UIItemList.I.ShowItemsOfPosition(position);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {

            if (collision.collider.gameObject.tag == "Player" && GameManager.I.PHASE == GamePhase.BUILD)
            {
                SetHighlight(false);
                UIItemList.I.HideItems();
            }
        }
    }

}

