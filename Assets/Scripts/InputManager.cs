using UnityEngine;
using System;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    // Event triggered when there is movement input
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    // Event triggered when the space key is pressed
    public UnityEvent OnSpacePressed = new UnityEvent();
    // Event triggered when the reset key (R) is pressed
    public UnityEvent OnResetPressed = new UnityEvent();

    void Update()
    {
        // Check if the space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Invoke the OnSpacePressed event
            OnSpacePressed?.Invoke();
        }

        // Initialize movement input vector
        Vector2 input = Vector2.zero;
        // Check if the A key is held down
        if (Input.GetKey(KeyCode.A))
        {
            // Add left direction to input vector
            input += Vector2.left;
        }
        // Check if the D key is held down
        if (Input.GetKey(KeyCode.D))
        {
            // Add right direction to input vector
            input += Vector2.right;
        }
        // Invoke the OnMove event with the input vector
        OnMove?.Invoke(input);

        // Check if the R key is pressed down
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Invoke the OnResetPressed event
            OnResetPressed?.Invoke();
        }
    }
}
