using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public KeyCode destroyKey = KeyCode.E;
    public float destroyDelay = 2.0f; // Delay in seconds

    private bool destroyRequestPending = false;

    private void Update()
    {
        if (Input.GetKeyDown(destroyKey) && !destroyRequestPending)
        {
            destroyRequestPending = true;
            Invoke("DestroyObject", destroyDelay);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}

