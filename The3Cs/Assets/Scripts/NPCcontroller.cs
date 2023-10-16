using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    public float lookRadius = 10f;
    public float moveSpeed = 5f;
    public Transform originalPosition; // Store the original position of the enemy

    private Transform target;
    private NavMeshAgent enemy;
    private float timeSincePlayerLastSeen;
    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        enemy = GetComponent<NavMeshAgent>();
        enemy.speed = moveSpeed;
        originalPosition = transform; // Set the original position to the current position

        // Get the Animator component attached to the enemy
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            enemy.SetDestination(target.position);
            timeSincePlayerLastSeen = 0f; // Reset the timer when the player is in radius

            // Set the "isWalking" parameter to true to start walking animation
            animator.SetBool("isWalking", true);
        }
        else
        {
            // Player is not in radius
            timeSincePlayerLastSeen += Time.deltaTime;
            if (timeSincePlayerLastSeen >= 5f)
            {
                // If 5 seconds have passed, return to the original position
                enemy.SetDestination(originalPosition.position);

                // Set the "isWalking" parameter to false to stop walking animation
                animator.SetBool("isWalking", false);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
