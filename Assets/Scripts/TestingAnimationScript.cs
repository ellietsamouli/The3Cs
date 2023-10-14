using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingAnimationScript : MonoBehaviour
{
    private Animator animator;
    private int isRunningHash;
    private int isWalkingHash;
    private int isJumpingHash;
    private int isLiftingHash;
    private int isOpeningHash; // The new animation parameter

    private bool hasKey = false;

    public AudioSource walkingAudioSource;
    public AudioSource runningFootstepsAudioSource;
    public AudioSource runningBreathingAudioSource;

    public AudioClip walkingClip;
    public AudioClip runningFootstepClip;
    public AudioClip runningBreathingClip;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isLiftingHash = Animator.StringToHash("isLifting");
        isOpeningHash = Animator.StringToHash("isOpening"); // Assign the hash for the new parameter
    }

    private void Update()
    {
        // Character movement logic
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown("space");

        // Check for jump input and set the isJumping parameter accordingly.
        animator.SetBool(isJumpingHash, jumpPressed);

        if (forwardPressed && runPressed)
        {
            animator.SetBool(isRunningHash, true);
            animator.SetBool(isWalkingHash, false);

            if (!runningFootstepsAudioSource.isPlaying)
            {
                runningFootstepsAudioSource.clip = runningFootstepClip;
                runningFootstepsAudioSource.Play();
            }
            if (!runningBreathingAudioSource.isPlaying)
            {
                runningBreathingAudioSource.clip = runningBreathingClip;
                runningBreathingAudioSource.Play();
            }
        }
        else if (forwardPressed)
        {
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isWalkingHash, true);

            runningFootstepsAudioSource.Stop();
            runningBreathingAudioSource.Stop();

            if (!walkingAudioSource.isPlaying)
            {
                walkingAudioSource.clip = walkingClip;
                walkingAudioSource.Play();
            }
        }
        else
        {
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isWalkingHash, false);
           
            runningFootstepsAudioSource.Stop();
            runningBreathingAudioSource.Stop();
            walkingAudioSource.Stop();
        }


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
 }


