using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateNPC : MonoBehaviour
{
    public Animator npcAnimator; // Reference to the NPC's Animator component

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Set the animation state of the NPC to "Idle"
            npcAnimator.SetTrigger("Idle"); // Assuming "Idle" is the name of the idle animation state
        }
    }
}
