using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;
    private int isRunningHash;
    private int isWalkingHash;
    private int isJumpingHash;
    private int isLiftingHash;
    private int isOpeningHash; // The new animation parameter

    private bool hasKey = false;

    private void Start()
    {
        animator = GetComponent < Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isLiftingHash = Animator.StringToHash("isLifting");
        isOpeningHash = Animator.StringToHash("isOpening"); // Assign the hash for the new parameter
        
    }

    private void Update()
    {
        // Character movement logic
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown("space");

        // Check for jump input and set the isJumping parameter accordingly.
        animator.SetBool(isJumpingHash, jumpPressed);

        if (isRunning)
        {
            if (!forwardPressed || !runPressed)
            {
                animator.SetBool(isRunningHash, false);
            }
        }
        else
        {
            if (forwardPressed && runPressed)
            {
                animator.SetBool(isRunningHash, true);
            }
        }

        if (isWalking)
        {
            if (!forwardPressed)
            {
                animator.SetBool(isWalkingHash, false);
            }
        }
        else
        {
            if (forwardPressed)
            {
                animator.SetBool(isWalkingHash, true);
            }
        }

        // Pick-up animation logic
        bool isLifting = animator.GetBool(isLiftingHash);
        bool pickUpPressed = Input.GetKey("c");

        if (pickUpPressed && !isLifting)
        {
            // Set the "isLifting" parameter to true to trigger the pick-up animation.
            animator.SetBool(isLiftingHash, true);
        }
        else if (!pickUpPressed && isLifting)
        {
            // Reset the "isLifting" parameter to false when the "C" key is released.
            animator.SetBool(isLiftingHash, false);
        }

        // Check if the player has the key
        if (hasKey)
        {
            // Opening animation logic
            bool isOpening = animator.GetBool(isOpeningHash);
            bool openPressed = Input.GetKey("o");
           
            if (openPressed && !isOpening)
            {
                // Set the "isOpening" parameter to true to trigger the opening animation.
                animator.SetBool(isOpeningHash, true);
               
            }
            else if (!openPressed && isOpening)
            {
                // Reset the "isOpening" parameter to false when the "O" key is released.
                animator.SetBool(isOpeningHash, false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            // If the player collides with an object tagged "Key," set hasKey to true.
            hasKey = true;
        }
    }
}
