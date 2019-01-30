using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace GGJ19
{

    public class DeathManager : MonoSingleton<DeathManager>
    {
        public DeathEntry[] entries;

        public CharacterItem deathItem;

        public GameObject deathPanel;
        public TextMeshProUGUI text;

        public Image img;
        bool click = false;

        private void Update()
        {
            if (GameManager.I.PHASE == GamePhase.DEATH)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    click = true;
                }
            }
        }

        public void Hide()
        {
            img.color = Color.clear;
            text.text = "";
        }

        public void ShowDeath(string characterName)
        {
            img.color = Color.white;

            foreach (var item in entries)
            {
                if (item.item == deathItem && item.character == characterName)
                {

                    SfxManager.I.Play("music_game_over");
                    deathPanel.SetActive(true);
                    text.text = item.text;

                    StartCoroutine(ShowDeathCO());

                }

                
            }
        }

        IEnumerator ShowDeathCO()
        {

            while (!click)
            {
                yield return null;
            }
            click = false;

            Hide();
            GameManager.I.GoToMainMenu();

        }
        


    }

}
