using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace GGJ19 {

    public class DialogueManager : MonoSingleton<DialogueManager>
    {

        public RectTransform panel;
        TextMeshProUGUI text;

        public float showPosition;
        public float transitionTime;

        float parkingPosition;

        bool isOpen = false;
        bool click = false;

        public CharacterDialogues[] successDialogues;
        public CharacterDialogues endDialogue;

        private void Start()
        {
            parkingPosition = panel.position.y;
            text = panel.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (isOpen && Input.GetKeyDown(KeyCode.Space))
            {
                click = true;
            }
        }

        public void Show(CharacterDialogues dialogues, CharacterAnimation charAnimation)
        {
            StartCoroutine(ShowCO(dialogues, charAnimation));
        }

        public IEnumerator ShowCO(CharacterDialogues dialogues, CharacterAnimation charAnimation)
        {
            foreach (var dialogue in dialogues.dialogues)
            {
                if (isOpen)
                {
                    yield return StartCoroutine(HideCO());
                }

                SfxManager.I.Play("sfx_pannello_testo");

                text.text = dialogue.text;
                charAnimation.SetEmotion(dialogue.emotion);

                panel.DOAnchorPosY(showPosition, transitionTime);
                yield return new WaitForSeconds(transitionTime);

                isOpen = true;

                while (!click)
                {
                    yield return null;
                }
                click = false;
            }

            Hide();

            GameManager.I.INTERACTING = false;
            CameraManager.I.Reset();

        }

        public IEnumerator ShowEmotion(Emotion emotion)
        {
            CharacterDialogues dialogues = successDialogues[(int)emotion];

            foreach (var dialogue in dialogues.dialogues)
            {
                if (isOpen)
                {
                    yield return StartCoroutine(HideCO());
                }

                SfxManager.I.Play("sfx_pannello_testo");

                text.text = dialogue.text;

                panel.DOAnchorPosY(showPosition, transitionTime);
                yield return new WaitForSeconds(transitionTime);

                isOpen = true;

                while (!click)
                {
                    yield return null;
                }
                click = false;
            }

            Hide();

        }

        public IEnumerator ShowEnd()
        {

            foreach (var dialogue in endDialogue.dialogues)
            {
                if (isOpen)
                {
                    yield return StartCoroutine(HideCO());
                }

                SfxManager.I.Play("sfx_pannello_testo");

                text.text = dialogue.text;

                panel.DOAnchorPosY(showPosition, transitionTime);
                yield return new WaitForSeconds(transitionTime);

                isOpen = true;

                while (!click)
                {
                    yield return null;
                }
                click = false;
            }

            Hide();
        }

        public void Hide()
        {
            StartCoroutine(HideCO());
        }
        public IEnumerator HideCO()
        {
            SfxManager.I.Play("sfx_pannello_testo");
            panel.DOMoveY(parkingPosition, transitionTime);
            yield return new WaitForSeconds(transitionTime);

            isOpen = false;
        }


    }

}
