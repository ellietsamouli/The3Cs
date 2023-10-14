using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestart : MonoBehaviour
{
    private Vector3 initialPlayerPosition; // Store the initial player position
    public Transform player; // Reference to the player's Transform component

    private void Start()
    {
        // Store the initial player position
        initialPlayerPosition = player.position;
        Debug.Log("Initial Player Position: " + initialPlayerPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player (you can change the tag or condition as needed)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the player's position to the initial position
            player.position = initialPlayerPosition;
            Debug.Log("Initial Player Position: " + initialPlayerPosition);
        }
    }
}
