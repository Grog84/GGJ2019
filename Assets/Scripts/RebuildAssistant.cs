using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GGJ19
{
    public class RebuildAssistant : MonoBehaviour
    {
        public AudioSource mAudio;


        private void OnEnable()
        {
            mAudio.DOFade(1, 2);


            if (Fader.I != null)
            {
                Fader.I.FadeIn();

            }

            if (DeathManager.I != null)
            {
                DeathManager.I.Hide();

            }
        }
    }
}
