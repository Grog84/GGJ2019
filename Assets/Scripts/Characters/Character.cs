using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using DG.Tweening;


namespace GGJ19 {

    public class Character : MonoBehaviour
    {
        public CharacterChoices choices;
        public CharacterDialogues dialogues;

        public SpriteRenderer interactImage;

        public Sprite[] pocketItems;

        CharacterPockets pockets;

        private void Start()
        {
            pockets = GetComponentInChildren<CharacterPockets>();
        }

        public void ShowInteraction(bool status)
        {
            float targetAlpha = status ? 1f : 0f;
            interactImage.DOFade(targetAlpha, 0.5f);
        }

        public void Interact()
        {
            GameManager.I.INTERACTING = true;
            ShowInteraction(false);

            CameraManager.I.StartFollowing(transform);
            CameraManager.I.ZoomIn();

            pockets.Show(pocketItems);

            DialogueManager.I.Show(dialogues);
        }
    }
}

