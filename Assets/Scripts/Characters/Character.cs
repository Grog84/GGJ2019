using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using DG.Tweening;


namespace GGJ19 {

    public class Character : MonoBehaviour
    {
        public string m_name;

        public CharacterChoices choices;
        public CharacterDialogues dialogues;

        public SpriteRenderer interactImage;

        public Sprite[] pocketItems;

        CharacterPockets pockets;
        public Transform mainBone;

        CharacterAnimation charAnimation;

        private void Start()
        {
            pockets = GetComponentInChildren<CharacterPockets>();
            charAnimation = GetComponent<CharacterAnimation>();

            charAnimation.characterName = m_name;
        }

        public void ShowInteraction(bool status)
        {
            SfxManager.I.Play("sfx_popup_interazione");
            float targetAlpha = status ? 1f : 0f;
            interactImage.DOFade(targetAlpha, 0.5f);
        }

        public void Interact()
        {
            GameManager.I.INTERACTING = true;
            ShowInteraction(false);

            CameraManager.I.StartFollowing(mainBone);
            CameraManager.I.ZoomIn();

            pockets.Show(pocketItems);

            DialogueManager.I.Show(dialogues, charAnimation);
        }
    }
}

