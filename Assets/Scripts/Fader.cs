using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GGJ19
{
    public class Fader : MonoSingleton<Fader>
    {
        public Image fadeImg;

        public void FadeOut()
        {
            fadeImg.DOColor(Color.white, 2f);
        }


        public void FadeIn()
        {
            fadeImg.DOColor(Color.clear, 2f);
        }

    }
}
