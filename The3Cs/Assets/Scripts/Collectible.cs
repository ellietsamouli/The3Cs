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
           


            // Deactivate the collectible to hide it.
            gameObject.SetActive(false);
        }
    }
}
