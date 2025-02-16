using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Serialized fields for setting in the Unity Editor
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;

    // Private fields for internal use
    private FallTrigger[] pins;
    private GameObject pinObjects;

    private void Start()
    {
        // Find all pins in the scene
        pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);

        // Add listener to each pin's fall event
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

        // Add listener to the reset button press event
        inputManager.OnResetPressed.AddListener(HandleReset);

        // Initialize pins
        SetPins();
    }

    // Increment the score and update the score text
    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    // Handle the reset event
    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    // Set up the pins in the scene
    private void SetPins()
    {
        // Destroy existing pins if any
        if (pinObjects != null)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // Instantiate new pins
        pinObjects = Instantiate(pinCollection, pinAnchor.position, Quaternion.identity, transform);

        // Find all pins including inactive ones
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        // Add listener to each pin's fall event
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }
}
