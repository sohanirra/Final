using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingBlock : MonoBehaviour
{
    public float swingSpeed = 2.0f; // Speed of the swinging motion
    public float swingAngle = 50.0f; // Maximum angle of swing

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.rotation = startRotation * Quaternion.Euler(angle, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Example: Push the player back
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (collision.transform.position - transform.position).normalized;
            playerRigidbody.AddForce(forceDirection * 10f, ForceMode.Impulse);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // You can add additional logic here if needed
    }
}