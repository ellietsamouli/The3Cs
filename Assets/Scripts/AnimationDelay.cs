using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    private Animator animator;

    public float delayBeforeAnimation = 2.0f;  // Delay in seconds before playing the animation

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimationWithDelay());
    }

    IEnumerator PlayAnimationWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeAnimation);
        animator.SetTrigger("YourAnimationTrigger"); // Replace with the name of your animation trigger
    }
}
