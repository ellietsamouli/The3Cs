using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
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

            // Now, you should also update the DoorController script to know if the player has the key.
            // You can do this by finding the DoorController script and calling a method to set the hasKey status.
            // For example:
            TriggerDoorController doorController = FindObjectOfType<TriggerDoorController>();
            if (doorController != null)
            {
                doorController.SetHasKey(true);
            }
        }
    }

    // You can add more inventory management functions here.
}
