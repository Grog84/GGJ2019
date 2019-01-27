using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ19
{
    public enum Winresults { GREAT, GOOD, MEH, BAD }

    public class WinManager : MonoBehaviour
    {
        public Image panelGreat;
        public Image panelGood;
        public Image panelMeh;
        public Image panelBad;

        public void Hide()
        {
            panelGreat.color = Color.clear;
            panelGood.color = Color.clear;
            panelMeh.color = Color.clear;
            panelBad.color = Color.clear;
        }


        public void ShowDeath(int score)
        {
            Winresults res;

        }

    }
}
