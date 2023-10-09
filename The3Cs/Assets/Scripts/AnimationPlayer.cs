using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    int isWalkingHash;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
       
        isWalkingHash = Animator.StringToHash("isWalking");
    }
    private void Update()
    { 
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        if (!isWalking &&  forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking &&!forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
