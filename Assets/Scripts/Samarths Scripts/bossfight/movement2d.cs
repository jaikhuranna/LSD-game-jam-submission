using System;
using UnityEngine;

public class movement2D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed;
    private bool isGrounded;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
        }
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, 0);

        // Move the player
        MovePlayer(movement);
    }

    void MovePlayer(Vector2 movement)
    {
        // Get the rigidbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Move the player using physics
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0,jumpSpeed),ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}