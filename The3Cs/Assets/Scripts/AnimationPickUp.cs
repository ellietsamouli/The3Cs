using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPickUp : MonoBehaviour
{
    private Animator animator;
    private int isLiftingHash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isLiftingHash = Animator.StringToHash("isLifting");
    }

    private void Update()
    {
        bool isLifting = animator.GetBool(isLiftingHash);
        bool pickUpPressed = Input.GetKeyDown(KeyCode.E);

        if (pickUpPressed && !isLifting)
        {
            // Set the "isLifting" parameter to true to trigger the pick-up animation.
            animator.SetBool(isLiftingHash, true);
        }
        else if (!pickUpPressed && isLifting)
        {
            // Reset the "isLifting" parameter to false when the "E" key is released.
            animator.SetBool(isLiftingHash, false);
        }
    }
}
