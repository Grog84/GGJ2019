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

        public void Hide()
        {
            img.color = Color.clear;
        }

        public void ShowDeath(string characterName)
        {
            img.color = Color.white;

            foreach (var item in entries)
            {
                if (item.item == deathItem && item.character == characterName)
                {
                    deathPanel.SetActive(true);
                    text.text = item.text;

                }

                
            }
        }

        IEnumerator ShowDeathCO()
        {
            yield return new WaitForSeconds(8f);
            GameManager.I.GoToMainMenu();
        }
        


    }

}
