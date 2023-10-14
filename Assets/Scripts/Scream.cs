using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public AudioSource soundSource; // Reference to the AudioSource component
    public AudioClip triggerSound; // Sound to be played when the trigger is hit

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is the player (you can change the tag or condition as needed)
        if (other.CompareTag("Player"))
        {
            // Check if an AudioSource and AudioClip are assigned
            if (soundSource != null && triggerSound != null)
            {
                // Play the sound
                soundSource.PlayOneShot(triggerSound);

                // Destroy this object after the audio clip has finished playing
                Destroy(gameObject, triggerSound.length);
            }
        }
    }
}
