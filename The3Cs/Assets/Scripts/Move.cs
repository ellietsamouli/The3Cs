using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;   // Adjust this value to control the movement speed.
    public float rotationSpeed = 100f;  // Adjust this value to control the rotation speed.

    void Update()
    {
        // Get input for movement.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector.
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize the vector to ensure consistent speed in all directions.
        moveDirection.Normalize();

        // Apply movement to the GameObject.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Get input for rotation.
        float rotateInput = Input.GetAxis("Rotate");

        // Rotate the GameObject based on input.
        transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime);
    }

}
