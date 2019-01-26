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
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);      

        }
    }
}