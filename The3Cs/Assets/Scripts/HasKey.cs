using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasKey : MonoBehaviour
{
    private bool hasKey = false; // Indicates whether the player has the key.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && !hasKey)
        {
            // Player picked up the key.
            hasKey = true;
            Debug.Log("Key Picked Up");

            // Destroy the key object.
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Door") && hasKey)
        {
            // Player has the key and is colliding with the door.
            Debug.Log("Door Unlocked and Opened");
            Destroy(other.gameObject);
            // You can add code here to open the door. For example, you might animate the door opening.
            // Replace the following line with the appropriate code for your game.
            OpenDoor(other.gameObject);
        }
    }

    private void OpenDoor(GameObject door)
    {
        // Replace this with your door opening logic.
        // For example, you can play an animation, rotate the door, or perform any other door-opening action.
        door.SetActive(false); // For simplicity, we just deactivate the door GameObject.
    }
}
