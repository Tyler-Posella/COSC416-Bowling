using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody rb;

    /// <summary>
    /// Unity's Start method, called before the first frame update.
    /// Initializes the player by setting up the input manager listener and getting the Rigidbody component.
    /// </summary>
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer); //Adding MovePlayer listener to the OnMove event.
        rb = GetComponent<Rigidbody>();
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.y);
        rb.AddForce(speed * moveDirection);
    }
}
