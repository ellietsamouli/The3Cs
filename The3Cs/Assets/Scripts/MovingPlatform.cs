using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform startPosition; // The starting position.
    [SerializeField] private Transform endPosition; // The ending position.

    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float pauseTime = 1.0f; // Time to pause at each end position.

    private bool movingToEnd = true;
    private float timer = 0.0f;
    private bool playerOnPlatform = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            if (movingToEnd)
            {
                // Move the platform towards the end position.
                transform.position = Vector3.MoveTowards(transform.position, endPosition.position, moveSpeed * Time.deltaTime);

                // Check if the platform has reached the end position.
                if (transform.position == endPosition.position)
                {
                    // Stop the platform from moving further.
                    movingToEnd = false;
                    timer = 0.0f;
                }
            }
            else
            {
                // Pause at the end position for a specified time.
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    // Move the platform back to the start position.
                    transform.position = Vector3.MoveTowards(transform.position, startPosition.position, moveSpeed * Time.deltaTime);

                    // Check if the platform has reached the start position.
                    if (transform.position == startPosition.position)
                    {
                        // Start moving towards the end position again.
                        movingToEnd = true;
                        timer = 0.0f;
                    }
                }
            }
        }
    }
}
