using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this to set the character's movement speed

    private Rigidbody2D rb;

    void Start()
    {
        //Make sure Player RB is set up
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get Raw input from the arrow keys or WASD
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector to prevent faster diagonal movement
        movement.Normalize();

        // Apply the movement to the Rigidbody
        rb.velocity = movement * moveSpeed;
    }
}
