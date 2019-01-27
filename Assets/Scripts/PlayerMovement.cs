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

        bool isFlipped = false;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
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

        

    }
}