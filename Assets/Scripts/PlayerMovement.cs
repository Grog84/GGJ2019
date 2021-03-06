using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ19
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 2f;

        private Vector2 movement = Vector2.zero;
        private Rigidbody2D rb;

        bool isFlipped = true;

        BoxCollider2D[] colliders;

        AudioSource audio;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            colliders = GetComponents<BoxCollider2D>();
            audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if ((movement.x != 0 || movement.y != 0) && !audio.isPlaying)
            {
                audio.Play();

            }
            else if ((movement.x == 0 && movement.y == 0) && audio.isPlaying)
            {

                audio.Stop();
            }
        }

        private void FixedUpdate()
        {
            if (!GameManager.I.INTERACTING)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
                if (movement.x != 0f && !isFlipped && Mathf.Sign(movement.x) == -1f) {
                    Flip();
                } else if (movement.x != 0f && isFlipped && Mathf.Sign(movement.x) == 1f) {
                    Flip();
                }
            }

        }

        void Flip()
        {
            float xScale = transform.localScale.x;
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            isFlipped = !isFlipped;
        }

        public void SetCollidersActive(bool status)
        {
            foreach (var col in colliders)
            {
                col.enabled = status;
            }
        }

        

    }
}