using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GGJ19
{
    [CreateAssetMenu]
    public class DeathEntry: ScriptableObject
    {
        public string character;
        public CharacterItem item;
        [TextArea]
        public string text;
    }

    public class DeathManager : MonoSingleton<DeathManager>
    {
        public DeathEntry[] entries;

        public CharacterItem deathItem;

        public GameObject deathPanel;
        public TextMeshProUGUI text;

        public void ShowDeath(string characterName)
        {
            foreach (var item in entries)
            {
                if (item.item == deathItem && item.character == characterName)
                {
                    deathPanel.SetActive(true);
                    text.text = item.text;

                }
            }
        }


    }

}
