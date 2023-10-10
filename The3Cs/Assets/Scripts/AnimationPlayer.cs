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

    private void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isLiftingHash = Animator.StringToHash("isLifting");
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
        bool pickUpPressed = Input.GetKey("e");

        if (pickUpPressed && !isLifting)
        {
            // Set the "isLifting" parameter to true to trigger the pick-up animation.
            animator.SetBool(isLiftingHash, true);

            // Debug the key press.
            Debug.Log("E key pressed.");
        }
        else if (!pickUpPressed && isLifting)
        {
            // Reset the "isLifting" parameter to false when the "E" key is released.
            animator.SetBool(isLiftingHash, false);
        }

    }
}
