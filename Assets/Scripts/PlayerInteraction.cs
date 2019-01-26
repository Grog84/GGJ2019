using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class PlayerInteraction : MonoBehaviour
    {

        Character interactiveCharacter;

        private void Update()
        {
            if (interactiveCharacter != null && Input.GetKeyDown(KeyCode.Space)) {
                if (!GameManager.I.INTERACTING)
                {
                    interactiveCharacter.Interact();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Character")
            {
                interactiveCharacter = collision.GetComponent<Character>();
                interactiveCharacter.ShowInteraction(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Character")
            {
                interactiveCharacter.ShowInteraction(false);
                interactiveCharacter = null;
            }
        }
    }

}

