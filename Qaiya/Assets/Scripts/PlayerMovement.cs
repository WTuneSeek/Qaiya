using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    // private Vector2 moveDirection;

    private void Update()
    {
        ProcessInputs();
        
    }

    private void FixedUpdate()
    {
        // Move();
        
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * moveX * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * moveY * moveSpeed * Time.deltaTime);

    }

    // private void Move()
    // {
    //     rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    // }
}
