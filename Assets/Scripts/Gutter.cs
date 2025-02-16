using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        if (triggeredBody.CompareTag("Ball"))
        {
            Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>(); //Get rigidy body of ball, store in variable

            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude; //Store velocity magnitude before resetting velocity

            ballRigidBody.linearVelocity = Vector3.zero; //Reset both linear and angular velocity, because ball is rotating on ground when moving.
            ballRigidBody.angularVelocity = Vector3.zero;

            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange); //Now add force in forward direction of gutter, use cashed velocity magnitude to keep it somewhat realistic.
        }
    }
}
