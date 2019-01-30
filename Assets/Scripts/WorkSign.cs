using System.Collections;
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
            if (GameManager.I.PHASE != GamePhase.DEATH)
            {
                if (GameManager.I.PHASE == GamePhase.EXPLORE && !mHome.IsComplete())
                {
                    HomeManager.I.ACTIVE_HOME = mHome;

                    SfxManager.I.Play("sfx_passaggio_build");
                    GameManager.I.GoToBuild();
                }
                else
                {
                    if (HomeManager.I.IsComplete())
                    {
                        SfxManager.I.Play("sfx_ritorno_gioco");
                        GameManager.I.GoToExplore();
                        interactImage.DOFade(0, 0.5f);
                    }
                }
            }
        }

        public void ShowInteraction(bool status)
        {
            if (!mHome.IsComplete() || (mHome.IsComplete() && GameManager.I.PHASE == GamePhase.BUILD))
            {
                float targetAlpha = status ? 1f : 0f;
                interactImage.DOFade(targetAlpha, 0.5f);
            }
            
        }
    }

}
