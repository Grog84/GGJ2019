using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using UnityEngine.SceneManagement;

namespace GGJ19
{

    public enum MenuBtn { PLAY, CREDITS }

    public class MainMenu : MonoBehaviour
    {
        public float playBtn_y;
        public float creditsBtn_y;

        public RectTransform selector;

        public AudioSource mAudio;

        MenuBtn menuBtn = MenuBtn.PLAY;

        private void Start()
        {
            Fader.I.FadeIn();
            mAudio.DOFade(0.8f, 5);
            mAudio.DOPlay();
        }

        void Update()
        {
            if (Input.GetButtonDown("Vertical"))
            {
                if (Input.GetAxis("Vertical") < 0 && menuBtn == MenuBtn.PLAY)
                {
                    selector.DOAnchorPosY(creditsBtn_y, 1f);
                    menuBtn = MenuBtn.CREDITS;
                    SfxManager.I.Play("sfx_over");
                }
                else if (Input.GetAxis("Vertical") < 1 && menuBtn == MenuBtn.CREDITS)
                {

                    selector.DOAnchorPosY(playBtn_y, 1f);
                    menuBtn = MenuBtn.PLAY;
                    SfxManager.I.Play("sfx_over");
                }

            }

            if (Input.GetButtonDown("Jump"))
            {
                if (menuBtn == MenuBtn.PLAY)
                {
                    StartCoroutine(PlayCO());
                }
            }
        }

        IEnumerator PlayCO()
        {
            Fader.I.FadeOut();
            mAudio.DOFade(0, 2);

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(1);
            Fader.I.FadeOut();
        }

        private void OnEnable()
        {
            if (DeathManager.I != null)
            {
                DeathManager.I.Hide();

            }
        }

    }

}

