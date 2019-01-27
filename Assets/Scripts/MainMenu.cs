using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ19
{

    public enum MenuBtn { PLAY, CREDITS }

    public class MainMenu : MonoBehaviour
    {
        public Button playBtn;
        public Button creditsBtn;

        public Image selector;

        MenuBtn menuBtn;

        void Update()
        {
            if (Input.GetButtonDown("Vertical"))
            {

            }
        }
    }

}

