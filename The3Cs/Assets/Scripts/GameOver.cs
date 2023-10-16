using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    // Public variable to specify the name of the win scene.
    public string winSceneName = "GameOver";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the win scene.
            LoadWinScene();
        }
    }

    // Method to load the win scene.
    private void LoadWinScene()
    {
        if (!string.IsNullOrEmpty(winSceneName))
        {
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            Debug.LogWarning("Win scene name is not set.");
        }
    }

}
