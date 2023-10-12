using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";

    private bool hasKey = false; // Indicates whether the player has the key.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasKey)
        {
            if (openTrigger)
            {
                myDoor.Play(doorOpen, 0, 0.0f);
            }
            else if (closeTrigger)
            {
                myDoor.Play(doorClose, 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }

    public void SetHasKey(bool hasKeyStatus)
    {
        hasKey = hasKeyStatus;
    }

}
