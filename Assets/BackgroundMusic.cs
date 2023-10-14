using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; // Reference to the background music audio clip
    private AudioSource audioSource;
    private void Awake()
    {
        // This ensures that the GameObject won't be destroyed when loading a new scene.
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Create an AudioSource component on the GameObject

        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Loop the background music
            audioSource.Play(); // Play the background music
        }
        else
        {
            Debug.LogWarning("Background music clip is not assigned. Please assign an AudioClip in the Inspector.");
        }
    }
}
