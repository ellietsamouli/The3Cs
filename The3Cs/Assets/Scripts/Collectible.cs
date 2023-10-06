using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the collectible.
        if (other.CompareTag("Player"))
        {
            // Debug log a message when the player touches the collectible.
            Debug.Log("WOW");

            // You can add any other logic here, such as increasing the player's score, playing a sound, or deactivating the collectible.

            // Deactivate the collectible to hide it.
            gameObject.SetActive(false);
        }
    }
}
