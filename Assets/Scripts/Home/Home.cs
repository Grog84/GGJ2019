using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19 {

    public class Home : MonoBehaviour
    {
        SlotsManager slots;

        public Transform character;

        private void Awake()
        {
            slots = GetComponentInChildren<SlotsManager>();
        }

        public void MoveCharacterIn()
        {
            character.transform.position = transform.position;
        }


    }
}
