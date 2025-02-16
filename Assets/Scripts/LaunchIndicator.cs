using UnityEngine; // Import the UnityEngine namespace
using Unity.Cinemachine; // Import the Cinemachine namespace

public class LaunchIndicator : MonoBehaviour // Define a class named LaunchIndicator that inherits from MonoBehaviour
{
    [SerializeField] private CinemachineCamera freeLookCamera; // SerializeField attribute allows this private field to be set in the Unity Editor

    void Update() // Update is called once per frame
    {
        transform.forward = freeLookCamera.transform.forward; // Set the forward direction of this transform to match the forward direction of the freeLookCamera
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); // Set the rotation of this transform, keeping only the y-axis rotation
    }
}
