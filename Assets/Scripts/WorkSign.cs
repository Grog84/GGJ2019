﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GGJ19 {

    public class WorkSign : MonoBehaviour
    {
        public Home mHome;
        public SpriteRenderer interactImage;

        public void Interact()
        {
            if (GameManager.I.PHASE == GamePhase.EXPLORE)
            {
                HomeManager.I.SetBuildingHome(mHome);

                SfxManager.I.Play("sfx_passaggio_build");
                GameManager.I.GoToBuild();
            }
            else
            {
                if (HomeManager.I.IsComplete())
                {
                    FixCanvas.I.gameObject.SetActive(false);
                    SfxManager.I.Play("sfx_ritorno_gioco");
                    GameManager.I.GoToExplore();
                }
            }
        }

        public void ShowInteraction(bool status)
        {
            float targetAlpha = status ? 1f : 0f;
            interactImage.DOFade(targetAlpha, 0.5f);
        }
    }

}
