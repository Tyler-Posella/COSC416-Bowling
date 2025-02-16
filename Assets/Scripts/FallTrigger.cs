using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    // Event that gets triggered when the pin falls
    public UnityEvent OnPinFall = new();

    // Boolean to check if the pin has already fallen
    public bool isPinFallen = false;

    // Method called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider triggeredObject)
    {
        // Check if the object that entered the trigger has the tag "Ground" and the pin has not already fallen
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            // Set the pin fallen status to true
            isPinFallen = true;

            // Invoke the OnPinFall event
            OnPinFall?.Invoke();

            // Log the name of the fallen pin
            Debug.Log($"{gameObject.name} has fallen");
        }
    }
}
