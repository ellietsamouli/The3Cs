using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform endPoint; // The position where the platform should move to
    public float moveSpeed = 2.0f;
    public float attachPlayerDelay = 2.0f; // Delay after player enters

    private bool isMoving = false;
    private bool playerAttached = false;

    private void Update()
    {
        if (isMoving)
        {
            // Move the platform towards the endpoint
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerAttached)
        {
            playerAttached = true;
            StartCoroutine(AttachPlayerAfterDelay(collision.transform));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAttached = false;
            // Detach the player from the platform when they leave
            collision.transform.parent = null;
        }
    }

    private IEnumerator AttachPlayerAfterDelay(Transform player)
    {
        // Delay before attaching the player to the platform
        yield return new WaitForSeconds(attachPlayerDelay);

        // Attach the player to the platform
        player.parent = transform;
        isMoving = true;
    }
}
