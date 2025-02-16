using UnityEngine;

public class BallController : MonoBehaviour
{
    // Serialized fields to set in the Unity Editor
    [SerializeField] private float force = 1f; // Force applied to launch the ball
    [SerializeField] private InputManager inputManager; // Reference to the InputManager
    [SerializeField] private Transform ballAnchor; // Anchor point for the ball
    [SerializeField] private Transform launchIndicator; // Indicator for launch direction

    // Private fields
    private bool isBallLaunched; // Flag to check if the ball is launched
    private Rigidbody ballRB; // Rigidbody component of the ball

    void Start()
    {
        // Get the Rigidbody component attached to the ball
        ballRB = GetComponent<Rigidbody>();

        // Add listener to the space key press event
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        // Initialize the ball position and state
        InitializeBall();
    }

    // Method to initialize the ball position and state
    private void InitializeBall()
    {
        // Set the ball's parent to the anchor and reset its position
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;

        // Make the ball kinematic to prevent physics interactions
        ballRB.isKinematic = true;

        // Reset the ball state
        ResetBall();
    }

    // Method to launch the ball
    private void LaunchBall()
    {
        // If the ball is already launched, do nothing
        if (isBallLaunched) return;

        // Set the ball as launched
        isBallLaunched = true;

        // Detach the ball from the anchor and enable physics interactions
        transform.parent = null;
        ballRB.isKinematic = false;

        // Apply force to the ball in the direction of the launch indicator
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);

        // Disable the launch indicator
        launchIndicator.gameObject.SetActive(false);
    }

    // Method to reset the ball to its initial state
    public void ResetBall()
    {
        // Set the ball as not launched
        isBallLaunched = false;

        // Make the ball kinematic to prevent physics interactions
        ballRB.isKinematic = true;

        // Enable the launch indicator
        launchIndicator.gameObject.SetActive(true);

        // Set the ball's parent to the anchor and reset its position
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }
}
