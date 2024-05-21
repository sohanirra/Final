using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PtestController : MonoBehaviour
{
    public float moveSpeed = 2f; // Adjust this value to change movement speed
    private Rigidbody rb;
    private Vector3 respawnPosition; // Position to respawn the player

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Ensure the player doesn't tip over
        respawnPosition = transform.position; // Save the initial position as the respawn position
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Move the player using Rigidbody
        rb.MovePosition(transform.position + movement);

        // condition to respawn player, such as falling below a certain y-coordinate
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        rb.velocity = Vector3.zero; // Reset the players velocity
    }
}
