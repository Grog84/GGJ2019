using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class PlayerInteraction : MonoBehaviour
    {

        Character interactiveCharacter;
        WorkSign sign;

        private void Update()
        {
            if (interactiveCharacter != null && Input.GetKeyDown(KeyCode.Space)) {
                if (!GameManager.I.INTERACTING)
                {
                    interactiveCharacter.Interact();
                }
            }

            if (sign != null && Input.GetKeyDown(KeyCode.Space))
            {
                if (!GameManager.I.INTERACTING)
                {
                    sign.Interact();
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
            else if (collision.tag == "Sign")
            {
                SfxManager.I.Play("sfx_popup_interazione");
                sign = collision.GetComponent<WorkSign>();
                sign.ShowInteraction(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Character")
            {
                interactiveCharacter.ShowInteraction(false);
                interactiveCharacter = null;
            }
            else if (collision.tag == "Sign")
            {
                SfxManager.I.Play("sfx_popup_interazione");
                sign.ShowInteraction(false);
                sign = null;
            }
        }
    }

}

