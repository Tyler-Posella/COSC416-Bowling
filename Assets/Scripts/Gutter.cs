using UnityEngine;

public class Gutter : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider attached to the object where this script is attached
    private void OnTriggerEnter(Collider triggeredBody)
    {
        // Check if the collider that entered the trigger has the tag "Ball"
        if (triggeredBody.CompareTag("Ball"))
        {
            // Get the Rigidbody component attached to the ball
            Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>(); 

            // Get the magnitude of the ball's current velocity
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

            // Set the ball's linear and angular velocity to zero to stop it
            ballRigidBody.linearVelocity = Vector3.zero; 
            ballRigidBody.angularVelocity = Vector3.zero;

            // Apply a force to the ball in the forward direction of the gutter with the same magnitude as the original velocity
            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange); 
        }
    }
}
