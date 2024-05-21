using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
 
public class Jump : MonoBehaviour {
 
    public float jumpSpeed = 50f; // Increased jump speed
private bool onGround = false;

Rigidbody rb;

// Use this for initialization
void Start()
{
    rb = GetComponent<Rigidbody>();
}

float movementSpeed = 10f; // Added an initial value for movement speed

// Update is called once per frame
void Update()
{
    float amountToMove = movementSpeed * Time.deltaTime;
    Vector3 movement = (Input.GetAxis("Horizontal") * -Vector3.left * amountToMove) + (Input.GetAxis("Vertical") * Vector3.forward * amountToMove);
    rb.AddForce(movement, ForceMode.Force);

    if (Input.GetKeyDown("space") && onGround)
    {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        onGround = false; // prevents jumping again until landing
    }
}

void OnCollisionStay(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground")) // only ground collisions set onGround to true
    {
        onGround = true;
    }
}

void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground")) // Ensures onGround is false when leaving the ground
    {
        onGround = false;
    }
}
}