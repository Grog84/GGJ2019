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

        public void Show(CharacterDialogues dialogues)
        {
            StartCoroutine(ShowCO(dialogues));
        }

        public IEnumerator ShowCO(CharacterDialogues dialogues)
        {
            foreach (var dialogue in dialogues.dialogues)
            {
                if (isOpen)
                {
                    yield return StartCoroutine(HideCO());
                }

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

            GameManager.I.INTERACTING = false;
            CameraManager.I.Reset();

        }

        public void Hide()
        {
            StartCoroutine(HideCO());
        }
        public IEnumerator HideCO()
        {
            panel.DOMoveY(parkingPosition, transitionTime);
            yield return new WaitForSeconds(transitionTime);

            isOpen = false;
        }


    }

}
